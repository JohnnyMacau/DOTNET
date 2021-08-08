using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class __MigrationHistory
    {
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string MigrationId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsId]
        [IsDBField]
        public string ContextKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string Model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string ProductVersion { get; set; }
    }
}
