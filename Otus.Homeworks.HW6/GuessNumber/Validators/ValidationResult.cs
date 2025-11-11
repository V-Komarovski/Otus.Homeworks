namespace Otus.Homeworks.HW6.GuessNumber.Validators;

/// <summary>
/// Результат валидации
/// </summary>
/// <param name="IsValid">Признак успешной валидации</param>
/// <param name="ValidationMessage">Сообщение валидатора</param>
internal record ValidationResult(bool IsValid, string ValidationMessage);