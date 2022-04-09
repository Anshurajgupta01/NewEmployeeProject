using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee;

namespace EmpDataLayer
{
    public interface IEmployee
    {
          void AddEmp(Employees emp);
         bool DeleteEmp(int empnumber);
         Employees SearchEmp(int empnumber);

         List<Employees> GetAllEmp();
         void UpdateEmp(int empnumber,Employees e);


    }
}
