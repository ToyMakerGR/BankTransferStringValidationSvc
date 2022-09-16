namespace Defender.MarkII.BankTransferStringValidationSvc.ValidationServices;

using Defender.MarkII.BankTransferStringValidationSvc.Constants;
using Defender.MarkII.BankTransferStringValidationSvc.Model;

/// <summary>
/// Blueprint for all validation strategies
/// </summary>
public interface IStringValidationSvc
{
    /// <summary>
    /// The <see cref="ValidationResult"> when validation has been performed.
    /// </summary>
    EvaluationResult? Result { get; }

    /// <summary>
    /// Scopes which this validation service instance is valid for.
    /// </summary>
    IEnumerable<ValidationScope> Scopes { get; }

    /// <summary>
    /// Performs validation against the provided string.
    /// </summary>
    /// <param name="stringOfInterest">The string to validate</param>
    /// <returns>An empty task.</returns>
    Task Validate(string stringOfInterest);
}