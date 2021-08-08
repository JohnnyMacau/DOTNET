using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class Students
    {
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public int StudentID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string StudentName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public int? ClassID { get; set; }
    }
}
