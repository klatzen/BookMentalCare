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

            Assert.IsTrue(empFac.SaveEmployee(new Employee() { FNAME = "Andreas", LNAME = "Gelardi",  PASSWORD = "1234", TITLE = "Master", DEPARTMENT = depFac.FindDepartment(1)}));
            Assert.IsTrue(empFac.SaveEmployee(new Employee() { FNAME = "Kristine", LNAME = "El-Banna", PASSWORD = "1234", TITLE = "Leder", DEPARTMENT = depFac.FindDepartment(1)}));
            Assert.IsTrue(empFac.SaveEmployee(new Employee() { FNAME = "Christian", LNAME = "Klattrup", PASSWORD = "1234", TITLE = "Læge", DEPARTMENT = depFac.FindDepartment(2) }));
            Assert.IsTrue(empFac.SaveEmployee(new Employee() { FNAME = "Darlene", LNAME = "Frandsen", PASSWORD = "1234", TITLE = "Sygeplejerske", DEPARTMENT = depFac.FindDepartment(3)}));
        }
    }
}
