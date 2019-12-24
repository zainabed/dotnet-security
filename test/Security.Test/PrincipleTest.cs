using Moq;
using NUnit.Framework;
using Security;
using System;
using System.Collections.Generic;

namespace SecurityTest
{

    public class PrincipleTest
    {
        Principle principle;
        Mock<Principle> mockPriciple;

        string testUsername;
        Credential testCredential;
        bool testIsActiveValue;

        List<Role> testRoles;

        [SetUp]
        public void Setup()
        {
            testUsername = "testusername";
            testCredential = new Mock<Credential>().Object;
            testIsActiveValue = true;
            testRoles = new List<Role>();
            testRoles.Add(new Mock<Role>().Object);

            mockPriciple = new Mock<Principle>();
            mockPriciple.Setup(principle => principle.GetUsername()).Returns(testUsername);
            mockPriciple.Setup(principle => principle.GetCredential()).Returns(testCredential);
            mockPriciple.Setup(principle => principle.IsActive()).Returns(testIsActiveValue);
            mockPriciple.Setup(principle => principle.GetRoles()).Returns(testRoles);

            principle = mockPriciple.Object;
        }

        [TearDown]
        public void TearDown()
        {
            mockPriciple = null;
            principle = null;
            testRoles = null;
            testCredential = null;
        }


        [Test]
        public void ShouldReturnUsername()
        {
            string username = principle.GetUsername();
            Assert.That(username, Is.EqualTo(testUsername));
        }

        [Test]
        public void ShouldReturnCredentials()
        {
            Credential credential = principle.GetCredential();
            Assert.That(credential, Is.EqualTo(testCredential));
            mockPriciple.Verify(principle => principle.GetCredential(), Times.Once);
        }

        [Test]
        public void ShouldReturnIsActiveValue()
        {
            var isActiveValue = principle.IsActive();
            Assert.That(isActiveValue, Is.EqualTo(testIsActiveValue));
            mockPriciple.Verify(principle => principle.IsActive(), Times.Once);
        }

        [Test]
        public void ShouldReturnRoles()
        {
            var roles = principle.GetRoles();
            Assert.AreEqual(roles, testRoles);
        }

    }
}