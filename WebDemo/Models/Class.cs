using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Models
{
    [Table("Classes")]
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