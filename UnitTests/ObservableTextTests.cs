using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObservableDemo;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Utilities;

namespace ObservableDemo.Tests
{
    [TestClass()]
    public class ObservableTextTests
    {
        [TestMethod]
        public void Constructor_WhenCalled_CreatesEmptyListofObservers()
        {
            //Arrange
            var sut = new ObservableText();

            //Act
            var result = RefelectionUtilities.GetField(sut, "observers");

            //Assert
            Assert.AreEqual(0, result.CustomAttributes.Count());
        }

        [TestMethod]
        public void Notify_WhenCalled_OnNextCalled()
        {
            //Arrange
            var mockObserver = MockRepository.GenerateMock<IObserver<string>>();
            List<IObserver<string>> observerList = new List<IObserver<string>>()
            {
                mockObserver
            };
            var testString = "Test";

            //Act
            mockObserver.Expect(x => x.OnNext(Arg<string>.Is.Anything));

            var sut = new ObservableText();

            RefelectionUtilities.SetFieldValue(sut, "observers", observerList);

            sut.Notify(testString);

            //Assert
            mockObserver.VerifyAllExpectations();
        }
    }
}