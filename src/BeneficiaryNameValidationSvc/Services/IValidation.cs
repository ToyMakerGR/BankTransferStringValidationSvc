namespace Defender.MarkII.BeneficiaryNameValidationSvc.Services;

using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

public interface IValidationSvc
{
    Task<EvaluationResult> Validate(string stringOfInterest, ValidationScope scope);
}