
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace AdoDemo.Models
{
    [Table("Classes")]
    public class Classes
    {
        [IsId]
        [IsDBField]
        public int ClassID { get; set; }
        [IsDBField]
        public string ClassName { get; set; }
        [IsDBField]
        public string Description { get; set; }
        [IsDBField]
        public virtual ICollection<Students> Students { get; set; }
    }
}