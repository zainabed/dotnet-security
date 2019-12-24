using NUnit.Framework;
using Moq;
using Security;

namespace SecurityTest
{
    public class RoleTest
    {
        Role role;

        Mock<Role> mockRole;

        string testRoleValue;
        string testRoleTitle;

        [SetUp]
        public void Setup()
        {
            testRoleValue = "test";
            testRoleTitle = "test";
            mockRole = new Mock<Role>();
            mockRole.Setup(role => role.GetValue()).Returns(testRoleValue);
            mockRole.Setup(role => role.GetTitle()).Returns(testRoleTitle);

            role = mockRole.Object;
        }

        [TearDown]
        public void TearDown()
        {
            role = null;
            mockRole = null;
        }

        [Test]
        public void ShouldReturnRoleValue()
        {
            var roleValue = role.GetValue();
            Assert.That(roleValue, Is.EqualTo(testRoleValue));
        }

        [Test]
        public void ShouldReturnRoleTitle()
        {
            var roleTitle = role.GetTitle();
            Assert.That(roleTitle, Is.EqualTo(testRoleTitle));
        }
    }
}