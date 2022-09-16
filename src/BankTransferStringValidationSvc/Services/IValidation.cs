namespace Defender.MarkII.BankTransferStringValidationSvc.Services;

using Defender.MarkII.BankTransferStringValidationSvc.Constants;
using Defender.MarkII.BankTransferStringValidationSvc.Model;

public interface IValidationSvc
{
    Task<EvaluationResult> Validate(string stringOfInterest, ValidationScope scope);
}