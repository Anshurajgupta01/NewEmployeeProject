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
            EmpBl bl = new EmpBl(new EmpDl());
            /*  List<Employees> em = new List<Employees>();

              Employees e = new Employees() { empname = "Aryan", department = "L&D", salary = 65000 };
               bl.Add(e);

              Employees delemp = bl.SearchEmp(132);
              if (delemp == null)
              {
                  Console.WriteLine("No such employee");
              }
              else
                  Console.WriteLine(delemp.empname);
              bl.UpdateEmp(132, e);
              bool b = bl.Delete(138);    */

            //Employees e = new Employees() { empname = "AcdBB", department = "Finance", salary = 65000,joindate= DateTime.Parse("11-Jun-2020")};
            //bl.Add(e);

            bool b=bl.Delete(143);
            if (b == true)
            {
                Console.WriteLine("deleted");

            }
            else
                Console.WriteLine("No such employee");


            List<Employees> emplist = bl.GetAllEmp();
            Console.WriteLine(emplist.Count);
            foreach(Employees emp in emplist)
            {
                Console.WriteLine("{0},{1}",emp.empname,emp.empnumber);
            }





        }
    }
}
