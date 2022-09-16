namespace Defender.MarkII.BankTransferStringValidationSvc.Infrastructure;

using System.Globalization;
using System.Reflection;
using System.Text;
using Defender.MarkII.BankTransferStringValidationSvc.Constants;
using Defender.MarkII.BankTransferStringValidationSvc.Model;
using Defender.MarkII.BankTransferStringValidationSvc.Services;

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

    public static string RemoveDiacritics(this string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}