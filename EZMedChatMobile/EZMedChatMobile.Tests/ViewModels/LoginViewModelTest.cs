using EZMedChatMobile.ViewModels;
using NUnit.Framework;
using Moq;
using EZMedChatMobile.Services;

namespace EZMedChatMobile.Tests.ViewModels
{
    [TestFixture]
    public class LoginViewModelTest
    {
        LoginViewModel _vm;

        [SetUp]
        public void Setup()
        {
            var apiMock = new Mock<IMedChatDataService>().Object;
            _vm = new LoginViewModel(apiMock);
        }

        [Test]
        public void Login__ParameterNotProvided_ThrowsUsernameNotProvidedException()
        {
            //Assert.Throws(typeof(UserNameNotProvidedException), () => _vm.init());
        }
    }
}
