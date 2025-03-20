using System;
using Shouldly;
using Xunit;
using PowerDistributionSystem.Domain.Entities;
using PowerDistributionSystem.Domain.Enums;
using PowerDistributionSystem.Domain.ValueObjects;

namespace PowerDistributionSystem.Domain.Tests;

public class PoleTests
{
    [Fact]
    public void Pole_Should_Be_Created_With_Valid_Properties()
    {
        // Arrange
        var coordinates = new GeoCoordinate(-36.52345678m, 174.98765432m);
        var pole = new Pole(
            Height_Pole.NineAndHalfMeters,
            Type_Pole.Concrete,
            2020,
            2019,
            Power_Tension_Pole.TwentyKN,
            new DateTime(2023, 10, 1),
            coordinates,
            150,
            "SN123456789",
            "ABC Constructors"
        );

        // Assert
        pole.Height.ShouldBe(Height_Pole.NineAndHalfMeters);
        pole.Material.ShouldBe(Type_Pole.Concrete);
        pole.Year_Installation.ShouldBe(2020);
        pole.Year_Made.ShouldBe(2019);
        pole.Power_Tension.ShouldBe(Power_Tension_Pole.TwentyKN);
        pole.Last_Date_Inspect.ShouldBe(new DateTime(2023, 10, 1));
        pole.Coordinates.ShouldBe(coordinates);
        pole.Weight.ShouldBe(150);
        pole.Serial_No.ShouldBe("SN123456789");
        pole.Company_Constructor.ShouldBe("ABC Constructors");
    }

    [Fact]
    public void Pole_Should_Throw_Exception_For_Null_SerialNo()
    {
        // Arrange
        var coordinates = new GeoCoordinate(-36.678m, 174.5432m);

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => new Pole(
            Height_Pole.NineAndHalfMeters,
            Type_Pole.Concrete,
            2020,
            2019,
            Power_Tension_Pole.TwentyKN,
            new DateTime(2023, 10, 1),
            coordinates,
            150,
            null, // Serial_No is null
            "ABC Constructors"
        ));
    }

    [Fact]
    public void Pole_Should_Throw_Exception_For_Null_CompanyConstructor()
    {
        // Arrange
        var coordinates = new GeoCoordinate(-36.82345678m, 174.98765432m);

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => new Pole(
            Height_Pole.NineAndHalfMeters,
            Type_Pole.Concrete,
            2020,
            2019,
            Power_Tension_Pole.TwentyKN,
            new DateTime(2023, 10, 1),
            coordinates,
            150,
            "SN123456789",
            null // Company_Constructor is null
        ));
    }

    [Fact]
    public void Pole_Should_Change_Height()
    {
        // Arrange
        var coordinates = new GeoCoordinate(-36.6345678m, 174.98765432m);
        var pole = new Pole(
            Height_Pole.NineAndHalfMeters,
            Type_Pole.Concrete,
            2020,
            2019,
            Power_Tension_Pole.TwentyKN,
            new DateTime(2023, 10, 1),
            coordinates,
            150,
            "SN123456789",
            "ABC Constructors"
        );

        // Act
        pole.ChangeHeight(Height_Pole.ElevenAndHalfMeters);

        // Assert
        pole.Height.ShouldBe(Height_Pole.ElevenAndHalfMeters);
    }

    [Fact]
    public void Pole_Should_Throw_When_Changing_Height_For_Wooden_Pole()
    {
        // Arrange
        var coordinates = new GeoCoordinate(-36.78m, 175.2m);
        var pole = new Pole(
            Height_Pole.NineAndHalfMeters,
            Type_Pole.Wooden,
            2020,
            2019,
            Power_Tension_Pole.TwentyKN,
            new DateTime(2023, 10, 1),
            coordinates,
            150,
            "SN123456789",
            "ABC Constructors"
        );

        // Act & Assert
        Should.Throw<InvalidOperationException>(() => pole.ChangeHeight(Height_Pole.SixAndHalfMeters));
    }

    [Fact]
    public void Pole_Should_Update_Coordinates()
    {
        // Arrange
        var coordinates = new GeoCoordinate(-36.7345678m, 175.28765432m);
        var pole = new Pole(
            Height_Pole.NineAndHalfMeters,
            Type_Pole.Concrete,
            2020,
            2019,
            Power_Tension_Pole.TwentyKN,
            new DateTime(2023, 10, 1),
            coordinates,
            150,
            "SN123456789",
            "ABC Constructors"
        );

        var newCoordinates = new GeoCoordinate(37.654321m, 52.123456m);

        // Act
        pole.UpdateCoordinates(newCoordinates.Latitude, newCoordinates.Longitude);

        // Assert
        pole.Coordinates.ShouldBe(newCoordinates);
    }
}