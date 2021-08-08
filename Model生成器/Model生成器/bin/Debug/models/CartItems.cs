using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class CartItems
    {
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public string ItemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string CartId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public int Quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public int ProductId { get; set; }
    }
}
