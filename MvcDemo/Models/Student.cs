using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDemo.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please enter student name.")] 
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please enter student address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select student class.")]
        public virtual Class Class { get; set; }

    }
}