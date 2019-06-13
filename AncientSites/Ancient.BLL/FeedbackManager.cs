using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ancient.DAL;
using Ancient.Models;

namespace Ancient.BLL
{
    public class FeedbackManager
    {
        FeedbackService objFeedbackService = new FeedbackService();

        /// <summary>
        /// 读取反馈信息逻辑类
        /// </summary>
        /// <param name="objFeedback">反馈信息</param>
        /// <returns>反馈信息</returns>
        public Feedback BLLReadFeedback(Feedback objFeedback)
        {
            return objFeedbackService.DALReadFeedback(objFeedback);
        }

        /// <summary>
        /// 保存反馈信息逻辑处理
        /// </summary>
        /// <param name="objFeedback">反馈信息</param>
        /// <returns>1:成功;0:失败</returns>
        public int BLLSaveFeedback(Feedback objFeedback)
        {
            return objFeedbackService.DALSaveFeedback(objFeedback);
        }

        /// <summary>
        /// 更改反馈信息逻辑处理
        /// </summary>
        /// <param name="objFeedback">反馈信息</param>
        /// <returns>1:成功;0:失败</returns>
        public int BLLUpdateFeedback(Feedback objFeedback)
        {
            
            return objFeedbackService.DALUpdateFeedback(objFeedback);
        }
    }
}
