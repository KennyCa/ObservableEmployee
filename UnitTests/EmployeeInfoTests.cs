using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObservableDemo;

namespace UnitTests
{
    [TestClass]
    public class EmployeeInfoTests
    {
        [TestMethod]
        public void EmployeeInfo_WhenSet_GetsSameValue()
        {
            //Arrange
            var id = 1;
            var firstName = "Bob";
            var lastName = "Tom";

            //Act
            var employee = new EmployeeInfo()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            //Assert
            Assert.AreEqual(id, employee.Id);
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
        }
    }
}
