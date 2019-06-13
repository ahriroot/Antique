using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ancient.DAL;
using Ancient.Models;

namespace Ancient.BLL
{
    /// <summary>
    /// 诗词业务逻辑类
    /// </summary>
    public class PoetryManager
    {
        PoetryService objPoetryService = new PoetryService();

        /// <summary>
        /// 通过诗人查询诗词
        /// </summary>
        /// <param name="authorName">诗人名</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> BLLSelectByAuthor(string authorName)
        {
            return objPoetryService.DALSelectByAuthor(authorName);
        }

        /// <summary>
        /// 通过诗名查询诗词(模糊查询)
        /// </summary>
        /// <param name="poetryName">诗名</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> BLLSelectByPoetryName(string poetryName)
        {
            return objPoetryService.DALSelectByPoetryName(poetryName);
        }

        /// <summary>
        /// 通过季节查询诗词
        /// </summary>
        /// <param name="season">季节</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> BLLSelectBySeason(string season)
        {
            return objPoetryService.DALSelectBySeason(season);
        }

        /// <summary>
        /// 通过特征查询诗词(模糊查询)
        /// </summary>
        /// <param name="feature">特征</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> BLLSelectByFeature(string feature)
        {
            return objPoetryService.DALSelectByFeature(feature);
        }

        /// <summary>
        /// 通过类别查询诗词(模糊查询)
        /// </summary>
        /// <param name="objClass">类别</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> BLLSelectByClass(string objClass)
        {
            return objPoetryService.DALSelectByClass(objClass);
        }
    }
}
