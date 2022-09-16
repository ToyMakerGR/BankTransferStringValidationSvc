namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

public class ValidationSvc : IValidationSvc
{
    IEnumerable<IStringValidationSvc> _validationServices;

    public ValidationSvc(IEnumerable<IStringValidationSvc> validationServices)
    {
        _validationServices = validationServices;
    }

    #region IValidationSvc members

    public async Task<EvaluationResult> Validate(string stringOfInterest, ValidationScope scope)
    {
        var result = new EvaluationResult();
        if (!_validationServices.Any())
        {
            return result;
        }
        if (string.IsNullOrWhiteSpace(stringOfInterest))
        {
            stringOfInterest = string.Empty;
        }

        var s = stringOfInterest.ToLower().Trim();
        foreach (var validationSvc in _validationServices.Where(v => v.Scopes.Contains(scope)))
        {
            await validationSvc.Validate(s);
        }

        var failedValidation = _validationServices.FirstOrDefault(v => v.Result?.Result != ValidationResult.Ok);
        if (failedValidation != null)
        {
            result = failedValidation.Result!;
        }

        return result;
    }

    #endregion

}