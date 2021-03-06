﻿namespace TinaTests
{
    using System;
    using Tina;
    using TinaTests.Mocks;
    using Xunit;
    using Xunit.Extensions;

    public class TinaTestFixture
    {
        [Fact]
        public void An_Extension_Is_Registered_If_Handle_Is_Found()
        {
            Tina tina = new Tina();
            tina.Register<MockTemplate>(".mock");
            Assert.True(tina.IsRegistered("mock"));
        }

        [Fact]
        public void Can_Register_Handle_If_Template_Extension_Attribute_Is_Found()
        {
            var tina = new Tina();
            tina.Register<AttributedTemplate>();
            Assert.True(tina.IsRegistered(".attribute"));
        }

        [Fact]
        public void Can_Look_Up_Template_Class_By_Extension()
        {
            Tina tina = new Tina();
            tina.Register<MockTemplate>("mock");
            var impl = tina.GetTemplateType("mock");
            Assert.Equal(typeof(MockTemplate), impl);
        }

        [Fact]
        public void Can_Look_Up_Template_Class_By_Implicit_Extension()
        {
            var tina = new Tina();
            tina.Register<MockTemplate>("mock");

            var impl = tina.GetTemplateType(".mock");

            Assert.Equal(typeof(MockTemplate), impl);
        }

        [Fact]
        public void Can_Look_Up_Template_By_Multiple_Extensions()
        {
            var tina = new Tina();
            tina.Register<MockTemplate>("mock");
            var impl = tina.GetTemplateType("index.html.mock");
            Assert.Equal(typeof(MockTemplate), impl);
        }

        [Fact]
        public void Can_Look_Up_Template_Class_By_File_Name()
        {
            var tina = new Tina();
            tina.Register<MockTemplate>(".mock");
            var impl = tina.GetTemplateType(@"c:\\test\test\test.mock");
            Assert.NotNull(impl);
            Assert.Equal(typeof(MockTemplate), impl);   
        }

        [Fact]
        public void NonExistant_Extension_Returns_Null()
        {
            var tina = new Tina();
            Assert.Null(tina.GetTemplateType("mock"));
        }

        [Fact]
        public void Can_Look_Up_Template_Class_By_Item_Property()
        {
            var tina = new Tina();
            tina.Register<MockTemplate>("mock");
            var impl = tina[".mock"];
            Assert.NotNull(impl);
            Assert.Equal(typeof(MockTemplate), impl);
        }
    }
}
