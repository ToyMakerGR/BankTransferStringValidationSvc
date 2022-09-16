namespace Defender.MarkII.BankTransferStringValidationSvc.Model;

using Defender.MarkII.BankTransferStringValidationSvc.Constants;

/// <summary>
/// The result of a validation
/// </summary>
public record EvaluationResult
{
    /// <summary>
    /// The <see cref="Constants.Action"> that must be taken based on the performed validation
    /// </summary>
    public ValidationAction? Action { get; set; }

    /// <summary>
    /// The <see cref="Constants.Result"> of the performed validation
    /// </summary>
    public ValidationResult? Result { get; set; }

    /// <summary>
    /// Any metadata relevant to the performed validation
    /// </summary>
    public string? Metadata { get; set; }

    public EvaluationResult()
    {
        Action = ValidationAction.Ok;
        Result = ValidationResult.Ok;
    }
}