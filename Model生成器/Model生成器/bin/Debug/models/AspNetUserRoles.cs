using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class AspNetUserRoles
    {
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public string RoleId { get; set; }
    }
}
