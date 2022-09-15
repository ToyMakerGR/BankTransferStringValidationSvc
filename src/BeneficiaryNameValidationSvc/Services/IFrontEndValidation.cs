namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

public interface IFrontEndValidation
{
    EvaluationResult Validate(string Name);
}