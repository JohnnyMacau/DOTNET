using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Models
{
    [Table("Students")]
    public class Student
    {
        [ScaffoldColumn(false)]
        public int StudentID { get; set; }

        [Required, StringLength(100), Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required, StringLength(10000), Display(Name = "Address"), DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public int? ClassID { get; set; }

        public virtual Class Class { get; set; }
    }
}