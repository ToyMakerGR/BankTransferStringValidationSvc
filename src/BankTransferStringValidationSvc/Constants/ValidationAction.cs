namespace Defender.MarkII.BankTransferStringValidationSvc.Constants;

/// <summary>
/// Describes the action that must be taken after a validation
/// </summary>
public enum ValidationAction
{
    /// <summary>
    /// Default-fallback
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Issue a warning to the customer
    /// </summary>
    Warning = 1,
    /// <summary>
    /// Block the transaction
    /// </summary>
    Block = 2,
    /// <summary>
    /// Okey-dokey
    /// </summary>
    Ok = 200
}