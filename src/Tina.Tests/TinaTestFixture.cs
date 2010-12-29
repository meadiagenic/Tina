namespace Tina.Tests
{
    using System;
    using TinaTests.Mocks;
    using Xunit;
    using Xunit.Extensions;

    public class TinaTestFixture
    {
        [Fact]
        public void An_Extension_Is_Registered_If_Handle_Is_Found()
        {   

            Tina.Register<MockTemplate>(".mock");
            Assert.True(Tina.IsRegistered("mock"));
        }

        [Fact]
        public void Can_Look_Up_Template_Class_By_Extension()
        {
            Tina.Register<MockTemplate>("mock");
            var impl = Tina.GetTemplateType("mock");
            Assert.Equal(typeof(MockTemplate), impl);
        }

        [Fact]
        public void Can_Look_Up_Template_Class_By_Implicit_Extension()
        {
            Tina.Register<MockTemplate>("mock");

            var impl = Tina.GetTemplateType(".mock");

            Assert.Equal(typeof(MockTemplate), impl);
        }

        [Fact]
        public void Can_Look_Up_Template_Class_By_File_Name()
        {
            Tina.Register<MockTemplate>(".mock");
            var impl = Tina.GetTemplateType(@"c:\\test\test\test.mock");
            Assert.NotNull(impl);
            Assert.Equal(typeof(MockTemplate), impl);
            
        }
    }
}
