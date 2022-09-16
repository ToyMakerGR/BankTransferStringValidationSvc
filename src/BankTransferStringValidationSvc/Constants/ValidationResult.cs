namespace Defender.MarkII.BankTransferStringValidationSvc.Constants;

/// <summary>
/// Describes the result of a validation strategy
/// </summary>
public enum ValidationResult
{
    /// <summary>
    /// Default-fallback
    /// </summary>
    Undefined = 0,
    /// <summary>
    /// Minimum length requirements not met
    /// </summary>
    MinimumLengthNotMet = 1,
    /// <summary>
    /// Consecutive characters encountered
    /// </summary>
    ConsecutiveCharacters = 2,
    /// <summary>
    /// Repeated characters encountered
    /// </summary>
    RepeatedCharacters = 3,
    /// <summary>
    /// Predefined suspicious words encountered
    /// </summary>
    PredefinedSuspiciousWords = 4,
    /// <summary>
    /// Suspicious names encountered
    /// </summary>
    SuspiciousNamesList = 5,
    /// <summary>
    /// Okey-dokey
    /// </summary>
    Ok = 200
}