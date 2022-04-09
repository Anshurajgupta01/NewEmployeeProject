using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpBusinessLayers;
using EmpDataLayer;
using Employee;

namespace NewEmployeeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Employees> em = new List<Employees>();
            EmpBl bl = new EmpBl(new EmpDl());
            //Employees e = new Employees() {empname = "Alok", department = "Management", salary = 50000, joindate = DateTime.Parse("12-Jan-2020") };
            //// bl.Add(e);

            //Employees delemp = bl.SearchEmp(132);
            //if (delemp == null)
            //{
            //    Console.WriteLine("No such employee");
            //}
            //else
            //    Console.WriteLine(delemp.empname);
            //// bl.UpdateEmp(131,e);


            List<Employees> emplist = bl.GetAllEmp();

            foreach(Employees e in emplist)
            {
                Console.WriteLine(e.empname);
            }





        }
    }
}
