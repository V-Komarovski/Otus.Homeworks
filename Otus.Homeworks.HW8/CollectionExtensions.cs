namespace Otus.Homeworks.HW8;

internal static class CollectionExtensions
{
    /// <summary>
    /// Возвращает максимальный элемент по числовому параметру
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">Коллекция элементов</param>
    /// <param name="getParameter">Функция, возвращающая параметр, по которому сравниваются элементы</param>
    internal static T? GetMax<T>(this IList<T> collection, Func<T, float> getParameter) where T : class
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(getParameter);

        if (!collection.Any())
        {
            throw new ArgumentException("Пустая коллекция", nameof(collection));     
        }

        var maxValue = float.MinValue;
        T? maxItem = null;
        foreach (var item in collection)
        {
            var value = getParameter(item);
            if (value > maxValue)
            {
                maxValue = value;
                maxItem = item;
            }
        }

        return maxItem;
    }
}