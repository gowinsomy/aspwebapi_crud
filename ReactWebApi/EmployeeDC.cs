using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ReactWebApi.Models;

namespace ReactWebApi
{
    public class EmployeeDC
    {
        string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public DataTable GetAllEmployee()
        {
            try
            {
                DataTable dtEmployee=new DataTable();
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    string Query = "select * from Employee";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        conn.Open();
                        SqlDataAdapter DA = new SqlDataAdapter(cmd);
                        DA.Fill(dtEmployee);
                        conn.Close();                            
                    }
                }
                return dtEmployee;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public DataTable GetEmployee(string EmpID)
        {
            try
            {
                DataTable DtEmployeeByID = new DataTable();
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    string Query = "select * from Employee where ID =" + EmpID;
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        conn.Open();
                        SqlDataAdapter DA = new SqlDataAdapter(cmd);
                        DA.Fill(DtEmployeeByID);
                        conn.Close();        
                    }
                }
                return DtEmployeeByID;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool SaveEmployee(EmployeeMo ObjEmp)
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    string Query = "insert into Employee(FirstName,LastName,Age,Gender,JoinedDate) values('" + ObjEmp.FirstName + "','" + ObjEmp.LastName + "','" + ObjEmp.Age + "','" + ObjEmp.Gender + "','" + ObjEmp.JoinedDate + "')";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();        
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateEmployee(int id,EmployeeMo ObjEmp)
        {
            try
            {                
                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    string Query = "update Employee set FirstName = '" + ObjEmp.FirstName + "',LastName = '" + ObjEmp.LastName + "',Age = '" + ObjEmp.Age + "',Gender = '" + ObjEmp.Gender + "',JoinedDate = '" + ObjEmp.JoinedDate + "' where ID = " + id;
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();        
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteEmployee(string EmpID)
        {
            try
            {
                string Query = "delete from Employee where ID = " + EmpID;

                using (SqlConnection conn = new SqlConnection(ConString))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}