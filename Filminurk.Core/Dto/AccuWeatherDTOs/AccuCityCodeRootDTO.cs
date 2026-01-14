using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Dto.AccuWeatherDTOs
{
    public class AccuCityCodeRootDTO
    {
        public int Version { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Type {  get; set; } = string.Empty;
        public int Rank { get; set; }
        public string LocalizedName {  get; set; } = string.Empty;
        public string EnglishName {  get; set; } = string.Empty;
        public string PrimaryPostalCode {  get; set; } = string.Empty;
        public Region? Region { get; set; }
        public Country? Country { get; set; }
        public AdministrativeArea? AdministrativeArea { get; set; }
        public TimeZone? TimeZone { get; set; }
        public Geoposition? Geoposition { get; set; }
        public bool IsAlias { get; set; }
        public SupplementalAdminArea[]? SupplementalAdminAreas { get; set; }
        public string[]? DataSets { get; set; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
       


    }
    public class Region
    {
        public string Id { get; set; } = string.Empty ;
        public string LoacalizedName { get; set; } = string.Empty ;
        public string EnglishName { get; set; } = string.Empty ;
    }
    public class Country
    {
        public string Id { get; set; } = string.Empty ;
        public string LoacalizedName { get; set; } = string.Empty ;
        public string EnglishName { get; set; } = string.Empty ;
    }
    public class AdministrativeArea
    {
        public string Id { get; set; } = string.Empty ;
        public string LoacalizedName { get; set; } = string.Empty ;
        public string EnglishName { get; set; } = string.Empty ;
        public int Level { get; set; }
        public string LocalizedType {  get; set; } = string.Empty ;
        public string EnglishType {  get; set; } = string.Empty ;
        public string CountryId {  get; set; } = string.Empty ;
    }
    public class TimeZone
    {
        public string Code {  get; set; } = string.Empty ;
        public string Name {  get; set; } = string.Empty ;
        public int GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public DateTime NextOffsetChange { get; set; }
    }

    public class Geoposition
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public Elevation? Elevation { get; set; }
    }
    public class Elevation
    {
        public Metric? Metric{ get; set; }
        public Imperial? Imperial{ get; set; }
    }
    public class Metric
    {
        public double Value{ get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }
    public class Imperial
    {
        public double Value{ get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }
    public  class SupplementalAdminArea
    {
        public int Level { get; set; }
        public string LocalizedName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
    }
    public class AirAndPollen
    {
    }

    public class Average
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

    public class Cooling
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }





    public class DegreeDaySummary
    {
        public Heating Heating { get; set; }
        public Cooling Cooling { get; set; }
    }

    public class Direction
    {
        public int Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }

    public class Evapotranspiration
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

  

    public class Heating
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

    public class HoursOfIce
    {
    }

    public class HoursOfPrecipitation
    {
    }

    public class HoursOfRain
    {
    }

    public class HoursOfSnow
    {
    }

    public class HoursOfSun
    {
    }

    public class Ice
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

    public class IceProbability
    {
    }

    public class LongPhrase
    {
    }




    public class Moon
    {
        public DateTime Rise { get; set; }
        public int EpochRise { get; set; }
        public DateTime Set { get; set; }
        public int EpochSet { get; set; }
        public string Phase { get; set; }
        public int Age { get; set; }
    }

   

    public class PrecipitationIntensity
    {
    }

    public class PrecipitationProbability
    {
    }

    public class Rain
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

    public class RainProbability
    {
    }

    public class RealFeelTemperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    public class RealFeelTemperatureShade
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    public class RelativeHumidity
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Average { get; set; }
    }

    public class Root
    {
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    public class ShortPhrase
    {
    }

    public class Snow
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

    public class SnowProbability
    {
    }

    public class SolarIrradiance
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

    public class Speed
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

    public class Sun
    {
        public DateTime Rise { get; set; }
        public int EpochRise { get; set; }
        public DateTime Set { get; set; }
        public int EpochSet { get; set; }
    }



    public class ThunderstormProbability
    {
    }

    public class TotalLiquid
    {
        public int UnitType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }

    public class UVIndexFloat
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    public class WetBulbGlobeTemperature
    {
        public Average Average { get; set; }
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    public class WetBulbTemperature
    {
        public Average Average { get; set; }
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    public class Wind
    {
        public Speed Speed { get; set; }
        public Direction Direction { get; set; }
    }

    public class WindGust
    {
        public Speed Speed { get; set; }
        public Direction Direction { get; set; }
    }
}
