using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        private bool IsValidUser(string email, string password)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Register;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Registerpage WHERE Email = @Email AND Password = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }


        [HttpPost]
        public IActionResult Success(Student reg)
        {
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentsTable;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentsTable;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
                {
                    con.Open();

                    if (IsEmailAlreadyRegistered(con, reg.Email))
                    {
                        ModelState.AddModelError("Email", "Email is already registered");
                        return View("Registration");
                    }

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Student (FirstName, LastName, Gender, DateofBirth, Email, PhoneNumber, Age, Password, ConfirmPassword) VALUES (@firstname, @lastname, @gender, @dateofbirth, @email, @phoneNumber, @age, @password, @confirmpassword)", con))
                    {
                        cmd.Parameters.AddWithValue("@firstname", reg.FirstName);
                        cmd.Parameters.AddWithValue("@lastname", reg.LastName);
                        cmd.Parameters.AddWithValue("@gender", reg.Gender);
                        cmd.Parameters.AddWithValue("@dateofbirth", reg.DateofBirth);
                        cmd.Parameters.AddWithValue("@email", reg.Email);
                        cmd.Parameters.AddWithValue("@phonenumber", reg.PhoneNumber);
                        cmd.Parameters.AddWithValue("@age", reg.Age);
                        cmd.Parameters.AddWithValue("@password", reg.Password);
                        cmd.Parameters.AddWithValue("@confirmpassword", reg.ConfirmPassword);
                        

                        cmd.ExecuteNonQuery();
                    }
                }

                return View();
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = "An error occurred while processing your request.";
                return View("Error");
            }


        }
        private bool IsEmailAlreadyRegistered(SqlConnection con, string email)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Registerpage WHERE Email = @email", con))
            {
                cmd.Parameters.AddWithValue("@email", email);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}