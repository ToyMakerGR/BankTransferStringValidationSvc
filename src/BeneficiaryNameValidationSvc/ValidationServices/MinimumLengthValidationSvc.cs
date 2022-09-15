namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using System.Threading.Tasks;
using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

/// <summary>
/// <see cref="INameValidationSvc"> implementation - name minimum length
/// </summary>
public class MinimumLengthValidationSvc : INameValidationSvc
{
    #region INameValidationSvc members

    public EvaluationResult? Result { get; private set; }

    public async Task Validate(string Name)
    {
        Result = new EvaluationResult();
        if (string.IsNullOrWhiteSpace(Name) || Name.Length < 3)
        {
            Result.Result = ValidationResult.MinimumLengthNotMet;
            Result.Action = ValidationAction.Block;
        }
        await Task.CompletedTask;
    }

    #endregion

}