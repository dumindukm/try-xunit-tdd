using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using PractitionerCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using try_xunit_tdd.Controllers;

namespace XunitTestProject
{
    public class PractitionerControllerTest
    {
        private Mock<HttpMessageHandler>? _msgHandler;
        private string _response = "verified";
        public PractitionerControllerTest()
        {
            _msgHandler = new Mock<HttpMessageHandler>();

            

        }
        // https://code-maze.com/unit-testing-aspnetcore-web-api/
        [Fact]
        [Trait("Practitoner", "WebApi")]
        public void ShouldReturnOk_ForPractitonerExists()
        {
            var mock = new Mock<IPractitionerService>();

            var practitionerController = new PractitionerController(mock.Object, null);

            var result = practitionerController.GetPractioner(2);


            var okResult = result as OkObjectResult;

            Assert.True(okResult != null);
            Assert.True(okResult.Value != null);
        }


        [Fact]
        [Trait("Practitoner", "WebApi")]
        public void ShouldReturnId_AfterCreateNewPractitoiner()
        {
            var mock = new Mock<IPractitionerService>();
            mock.Setup(p => p.CreatePractitioner(It.IsAny<Practitioner>())).Returns(1);
            var practitionerController = new PractitionerController(mock.Object,null);

            var practitionerRequest = new PractitionerRequest()
            {
                FirstName = "f",
                Email = "test@email.com",
                LastName = "last"
            };

            var result = practitionerController.CreatePractioner(practitionerRequest);


            var okResult = result as OkObjectResult;

            Assert.True(okResult != null);
            Assert.Equal(okResult.Value.ToString(), "1");
        }

        [Fact]
        [Trait("Practitoner", "WebApi")]
        public async Task ShouldReturnTrue_AfterVerifyCredentials()
        {
            //https://code-maze.com/csharp-mock-httpclient-with-unit-tests/
            var mockedProtected = _msgHandler.Protected();

            var setupApiRequest = mockedProtected.Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
                );

            var apiMockedResponse =
                setupApiRequest.ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(_response)
                });

            apiMockedResponse.Verifiable();

            var mock = new Mock<IPractitionerService>();
            mock.Setup(p => p.CreatePractitioner(It.IsAny<Practitioner>())).Returns(1);

            var httpClient = new HttpClient(_msgHandler.Object);

            var practitionerController = new PractitionerController(mock.Object, httpClient);

            var result = await practitionerController.VerifyPractioner(1);
            _msgHandler.VerifyAll();
            var okResult = result as OkObjectResult;
            Assert.Equal("verified", okResult.Value.ToString() );
        }


    }
}
