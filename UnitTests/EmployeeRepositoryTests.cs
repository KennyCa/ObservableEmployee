using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObservableDemo;

namespace UnitTests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        public void GetAllEmplyees_WhenCalled_ReturnsListOfThreeEmployees()
        {
            //Arrange
            var repository = new EmployeeRepository();

            //Act
            var result = repository.GetAllEmployees();

            //Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetEmployee_WhenCalled_ReturnsOneEmployee()
        {
            //Arrange
            var first = "Stan";
            var last = "Marsh";
            var repository = new EmployeeRepository();

            //Act
            var result = repository.GetEmployee(0);

            //Assert
            Assert.AreEqual(first, result.FirstName);
            Assert.AreEqual(last, result.LastName);
        }
    }
}
