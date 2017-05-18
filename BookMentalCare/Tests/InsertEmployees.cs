using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;

namespace Tests
{
    [TestClass]
    public class InsertEmployees
    {
        [TestMethod]
        public void TestInsertEmps()
        {
            EmployeeFacade empFac = new EmployeeFacade();
            DepartmentFacade depFac = new DepartmentFacade();

            Assert.IsTrue(empFac.SaveEmployee(new Employee() { FNAME = "Andreas", LNAME = "Gelardi", INITIALS = "AG", PASSWORD = "1234", TITLE = "Master", DEPARTMENT = depFac.FindDepartment(1)}));
        }
    }
}
