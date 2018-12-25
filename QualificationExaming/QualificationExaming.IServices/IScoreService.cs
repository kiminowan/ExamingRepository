using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using Entity;
    public interface IScoreService
    {
        /// <summary>
        /// 获取成绩
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        List<Score> GetScores(string openID);
        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        /// 用户id
        /// 题目id
        int AddScore(string openID, int examID, int score);
        /// <summary>
        /// 根据用户id进行查询成绩
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Score> GetScoresByid(int id);
    }
}
