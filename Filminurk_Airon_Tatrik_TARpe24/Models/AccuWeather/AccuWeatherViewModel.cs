namespace Filminurk.Models.AccuWeather
{
    public class AccuWeatherViewModel
    {
        public string CityName { get; set; } = string.Empty;
        //public string CityCode { get; set; } = string.Empty;
        public string EffectiveDate { get; set; } = string.Empty;
        public long EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public long EndEpochDate { get; set; }
        public string DailyForecastsDate { get; set; } = string.Empty;
        public int DailyForecastsEpoctDate { get; set; }
        public double TempMinValue { get; set; }
        public string TempMinUnit { get; set; } = string.Empty;
        public int TempMinUnitType { get; set; }
        public double TempMaxValue { get; set; }
        public string TempMaxUnit { get; set; } = string.Empty;
        public int TempMaxUnitType { get; set; }
        public int DayIcon { get; set; }
        public string DayIconPhrase { get; set; } = string.Empty;
        public bool DayHasPrescripitation { get; set; }
        public string DayPrescipitationType { get; set; } = string.Empty;
        public string DayPrescipitationIntensity { get; set; } = string.Empty;
        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; } = string.Empty;
        public bool NightHasPrescripitation { get; set; }
        public string NightPrescipitationType { get; set; } = string.Empty;
        public string NightPrescipitationIntensity { get; set; } = string.Empty;
        public string MobileLink { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
    }
}
