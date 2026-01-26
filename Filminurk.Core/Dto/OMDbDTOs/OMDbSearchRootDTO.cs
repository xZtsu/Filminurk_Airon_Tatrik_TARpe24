using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Dto.OMDbDTOs
{
    public class OMDbSearchRootDTO
    {
        public List<OMDbSearchResultDTO> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
        public string Error { get; set; }
    }
}