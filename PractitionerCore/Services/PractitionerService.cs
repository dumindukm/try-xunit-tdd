using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractitionerCore.Services
{
    public class PractitionerService : IPractitionerService
    {
        //private readonly HttpClient httpClient;

        //public PractitionerService(HttpClient httpClient)
        //{
        //    this.httpClient = httpClient;
        //}

        
        
        public int CreatePractitioner(Practitioner practitioner)
        {
            return 1;
        }

        public async Task<bool> VerifyPractitonerCredentials(Practitioner practitioner)
        {
            //HttpRequestMessage message = new HttpRequestMessage();
            //message.Method = HttpMethod.Get;
            //message.RequestUri = new Uri("");
            //var result = await this.httpClient.SendAsync(message);
            return true;
        }
    }
}
