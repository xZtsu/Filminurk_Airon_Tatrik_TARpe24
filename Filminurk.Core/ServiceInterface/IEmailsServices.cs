using Filminurk.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.ServiceInterface
{
    public interface IEmailsServices
    {
        void SendEmail(EmailDTO dTO);
        //HOMEWORK LOCATION
    }
}
