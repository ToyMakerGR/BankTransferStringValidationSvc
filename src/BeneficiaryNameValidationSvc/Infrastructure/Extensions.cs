namespace Defender.MarkII.BeneficiaryNameValidationSvc.Infrastructure;

using System.Reflection;
using Defender.MarkII.BeneficiaryNameValidationSvc.Constants;
using Defender.MarkII.BeneficiaryNameValidationSvc.Model;
using Defender.MarkII.BeneficiaryNameValidationSvc.ValidationServices;

public static class Extensions
{
    public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
        foreach (var type in typesFromAssemblies)
        {
            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }
    }

    public static void RegisterValidationEndpoint(this WebApplication app)
    {
        app.MapPost("/api/BankTransfers/Validation", (string stringOfInterest, ValidationScope scope, IValidationSvc validationSvc) =>
        {
            return validationSvc.Validate(stringOfInterest, scope);
        })
        .Produces<EvaluationResult>(StatusCodes.Status200OK)
        .WithName("ValidateBankTransferString");
    }
}