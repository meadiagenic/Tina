using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using TinaTests.Mocks;

namespace TinaTests
{

    public class TinaTemplateTestFixture
    {
        [Fact]
        public void Ctor_With_Null_Throws_Argument_NullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var impl = new MockImplTemplate(null);
            });
        }

        [Fact]
        public void Can_Create_Template_With_A_FileName()
        {
            var inst = new MockImplTemplate("foo.mock");
            Assert.Equal("foo.mock", inst.File);
        }

        [Fact]
        public void Can_Create_Template_With_A_FileName_And_LineNumber()
        {
            var inst = new MockImplTemplate("foo.mock", 55);
            Assert.Equal("foo.mock", inst.File);
            Assert.Equal(55, inst.Line);
        }
    }
}
