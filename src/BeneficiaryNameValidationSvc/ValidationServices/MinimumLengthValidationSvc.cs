namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using System.Threading.Tasks;
using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

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