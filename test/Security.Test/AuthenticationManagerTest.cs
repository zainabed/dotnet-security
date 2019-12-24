using Moq;
using NUnit.Framework;
using Security;

namespace SecurityTest
{
    public class AuthenticationManagerTest
    {

        AuthenticationManager authenticationManager;
        Principle principle;
        Mock<AuthenticationManager> mockAutheticationManager;

        [SetUp]
        public void Setup()
        {
            var mockPrinciple = new Mock<Principle>();
            principle = mockPrinciple.Object;

            mockAutheticationManager = new Mock<AuthenticationManager>();
            mockAutheticationManager.Setup(auth => auth.GetPrinciple()).Returns(principle);
            authenticationManager = mockAutheticationManager.Object;
        }

        [TearDown]
        public void TearDown()
        {
            principle = null;
            mockAutheticationManager = null;
            authenticationManager = null;
        }

        [Test]
        public void shouldReturnPricelInterface()
        {
            var principle = authenticationManager.GetPrinciple();
            Assert.That(principle, Is.Not.Null);
        }

        [Test]
        public void shouldCallMethodWithPrincipleAsParameter()
        {
            authenticationManager.SetPrinciple(principle);
            mockAutheticationManager.Verify(authenticationManager => authenticationManager.SetPrinciple(It.IsAny<Principle>()));
        }

        [Test]
        public void shouldCallResetMethod()
        {
            authenticationManager.Reset();
            mockAutheticationManager.Verify(authenticationManager => authenticationManager.Reset(), Times.Once());
        }
    }
}