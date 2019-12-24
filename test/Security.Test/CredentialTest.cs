using Moq;
using NUnit.Framework;
using Security;

namespace SecurityTest
{
    public class CredentialTest
    {

        Credential credential;
        Mock<Credential> mockCredential;
        string testCredentialValue;

        [SetUp]
        public void Setup()
        {
            testCredentialValue = "test";
            mockCredential = new Mock<Credential>();
            mockCredential.Setup(credential => credential.GetValue()).Returns(testCredentialValue);

            credential = mockCredential.Object;
        }

        [TearDown]
        public void TearDown()
        {
            credential = null;
            mockCredential = null;
        }

        [Test]
        public void ShouldReturnCredentialValue()
        {
            var credentialValue = credential.GetValue();
            Assert.That(credentialValue, Is.EqualTo(testCredentialValue));
        }
    }
}