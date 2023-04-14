using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTestProject.TestDataFixture
{
    public class TestPractitionerFixture
    {
        public Practitioner Practitioner;
        public TestPractitionerFixture()
        {
            Practitioner = Practitioner.Create("FirstName", "LastName", "test@test.com");
        }
    }
}
