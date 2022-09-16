namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

/// <summary>
/// <see cref="IStringValidationSvc"> implementation - repeated characters
/// </summary>
public class RepeatedCharsValidationSvc : IStringValidationSvc
{
    #region IStringValidationSvc members

    public EvaluationResult? Result { get; private set; }

    public IEnumerable<ValidationScope> Scopes => new[] { ValidationScope.BeneficiaryName };

    public async Task Validate(string stringOfInterest)
    {
        Result = new EvaluationResult();
        var m = Regex.Match(stringOfInterest, @"(.)\1{4,}", RegexOptions.IgnoreCase);
        if (m.Success)
        {
            Result.Result = ValidationResult.RepeatedCharacters;
            Result.Action = ValidationAction.Block;
        }
        else
        {
            m = Regex.Match(stringOfInterest, @"(.)\1{2,}", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                Result.Result = ValidationResult.RepeatedCharacters;
                Result.Action = ValidationAction.Warning;
            }
        }
        await Task.CompletedTask;
    }

    #endregion

}