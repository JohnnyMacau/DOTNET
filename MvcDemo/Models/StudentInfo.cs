using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class StudentInfo
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public int classid { get; set; }
        public string classname { get; set; }
        


    }
}