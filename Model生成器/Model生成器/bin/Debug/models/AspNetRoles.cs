using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class AspNetRoles
    {
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string Name { get; set; }
    }
}
