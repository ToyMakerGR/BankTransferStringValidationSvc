namespace Defender.MarkII.BankTransferStringValidationSvc.ValidationServices;

using System.Collections.Generic;
using System.Threading.Tasks;
using Defender.MarkII.BankTransferStringValidationSvc.Constants;
using Defender.MarkII.BankTransferStringValidationSvc.Model;

/// <summary>
/// <see cref="IStringValidationSvc"> implementation - consecutive characters
/// </summary>
public class ConsecutiveCharsValidationSvc : IStringValidationSvc
{
    const string enAlphabet = "abcdefghijklmnopqrstuvwxyz";
    const string grAlphabet = "αβγδεζηθικλμνξοπρστυφχψω";
    const string numbers = "01234567890";

    #region IStringValidationSvc members

    public EvaluationResult? Result { get; private set; }

    public IEnumerable<ValidationScope> Scopes => new[] { ValidationScope.BeneficiaryName };

    public async Task Validate(string stringOfInterest)
    {
        Result = new EvaluationResult();
        if (stringOfInterest.Length < 3)
        {
            await Task.CompletedTask;
            return;
        }

        for (var i = stringOfInterest.Length; i >= 3; i--)
        {
            for (var z = 0; z <= stringOfInterest.Length - i; z++)
            {
                var s = stringOfInterest.Substring(z, i).ToLower();
                if (IsConsecutive(stringOfInterest.Substring(z, i)))
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
        enAlphabet.Contains(s, StringComparison.InvariantCultureIgnoreCase) ||
        grAlphabet.Contains(s, StringComparison.InvariantCultureIgnoreCase) ||
        numbers.Contains(s, StringComparison.InvariantCultureIgnoreCase);
}