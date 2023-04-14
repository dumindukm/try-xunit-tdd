using Microsoft.AspNetCore.Mvc;
using PractitionerCore;
using PractitionerCore.Services;
using XunitTestProject;

namespace try_xunit_tdd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerController : ControllerBase
    {
        private readonly IPractitionerService _practitionerService;
        private readonly HttpClient _client;

        public PractitionerController(IPractitionerService practitionerService , HttpClient client)
        {
            _practitionerService = practitionerService;
            _client = client;
        }

        [HttpPost]
        public object CreatePractioner(PractitionerRequest practitionerRequest)
        {
            var id = _practitionerService.CreatePractitioner(
                Practitioner.Create(practitionerRequest.FirstName, practitionerRequest.LastName, practitionerRequest.Email));

            return Ok(id);
        }

        [HttpGet]
        public IActionResult GetPractioner(int practitonerId)
        {
            var practitoner = Practitioner.Create("d", "l", "df");
            return Ok(practitoner);
        }

        [HttpGet]
        public async Task<IActionResult> VerifyPractioner(int practitonerId)
        {
            string baseAddress = "https://reqres.in";
            string apiEndpoint = "/api/users/2";

            var responseMessage = await _client.GetAsync(baseAddress + apiEndpoint);

            var practitoner = Practitioner.Create("d", "l", "df");

            await _practitionerService.VerifyPractitonerCredentials(practitoner);
            string res = string.Empty;
            if (responseMessage.IsSuccessStatusCode)
            {
                res = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(Response);
            }

            return Ok(res);
        }

    }
}
