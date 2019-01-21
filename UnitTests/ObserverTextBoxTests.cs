using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObservableDemo;
using Rhino.Mocks;
using UnitTests.Utilities;

namespace UnitTests
{
    [TestClass]
    public class ObserverTextBoxTests
    {
        [TestMethod]
        public void Constructor_WhenCalled_CreatesInstanceOfEmployeeRepository()
        {
            //Arrange
            var mockTextBox = MockRepository.GenerateMock<TextBox>();

            //Act
            var sut = new ObserverTextBox(mockTextBox);

            var result = RefelectionUtilities.GetField(sut, "repository");

            //Assert
            Assert.AreEqual(typeof(EmployeeRepository), result.FieldType);
        }

        [TestMethod]
        public void Subscribe_WhenProviderIsNull_UnsubscriberIsNull()
        {
            //Arrange
            var mockTextBox = MockRepository.GenerateMock<TextBox>();
            var mockProvider = MockRepository.GenerateMock<IObservable<string>>();
            var mockObserver = MockRepository.GenerateMock<IObserver<string>>();
            List<IObserver<string>> observerList = new List<IObserver<string>>()
            {
                mockObserver
            };

            var unsubscriber = new Unsubscriber(observerList, mockObserver);

            //Act
            mockProvider.Expect(x => x.Subscribe(Arg<IObserver<string>>.Is.Anything)).Return(unsubscriber);
            var sut = new ObserverTextBox(mockTextBox);
            sut.Subscribe(mockProvider);

            //Assert
            mockProvider.VerifyAllExpectations();
        }

        [TestMethod]
        public void Subscribe_WhenProviderIsNull_ProviderSubscribeIsNotCalled()
        {
            //Arrange
            var mockTextBox = MockRepository.GenerateMock<TextBox>();
            var mockProvider = MockRepository.GenerateMock<IObservable<string>>();
            var mockObserver = MockRepository.GenerateMock<IObserver<string>>();
            List<IObserver<string>> observerList = new List<IObserver<string>>()
            {
                mockObserver
            };

            var unsubscriber = new Unsubscriber(observerList, mockObserver);

            //Act
            mockProvider.Stub(x => x.Subscribe(Arg<IObserver<string>>.Is.Anything)).Return(unsubscriber);
            var sut = new ObserverTextBox(mockTextBox);
            sut.Subscribe(null);

            //Assert
            mockProvider.AssertWasNotCalled(x => x.Subscribe(Arg<IObserver<string>>.Is.Anything));
        }
    }
}
