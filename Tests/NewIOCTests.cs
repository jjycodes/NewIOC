using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Business.Interfaces;
using NewIOC;
using NewIOC.Models;
using Xunit;

namespace Tests
{
    public class NewIOCTests
    {
        [Fact]
        public void GivenContainer_WhenNotRegistered_ThenShouldThrowException()
        {
            IContainer container = new Container();
            
            Assert.Throws<ImplementationNotFoundException>(() => container.Resolve<IEmailService>());
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

        [Fact]
        public void GivenContainer_WhenIRegisterTypeWithNoConstructor_ThenShouldResolveObject()
        {
            IContainer container = new Container();

            container.Register<IEmailService, EmailService>();

            var emailService = container.Resolve<IEmailService>();

            Assert.NotNull(emailService);
            Assert.IsType<EmailService>(emailService);
        }

        [Fact]
        public void GivenContainer_WhenIRegisterType_ThenShouldResolveTransientByDefault()
        {
            IContainer container = new Container();
            container.Register<ICalculator, Calculator>();

            var calculator = container.Resolve<ICalculator>();
            Assert.NotSame(container.Resolve<ICalculator>(), calculator);
        }

        [Fact]
        public void GivenContainer_WhenIRegisterTypeAsSingleton_ThenShouldResolveToTheSameInstance()
        {
            IContainer container = new Container(new SingletonLifeCycleService());
            container.Register<ICalculator, Calculator>();

            var calculator = container.Resolve<ICalculator>();
            Assert.Same(container.Resolve<ICalculator>(), calculator);
        }

        [Fact]
        public void GivenContainer_WhenIRegisterNestedType_ButMissingDependenciesRegistration_ThenShouldThrowException()
        {
            IContainer container = new Container();
            container.Register<IUsersController, UsersController>();
            
            Assert.Throws<ImplementationNotFoundException>(() => container.Resolve<IUsersController>());
        }

        [Fact]
        public void GivenContainer_WhenIRegisterNestedType_ThenShouldResolveObjectAndDependencies()
        {
            IContainer container = new Container();
            container.Register<IEmailService, EmailService>();
            container.Register<ICalculator, Calculator>();
            container.Register<IUsersController, UsersController>();

            var usersController = container.Resolve<IUsersController>();
            Assert.NotNull(usersController);
            Assert.NotNull(usersController.EmailService);
            Assert.NotNull(usersController.Calculator);

            Assert.IsType<UsersController>(usersController);
            Assert.IsType<EmailService>(usersController.EmailService);
            Assert.IsType<Calculator>(usersController.Calculator);
        }

        [Fact]
        public void GivenContainer_WhenIRegisterThreeLevelNestedType_ThenShouldResolveObjectAndDependencies()
        {
            IContainer container = new Container();
            container.Register<IEmailService, EmailService>();
            container.Register<ICalculator, Calculator>();
            container.Register<IUsersController, UsersController>();
            container.Register<ICyclesBusinessLogic, CyclesBusinessLogic>();

            var cyclesBL = container.Resolve<ICyclesBusinessLogic>();
            Assert.NotNull(cyclesBL);
            Assert.NotNull(cyclesBL.UsersController);
            Assert.NotNull(cyclesBL.UsersController.EmailService);
            Assert.NotNull(cyclesBL.UsersController.Calculator);

            Assert.IsType<CyclesBusinessLogic>(cyclesBL);
            Assert.IsType<UsersController>(cyclesBL.UsersController);
            Assert.IsType<EmailService>(cyclesBL.UsersController.EmailService);
            Assert.IsType<Calculator>(cyclesBL.UsersController.Calculator);
        }
    }
}
