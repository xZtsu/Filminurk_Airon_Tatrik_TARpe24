using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.ServiceInterface
{
    public interface IUserCommentsServices
    {
        Task<UserComment> NewComment(UserCommentDTO userCommentDTO);
        Task<UserComment> DetailAsync(Guid id);
        Task<UserComment> Delete(Guid id);
    }
}
