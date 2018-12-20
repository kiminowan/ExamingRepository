using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using Entity;
    public interface ICollectionService
    {
        /// <summary>
        /// 获取收藏题目
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        List<Question> GetCollectionQuestions(string openID);
        /// <summary>
        /// 根据用户openID和题目ID删除收藏
        /// </summary>
        /// <param name="erroid"></param>
        /// <returns></returns>
        int DeleteCollection(int questionID, string openID);
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int AddCollection(string openID, int questionID);
    }
}
