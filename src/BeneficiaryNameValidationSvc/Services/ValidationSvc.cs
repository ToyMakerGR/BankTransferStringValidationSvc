namespace Defender.MarkII.BeneficiaryNameValidationSvc.Services;

using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Infrastructure;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;
using Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

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

        var s = stringOfInterest.ToLower().Trim().RemoveDiacritics();
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