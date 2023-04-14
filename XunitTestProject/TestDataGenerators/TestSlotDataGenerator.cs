using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTestProject.TestDataGenerators
{
    public class TestSlotDataGenerator : IEnumerable<object[]>
    {


        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { DateTime.Now, "09:00", "10:00" };
            yield return new object[] { DateTime.Now, "08:00", "09:00" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
