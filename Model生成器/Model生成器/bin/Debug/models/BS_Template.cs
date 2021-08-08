using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class BS_Template
    {
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string typeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string folder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [IsDBField]
        public string remarks { get; set; }
    }
}
