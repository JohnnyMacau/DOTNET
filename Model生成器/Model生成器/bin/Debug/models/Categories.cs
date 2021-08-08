using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class Categories
    {
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public int CategoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string CategoryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string Description { get; set; }
    }
}
