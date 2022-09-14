using System;

namespace BeneficiaryNameValidationSvc;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureCC { get; set; }

    public int TemperatureFF => 32 + (int)(TemperatureCC / 0.5556);

    public string? Summary { get; set; }
}
