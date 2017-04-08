using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected questions";
            var expectedQuestionnaire = new Questionnaire() { QuestionnaireTitle = expectedTitle };
            var fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = expectedQuestionnaire };
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void ShouldGetNoQuestions()
        {
            //Arrange
            var expectedQuestions = new Questionnaire();
            var fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = expectedQuestions };
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionsText, Is.Null);
        }

        [Test]
        public void ShouldGetQuestion()
        {
            //Arrange
            var expectedQuestion = "What is the capital of Cuba?";
            List<string> questionsList = new List<string>();
            questionsList.Add(expectedQuestion);

            var expectedQuestions = new Questionnaire() { QuestionsText = questionsList };
            var fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = expectedQuestions };
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionsText, Is.Not.Null);
        }

        [Test]
        public void ShouldGetQuestionDetail()
        {
            //Arrange
            var expectedQuestion = "What is the capital of Cuba?";
            List<string> questionsList = new List<string>();
            questionsList.Add(expectedQuestion);

            var expectedQuestions = new Questionnaire() { QuestionsText = questionsList };
            var fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = expectedQuestions };
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionsText[0].ToString(), Is.EqualTo(expectedQuestion));
        }

        [Test]
        public void ShouldGetQuestionCount()
        {
            //Arrange
            var firstQuestion = "What is the capital of Cuba?";
            var secondQuestion = "What is the capital of France?";
            var thirdQuestion = "What is the capital of Poland?";

            List<string> questionsList = new List<string>();
            questionsList.Add(firstQuestion);
            questionsList.Add(secondQuestion);
            questionsList.Add(thirdQuestion);

            var expectedQuestions = new Questionnaire() { QuestionsText = questionsList };
            var fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = expectedQuestions };
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionsText.Count(), Is.EqualTo(3));
        }
    }
}