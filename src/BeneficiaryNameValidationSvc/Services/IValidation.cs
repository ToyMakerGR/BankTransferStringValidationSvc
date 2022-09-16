namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

public interface IValidationSvc
{
    Task<EvaluationResult> Validate(string stringOfInterest, ValidationScope scope);
}