namespace Defender.MarkII.BankTransferStringValidationSvc.ValidationServices;

using System.Threading.Tasks;
using Defender.MarkII.BankTransferStringValidationSvc.Constants;
using Defender.MarkII.BankTransferStringValidationSvc.Model;

/// <summary>
/// <see cref="IStringValidationSvc"> implementation - name minimum length
/// </summary>
public class MinimumLengthValidationSvc : IStringValidationSvc
{
    #region IStringValidationSvc members

    public EvaluationResult? Result { get; private set; }

    public IEnumerable<ValidationScope> Scopes => new[] { ValidationScope.BeneficiaryName };

    public async Task Validate(string stringOfInterest)
    {
        Result = new EvaluationResult();
        if (string.IsNullOrWhiteSpace(stringOfInterest) || stringOfInterest.Length < 3)
        {
            Result.Result = ValidationResult.MinimumLengthNotMet;
            Result.Action = ValidationAction.Block;
        }
        await Task.CompletedTask;
    }

    #endregion

}