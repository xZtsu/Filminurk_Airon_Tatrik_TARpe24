using Filminurk.Core.Dto.OMDbDTOs;
using Filminurk.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Filminurk.ApplicationServices.Services
{
    public class OMDbService : IOMDbServices
    {


        public async Task<OMDbApiResultDTO> OMDbApi(OMDbApiResultDTO dto)
        {
            string apikey = Filminurk.Data.Environment.omdbkey;
            string baseUrl = "http://www.omdbapi.com/";
            string omdbResponse = $"{baseUrl}?t={Uri.EscapeDataString(dto.Title)}&apikey={apikey}";

            OMDbApiRootDTO rootDto = new OMDbApiRootDTO();
            using (var clientOMDb = new HttpClient())
            {
                var httpResponseOMDb = await clientOMDb.GetAsync(omdbResponse);
                string jsonOMDb = await httpResponseOMDb.Content.ReadAsStringAsync();

                try
                {
                    rootDto = JsonSerializer.Deserialize<OMDbApiRootDTO>(jsonOMDb, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (rootDto.Response == "True")
                    {
                        dto.Title = rootDto.Title;
                        dto.Released = rootDto.Released;
                        dto.Director = rootDto.Director;
                        dto.Actors = rootDto.Actors;
                        dto.Plot = rootDto.Plot;
                        dto.imdbRating = rootDto.imdbRating;
                        dto.Response = rootDto.Response;
                    }
                    else
                    {
                        dto.Response = "False";
                        dto.Error = rootDto.Error;
                    }

                }
                catch (Exception ex)
                {
                    dto.Response = "False";
                    dto.Error = ex.Message;
                }
            }
            return dto;


        }
    }
}