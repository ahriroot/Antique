using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ancient.DAL;
using Ancient.Models;

namespace Ancient.BLL
{
    public class CollectManager
    {
        CollectService objCollectService = new CollectService();

        /// <summary>
        /// 读取收藏信息逻辑处理
        /// </summary>
        /// <param name="objCollect">收藏信息</param>
        /// <returns>true:是;false:否</returns>
        public bool BLLReadCollect(Collect objCollect)
        {
            return objCollectService.DALReadCollect(objCollect);
        }

        /// <summary>
        /// 保存收藏信息逻辑处理
        /// </summary>
        /// <param name="objCollect">收藏信息</param>
        /// <returns>1:成功;0:失败</returns>
        public int BLLSaveCollect(Collect objCollect)
        {
            return objCollectService.DALSaveCollect(objCollect);
        }

        /// <summary>
        /// 删除收藏信息逻辑处理
        /// </summary>
        /// <param name="objCollect">收藏信息</param>
        /// <returns>1:成功;0:失败</returns>
        public int BLLDeleteCollect(Collect objCollect)
        {
            return objCollectService.DALDeleteCollect(objCollect);
        }
    }
}
