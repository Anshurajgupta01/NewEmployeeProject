using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpDataLayer;
using Employee;

namespace EmpBusinessLayers
{
    public class EmpBl
    {
        IEmployee ed;
        public EmpBl(IEmployee dl)
        {
            this.ed = dl;
        }

        public void Add(Employees e)
        {
            ed.AddEmp(e);
        }
        public bool Delete(int empnumber)
        {
            bool b = ed.DeleteEmp(empnumber);
            return b;
        }
        public Employees SearchEmp(int empnumber)
        {
            return(ed.SearchEmp(empnumber));            
        }
        public List<Employees> GetAllEmp()
        {
            List<Employees> emplist = new List<Employees>();
            emplist=ed.GetAllEmp();
            return emplist;
        }
        public void UpdateEmp(int Empnum,Employees emp)
        {
            ed.UpdateEmp(Empnum, emp);
        }




    }
}
