using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class AspNetUsers
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
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public Boolean EmailConfirmed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string PasswordHash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string SecurityStamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public Boolean PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public Boolean TwoFactorEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public DateTime? LockoutEndDateUtc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public Boolean LockoutEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public int AccessFailedCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string UserName { get; set; }
    }
}
