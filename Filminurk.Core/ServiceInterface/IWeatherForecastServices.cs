using Filminurk.Core.Dto.AccuWeatherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        //method
        public Task<AccuLocationWeatherResultDTO> AccuWeatherResult(AccuLocationWeatherResultDTO dto);
        
        
            
        
    }
}
