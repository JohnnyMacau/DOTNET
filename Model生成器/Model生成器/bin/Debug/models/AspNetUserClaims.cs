using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class AspNetUserClaims
    {
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string ClaimType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string ClaimValue { get; set; }
    }
}
