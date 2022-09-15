namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

/// <summary>
/// Blueprint for all validation strategies
/// </summary>
public interface INameValidationSvc
{
    /// <summary>
    /// The <see cref="ValidationResult"> when validation has been performed.
    /// </summary>
    EvaluationResult? Result { get; }

    /// <summary>
    /// Performs validation against the provided name.
    /// </summary>
    /// <param name="Name">The name to validate</param>
    /// <returns>An empty task.</returns>
    Task Validate(string Name);
}