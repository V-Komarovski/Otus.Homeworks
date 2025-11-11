using System.Reflection;
using System.Text;

namespace Otus.Homeworks.HW7;

/// <summary>
/// Кастомный сериализатор.
/// </summary>
internal static class CustomSerializer
{
    public static string Serialize(object obj)
    {
        var type = obj.GetType();
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        var result = new StringBuilder();
        foreach (var prop in props)
        {
            result.AppendLine($"{prop.Name}={prop.GetValue(obj)}");
        }

        foreach (var field in fields)
        {
            result.AppendLine($"{field.Name}={field.GetValue(obj)}");
        }

        return result.ToString();
    }

    public static T Deserialize<T>(string data)
        where T : class, new()
    {
        var obj = new T();
        var lines = data.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var type = typeof(T);
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (var line in lines)
        {
            var parts = line.Split('=');
            if (parts.Length != 2) continue;

            var name = parts[0].Trim();
            var value = int.Parse(parts[1]);

            // Проверяем свойства
            foreach (var prop in props)
            {
                if (prop.Name == name && prop.PropertyType == typeof(int))
                {
                    prop.SetValue(obj, value);
                    break;
                }
            }

            // Проверяем поля
            foreach (var field in fields)
            {
                if (field.Name == name && field.FieldType == typeof(int))
                {
                    field.SetValue(obj, value);
                    break;
                }
            }
        }

        return obj;
    }

    public static T DeserializeFromCsv<T>(string data)
        where T : class, new()
    {
        var obj = new T();
        var lines = data.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var type = typeof(T);
        var fields = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        if (lines.Length < 2)
        {
            return obj;
        }

        var headers = lines[0].Split(';');
        var values = lines[1].Split(';');

        for (var i = 0; i < headers.Length && i < values.Length; i++)
        {
            var key = headers[i].Trim();
            var strValue = values[i].Trim();

            if (!int.TryParse(strValue, out var value))
            {
                continue;
            }

            foreach (var field in fields)
            {
                if (field.Name == key && field.PropertyType == typeof(int))
                {
                    field.SetValue(obj, value);
                    break;
                }
            }
        }

        return obj;
    }
}