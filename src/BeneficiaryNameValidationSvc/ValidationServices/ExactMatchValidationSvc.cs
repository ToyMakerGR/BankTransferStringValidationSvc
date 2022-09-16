namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using System.Linq;
using System.Threading.Tasks;
using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

/// <summary>
/// <see cref="IStringValidationSvc"> implementation - exact matches for beneficiary names
/// </summary>
public class ExactMatchValidationSvc : IStringValidationSvc
{
    #region IStringValidationSvc members

    public EvaluationResult? Result { get; private set; }

    public IEnumerable<ValidationScope> Scopes => new[] { ValidationScope.BeneficiaryName };

    public async Task Validate(string stringOfInterest)
    {
        Result = new EvaluationResult();
        var forbiddenStrings = new[]{
            "Own",
            "Transfer",
            "Transfer to own account",
            "Transfer to my account",
            "Own transfer",
            "Own account",
            "Own funds",
            "Anonymous",
            "No name",
            "Noname",
            "No matter who",
            "Customer",
            "Client",
            "Eurobank",
            "Alpha",
            "Alpha Bank",
            "National Bank of Greece",
            "National Bank",
            "Ethniki",
            "NBG",
            "Piraeus",
            "Piraeus Bank",
            "Peiraiws",
            "Peiraios",
            "Attica Bank",
            "Attica",
            "Cooperative Bank",
            "Cooperative"
        };
        if (
            forbiddenStrings.Contains(stringOfInterest, StringComparer.InvariantCultureIgnoreCase) ||
            stringOfInterest.Contains("bank", StringComparison.InvariantCultureIgnoreCase)
        )
        {
            Result.Result = ValidationResult.PredefinedSuspiciousWords;
            Result.Action = ValidationAction.Warning;
        }
        await Task.CompletedTask;
    }

    #endregion

}