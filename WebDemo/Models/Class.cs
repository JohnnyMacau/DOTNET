using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebDemo.Models
{
    public class Class
    {
        [ScaffoldColumn(false)]
        public int ClassID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ClassName { get; set; }

        [Display(Name = "Class Description")]
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}