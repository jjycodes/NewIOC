using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Business.Interfaces;
using NewIOC;
using Xunit;

namespace Tests
{
    public class NewIOCTests
    {
        [Fact]
        public void GivenContainer_WhenNotRegistered_ThenShouldThrowException()
        {
            IContainer container = new Container();
            
            Assert.Throws<Exception>(() => container.Resolve<IEmailService>());
        }

        [Fact]
        public void GivenContainer_WhenIRegisterTypeWithConstructor_ThenShouldResolveObject()
        {
            IContainer container = new Container();

            container.Register<ICalculator, Calculator>();

            var calculator = container.Resolve<ICalculator>();

            Assert.NotNull(calculator);
            Assert.IsType<Calculator>(calculator);
        }
    }
}
