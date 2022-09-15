namespace Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

using Defender.MarkII.BeneficiaryNameValidationSvc.Model;

public class FrontEndValidationSvc : IFrontEndValidation
{
    IEnumerable<INameValidationSvc> _validationServices;

    public FrontEndValidationSvc(IEnumerable<INameValidationSvc> validationServices)
    {
        _validationServices = validationServices;
    }

    #region IFrontEndValidation members

    public EvaluationResult Validate(string Name)
    {
        throw new NotImplementedException();
    }

    #endregion

}