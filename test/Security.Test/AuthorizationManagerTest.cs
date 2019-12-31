using Security;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace SecurityTest
{
    public class AuthorizationManagerTest{
        AuthorizationManager authorizationManager;
        Mock<AuthorizationManager> mockAuthorizationManager;
        Role userRole;
        List<Role> anyRoles;

        [SetUp]
        public void Setup(){
            mockAuthorizationManager = new Mock<AuthorizationManager>();
            userRole = new Mock<Role>().Object;
            anyRoles = new List<Role>();

            mockAuthorizationManager.Setup(authorizationManager => authorizationManager.IsAuthenticated()).Returns(true);
            mockAuthorizationManager.Setup(authorizationManager => authorizationManager.HasRole(userRole)).Returns(true);
            mockAuthorizationManager.Setup(authorizationManager => authorizationManager.HasAnyRole(anyRoles)).Returns(true);
            mockAuthorizationManager.Setup(authorizationManager => authorizationManager.HasRoles(anyRoles)).Returns(true);
            authorizationManager = mockAuthorizationManager.Object;
        }

        [Test]
        public void IsAuthenticatedMethodShouldReturnValue(){
            Assert.That(authorizationManager.IsAuthenticated(), Is.EqualTo(true));
        }

        [Test]
        public void HasRoleMethodShouldReturnValue(){
            Assert.That(authorizationManager.HasRole(userRole), Is.EqualTo(true));
            mockAuthorizationManager.Verify(authorizationManager => authorizationManager.HasRole(It.IsAny<Role>()));
        }

        [Test]
        public void HasAnyRoleMethodShouldReturnValue(){
            Assert.That(authorizationManager.HasAnyRole(anyRoles), Is.EqualTo(true));
            mockAuthorizationManager.Verify(authorizationManager => authorizationManager.HasAnyRole(It.IsAny<List<Role>>()));
        }

        [Test]
        public void HasRolesMethodShouldReturnValue(){
            Assert.That(authorizationManager.HasRoles(anyRoles), Is.EqualTo(true));
            mockAuthorizationManager.Verify(authorizationManager => authorizationManager.HasRoles(It.IsAny<List<Role>>()));
        }
    }
}