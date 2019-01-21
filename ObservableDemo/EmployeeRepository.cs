using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableDemo
{
    public class EmployeeRepository
    {
        private List<EmployeeInfo> employeeList;

        public EmployeeRepository()
        {
            employeeList = new List<EmployeeInfo>()
            {
                new EmployeeInfo
                {
                    Id = 1,
                    FirstName = "Stan",
                    LastName = "Marsh"
                },
                new EmployeeInfo
                {
                    Id = 2,
                    FirstName = "Kenny",
                    LastName = "McCormick"
                },
                new EmployeeInfo
                {
                    Id = 3,
                    FirstName = "Eric",
                    LastName = "Cartman"
                }
            };
        }

        public List<EmployeeInfo> GetAllEmployees()
        {
            return employeeList;
        }

        public EmployeeInfo GetEmployee(int id)
        {
            return employeeList[id];
        }

        
    }
}

