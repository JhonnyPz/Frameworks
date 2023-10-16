using System.ComponentModel.DataAnnotations;

namespace app.Schemas;

public class Validations : ValidationAttribute
{
  private readonly string[] _whiteList;

  public Validations(string[] whiteList)
  {
    _whiteList = whiteList;
  }

  protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
  {
    var list = value as string[];

    if (list != null && list.Any(item => !_whiteList.Contains(item)))
    {
      return new ValidationResult(GetErrorMessage());
    }

    return ValidationResult.Success!;
  }

  private string GetErrorMessage()
  {
    return $"Input is not valid: choose from the following accepted values: {string.Join(", ", _whiteList)}";
  }
}
