namespace XunitTestProject
{
    public class PractitionerFactoryTest
    {
        [Theory]
        [Trait("Practitoner", "factory")]
        [InlineData("FirstName", "LastName", "test@test.com")]
        public void Practiotner_Create_WithMinimalDetails(string firstname , string lastname , string email)
        {
            var practitioner = Practitioner.Create(firstname,lastname,email);

            Assert.Equal("FirstName", practitioner.FirstName);
            Assert.Equal("LastName", practitioner.LastName);
            Assert.Equal("test@test.com", practitioner.Email);
        }

    }
}