using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerDistributionSystem.Domain.Enums;
using PowerDistributionSystem.Domain.ValueObjects;
using PowerDistributionSystem.Domain.Helper;

namespace PowerDistributionSystem.Domain.Entities;

public class Pole
{
    // Just for EF
    public Pole()
    {
        // to avoid warring Non-nullable
        Coordinates = new GeoCoordinate(0,0);
        Serial_No = "";
        Company_Constructor = "";
    }

    // Main constructor
    public Pole(
        Height_Pole height,
        Type_Pole material,
        int yearInstallation,
        int yearMade,
        Power_Tension_Pole powerTension,
        DateTime lastDateInspect,
        GeoCoordinate coordinates, //Value Object
        int weight,
        string serialNo,
        string companyConstructor)
    {
        GeoValidator.ValidateCoordinates(coordinates.Latitude, coordinates.Longitude);
        Height = height;
        Material = material;
        Year_Installation = yearInstallation;
        Year_Made = yearMade;
        Power_Tension = powerTension;
        Last_Date_Inspect = lastDateInspect;
        Coordinates = coordinates;
        Weight = weight;
        Serial_No = serialNo ?? throw new ArgumentNullException(nameof(serialNo));
        Company_Constructor = companyConstructor ?? throw new ArgumentNullException(nameof(companyConstructor));
    }

    // Public properties with private setters
    public int Id { get; private set; }
    public Height_Pole Height { get; private set; }
    public Type_Pole Material { get; private set; }
    public int Year_Installation { get; private set; }
    public int Year_Made { get; private set; }
    public Power_Tension_Pole Power_Tension { get; private set; }
    public DateTime Last_Date_Inspect { get; private set; }
    public GeoCoordinate Coordinates { get; private set; } //Value Object
    public int Weight { get; private set; }
    public string Serial_No { get; private set; }
    public string Company_Constructor { get; private set; }

    // Domain methods
    public void ChangeHeight(Height_Pole newHeight)
    {
        if (newHeight == Height_Pole.SixAndHalfMeters && Material == Type_Pole.Wooden)
        {
            throw new InvalidOperationException("Wooden poles cannot be 6.5 meters tall.");
        }

        Height = newHeight;
    }

    public void ChangeMaterial(Type_Pole newMaterial)
    {
        if (newMaterial == Type_Pole.Wooden && Power_Tension == Power_Tension_Pole.ThirtyKN)
        {
            throw new InvalidOperationException("Wooden poles cannot support 30 NK tension.");
        }

        Material = newMaterial;
    }

    public void ChangePowerTension(Power_Tension_Pole newPowerTension)
    {
        if (newPowerTension == Power_Tension_Pole.ThirtyKN && Material == Type_Pole.Wooden)
        {
            throw new InvalidOperationException("Wooden poles cannot support 30 NK tension.");
        }

        Power_Tension = newPowerTension;
    }

    public void UpdateCoordinates(decimal latitude, decimal longitude)
    {
        Coordinates = new GeoCoordinate(latitude, longitude);
    }
}
