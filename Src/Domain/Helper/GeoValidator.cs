namespace PowerDistributionSystem.Domain.Helper;

public static class GeoValidator
{
    public const decimal MinLatitude = (decimal)-37.00;
    public const decimal MaxLatitude = -36.50m;
    public const decimal MinLongitude = 174.50m;
    public const decimal MaxLongitude = 175.3m;

    public static void ValidateCoordinates(decimal latitude, decimal longitude)
    {
        if (latitude < MinLatitude || latitude > MaxLatitude)
        {
            throw new ArgumentOutOfRangeException(nameof(latitude), $"Latitude must be between {MinLatitude} and {MaxLatitude}.");
        }

        if (longitude < MinLongitude || longitude > MaxLongitude)
        {
            throw new ArgumentOutOfRangeException(nameof(longitude), $"Longitude must be between {MinLongitude} and {MaxLongitude}.");
        }
    }
}
