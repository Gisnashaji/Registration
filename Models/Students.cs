

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Student
    {


        [Required(ErrorMessage = " Enter your first name")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = " Enter your last name")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = " Choose your gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = " Enter date of birth")]

        [Display(Name = "Date of Birth")]

        [DataType(DataType.DateTime)]
        public DateTime DateofBirth { get; set; }


        [Required(ErrorMessage = " Enter email address")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email should be no longer than 100 characters.")]
        [Display(Name = "Email Address")]


        public string Email { get; set; }


        [Required(ErrorMessage = " Enter phone number")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number should be no longer than 20 characters.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = " Enter  Age")]
        [Phone(ErrorMessage = "Invalid Age")]
        [StringLength(20)]
        [Display(Name = "Age")]
        public string Age { get; set; }

        [Required(ErrorMessage = " Enter your  Password")]
        [StringLength(100)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = " Enter your Confirm Password")]
        [StringLength(100)]
        [Display(Name = " Confirm Password")]
        public string ConfirmPassword { get; set; }

        public List<Qualification> Qualifications { get; set; }

    }
}
