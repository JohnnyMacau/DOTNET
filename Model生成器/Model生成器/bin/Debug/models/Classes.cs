using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class Classes
    {
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public int ClassID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string ClassName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string Description { get; set; }
    }
}
