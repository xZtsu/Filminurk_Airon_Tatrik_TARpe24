using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.ServiceInterface
{
    public interface IActorServices // see on interface. asub .core/serviceinterface
    {
        Task<Actors> Create(ActorsDTO dto);
        Task<Actors> Delete(Guid id);
        Task<Actors> DetailsAsync(Guid id);
        Task<Actors> Update(MoviesDTO dto);

    }
}
