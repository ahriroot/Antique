using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ancient.Models
{
    /// <summary>
    /// 诗词实体
    /// </summary>
    ///  [Serializable]
    public class Poetry
    {
        public int PoetryID { get; set; }
        public string PoetryAuthor { get; set; }
        public string PoetryName { get; set; }
        public string PoetrySeason { get; set; }
        public string PoetryFeature { get; set; }
        public string PoetryClass { get; set; }
        public string PoetryContent { get; set; }
        public string PoetryZhu { get; set; }
        public string PoetryYi { get; set; }
        public string PoetryShang { get; set; }
    }
}
