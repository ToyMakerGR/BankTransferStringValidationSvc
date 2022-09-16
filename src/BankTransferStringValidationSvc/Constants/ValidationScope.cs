namespace Defender.MarkII.BankTransferStringValidationSvc.Constants;

/// <summary>
/// Describes the scope of a validation
/// </summary>
public enum ValidationScope
{
    /// <summary>
    /// Default-fallback
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Beneficiary name
    /// </summary>
    BeneficiaryName = 1,
    /// <summary>
    /// Bank transfer description fields
    /// </summary>
    RemittanceInfo = 2,
    /// <summary>
    /// Debtor address information
    /// </summary>
    Address = 3
}