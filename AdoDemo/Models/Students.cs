using AdoDemo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoDemo.Models
{
    [Table("Students")]
    public class Students
    {
        [IsId]
        [IsDBField]
        public int StudentID { get; set; }

        [IsDBField]
        public string StudentName { get; set; }

        [IsDBField]
        public string Address { get; set; }

        [IsDBField]
        public int? ClassID { get; set; }

    }
}