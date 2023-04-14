using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractitionerCore.Services
{
    public interface IPractitionerService
    {
        int CreatePractitioner(Practitioner practitioner);
        Task<bool> VerifyPractitonerCredentials(Practitioner practitioner);
        
    }
}
