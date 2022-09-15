namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using System.Threading.Tasks;
using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

/// <summary>
/// <see cref="INameValidationSvc"> implementation - consecutive characters
/// </summary>
public class ConsecutiveCharsValidationSvc : INameValidationSvc
{
    const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    const string numbers = "01234567890";

    #region INameValidationSvc members

    public EvaluationResult? Result { get; private set; }

    public async Task Validate(string Name)
    {
        Result = new EvaluationResult();
        if (Name.Length < 3)
        {
            await Task.CompletedTask;
            return;
        }

        for (var i = Name.Length; i >= 3; i--)
        {
            for (var z = 0; z <= Name.Length - i; z++)
            {
                var s = Name.Substring(z, i).ToLower();
                if (IsConsecutive(Name.Substring(z, i)))
                {
                    Result.Result = ValidationResult.ConsecutiveCharacters;
                    Result.Action = i > 4 ? ValidationAction.Block : ValidationAction.Warning;
                    await Task.CompletedTask;
                    return;
                }
            }
        }
    }

    #endregion

    bool IsConsecutive(string s) =>
        alphabet.Contains(s, StringComparison.InvariantCultureIgnoreCase) ||
        numbers.Contains(s, StringComparison.InvariantCultureIgnoreCase);
}