using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tina;

namespace TinaTests.Mocks
{
    public class MockImplTemplate : Template
    {
        public MockImplTemplate(string val) : base(val)
        {
        }

        public MockImplTemplate(string file, int line) : base(file, line)
        {

        }
    }
}
