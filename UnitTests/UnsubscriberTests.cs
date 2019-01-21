using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObservableDemo;
using Rhino.Mocks;

namespace UnitTests
{
    [TestClass]
    public class UnsubscriberTests
    {
        [TestMethod]
        public void Constructor_WhenCalled_CreatesInstanceOfClass()
        {
            //Arrange
            var mockObserver = MockRepository.GenerateMock<IObserver<string>>();
            List<IObserver<string>> observerList = new List<IObserver<string>>()
            {
                mockObserver
            };

            //Act
            var sut = new Unsubscriber(observerList, mockObserver);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Unsubscriber));
        }

        [TestMethod]
        public void Dispose_WhenCalled_RemoveExecuted()
        {
            //Arrange
            var mockObserver = MockRepository.GenerateMock<IObserver<string>>();
            List<IObserver<string>> observerList = new List<IObserver<string>>()
            {
                mockObserver
            };

            //Act
            
            var sut = new Unsubscriber(observerList, mockObserver);
            sut.Dispose();

            //Assert
            Assert.AreEqual(0, observerList.Count);
        }
    }
}
