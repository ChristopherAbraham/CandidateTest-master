using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using System;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ReturnViewModel()
        {
            //Arrange
            var questionnaireController = new QuestionnaireController();

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.ViewData.Model;

            //Assert
            Assert.That(questionnaireController, Is.Not.Null);
        }
    }
}