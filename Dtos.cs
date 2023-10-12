namespace CarsApi
{
    public record CarDto(Guid Id, string Name, string Description, DateTime CreatedTime);
    public record CreatedCarDto(string Name, string Description);
    public record UpdateCarDto(string Name, string Description);
}