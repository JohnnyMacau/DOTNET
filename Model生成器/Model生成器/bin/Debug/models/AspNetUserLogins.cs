using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class AspNetUserLogins
    {
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public string LoginProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string ProviderKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string UserId { get; set; }
    }
}
