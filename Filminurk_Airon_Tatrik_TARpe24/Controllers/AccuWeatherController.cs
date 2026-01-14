using Filminurk.Core.Dto.AccuWeatherDTOs;
using Filminurk.Core.ServiceInterface;
using Filminurk.Models.AccuWeather;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    public class AccuWeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;
        public AccuWeatherController
            (
            IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FindWeather(AccuWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeather", new { city = model.CityName });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult City(string City)
        {
            AccuLocationWeatherResultDTO dto = new();
            dto.CityName = City;
            _weatherForecastServices.AccuWeatherResult(dto);
            AccuWeatherViewModel vm = new();
            vm.EffectiveDate = dto.EffectiveDate;
            vm.EffectiveEpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.Category = dto.Catagory;
            vm.EndDate = dto.EndDate;
            vm.EndEpochDate = dto.EndEpochDate;
            vm.DailyForecastsDate = dto.DailyForecastsDate;
            vm.DailyForecastsEpoctDate = dto.DailyForecastsEpochDate;
            vm.TempMinValue = dto.TempMinValue;
            vm.TempMinUnit = dto.TempMinUnit;
            vm.TempMinUnitType = dto.TempMinUnitType;

            vm.TempMaxValue = dto.TempMaxValue;
            vm.TempMaxUnit = dto.TempMaxUnit;
            vm.TempMaxUnitType = dto.TempMaxUnitType;

            vm.DayIcon = dto.DayIcon;
            vm.DayIconPhrase = dto.DayIconPhrase;
            vm.DayHasPrescripitation = dto.DayHasPrescripitation;
            vm.DayPrescipitationType = dto.DayPrecipitationType;
            vm.DayPrescipitationIntensity = dto.DayPrecipitationIntensity;

            vm.NightIcon = dto.NightIcon;
            vm.NightIconPhrase = dto.NightIconPhrase;
            vm.NightHasPrescripitation = dto.NightHasPrescripitation;
            vm.NightPrescipitationType = dto.NightPrecipitationType;
            vm.NightPrescipitationIntensity = dto.NightPrecipitationIntensity;

            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;
            return View(vm);
        }
    }
}
