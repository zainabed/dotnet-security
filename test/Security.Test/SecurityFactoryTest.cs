using Security;
using NUnit.Framework;
using Moq;

namespace SecurityTest
{
    public class SecurityFactoryTest{

        SecurityFactory securityFactory;
        Mock<SecurityFactory> mockSecurityFactory;
        AuthenticationManager authenticationManager;
        AuthorizationManager authorizationManager;
        

        [SetUp]
        public void Setup(){
            mockSecurityFactory = new Mock<SecurityFactory>();
            securityFactory = mockSecurityFactory.Object;
            authenticationManager =new  Mock<AuthenticationManager>().Object;
            authorizationManager = new Mock<AuthorizationManager>().Object;

            mockSecurityFactory.Setup(securityFactory => securityFactory.GetAuthenticationManager()).Returns(authenticationManager);
            mockSecurityFactory.Setup(securityFactory => securityFactory.GetAuthorizationManager()).Returns(authorizationManager);
        }

        [Test]
        public void ShouldReturnAuthenticationManagerObject(){
            Assert.That(securityFactory.GetAuthenticationManager(), Is.EqualTo(authenticationManager));
        }

        [Test]
        public void ShouldReturnAuthorizationManagerObject(){
            Assert.That(securityFactory.GetAuthorizationManager(), Is.EqualTo(authorizationManager));
        }
    }
}