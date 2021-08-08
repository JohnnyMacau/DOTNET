using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class Products
    {
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public int ProductID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string ImagePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public float? UnitPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public int? CategoryID { get; set; }
    }
}
