using Filminurk.Core.Dto.OMDbDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.ServiceInterface
{
    public interface IOMDbServices
    {
        Task<OMDbApiResultDTO> OMDbApi(OMDbApiResultDTO dto);
    }
}