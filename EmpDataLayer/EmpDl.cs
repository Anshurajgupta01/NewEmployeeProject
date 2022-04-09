using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Employee;

namespace EmpDataLayer
{
    public class TestException : ApplicationException
    {
        private string str;
        public TestException(String message)
        {
            this.str = message;
        }

        public override string Message
        {
            get
            {
                return this.str;
            }
        }

    }
    public class EmpDl:IEmployee
    {
      //  public string constr = "Server=localhost;database=TestDatabase;integrated security=true";
        SqlConnection con;
        SqlCommand cmd;
        public void AddEmp(Employees emp)
        {
            try
            {
                if (emp.empname == "AAABBB")
                {
                    throw (new TestException("Cannot Insert, Give other Name....."));
                   
                }
                else
                {
                    string constr = "Server=localhost;database=TestDatabase;integrated security=true";

                    using (con = new SqlConnection(constr))
                    {
                        con.Open();
                        string str = "insert into employees values('" + emp.empname + "','" + emp.department + "'," + emp.salary + ",'" + emp.joindate + "')";
                        cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                    }

                }
                    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
           
            
        }
        public bool Delete(int empnumber)
        {
            string constr = "Server=localhost;database=TestDatabase;integrated security=true";
            using (con=new SqlConnection(constr))
            {
                con.Open();
                string str="delete from employees where empnumber="+empnumber;
                cmd = new SqlCommand(str, con);
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else return false;
            }
        }
        public Employees SearchEmp(int empnum)
        {
            string constr = "Server=localhost;database=TestDatabase;integrated security=true";
           
           using(con=new SqlConnection(constr))
            {
                con.Open();
                string str= "select * from Employees where empnumber =" + empnum;
                cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()==true)
                {
                    Employees e = new Employees();
                    e.empnumber = dr.GetInt16(0);
                    e.empname = dr.GetString(1);
                    e.department = dr.GetString(2);
                    e.salary = dr.GetDecimal(3);
                    e.joindate = dr.GetDateTime(4);
                    return e;
                }
                else
                    return null;
            }

        }

        public bool DeleteEmp(int Empnumber)
        {
            string constr = "Server=localhost;database=TestDatabase;integrated security=true";
            string str= "Delete from employees where empnumber=" + Empnumber;
            using(con=new SqlConnection(constr))
            {
                con.Open();
                cmd = new SqlCommand(str, con);
                int res = cmd.ExecuteNonQuery();
                if (res != 0)
                {
                    return true;
                }
                return false;


            }
        }

        public List<Employees> GetAllEmp()
        {
            string constr = "Server=localhost;database=TestDatabase;integrated security=true";
            List<Employees> emplist=new List<Employees>();
           
            
            using(con=new SqlConnection(constr))
            {
                con.Open();
                Employees emp;
                string str = "select * from employees";
                cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()==true)
                {
                    emp = new Employees();
                    emp.empnumber = dr.GetInt16(0);
                    emp.empname = dr.GetString(1);
                    emp.department = dr.GetString(2);
                    emp.salary = dr.GetDecimal(3);
                    emp.joindate = dr.GetDateTime(4);

                    emplist.Add(emp);
                }
                return emplist;
            }
        }
        public void UpdateEmp(int empnumber,Employees emp)
        {
            string constr = "Server=localhost;database=TestDatabase;integrated security=true";
            using (con=new SqlConnection(constr))
            {
                con.Open();
                string str = "update employees set empname='" + emp.empname + "', salary=" + emp.salary + ",department='" + emp.department + "' where empnumber=" +empnumber;
                cmd = new SqlCommand(str,con);
                cmd.ExecuteNonQuery();
                

            }
        }
        
    }
}
