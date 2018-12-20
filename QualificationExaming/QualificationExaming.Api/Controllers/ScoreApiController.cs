using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QualificationExaming.Api.Controllers
{
    using Entity;
    using IServices;
    using Services;
    using Unity.Attributes;
    public class ScoreApiController : ApiController
    {
        [Dependency]
        public IScoreService scoreService { get; set; }
        /// <summary>
        /// 获取成绩
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Score> GetScores(string openID)
        {
            var scores = scoreService.GetScores(openID);
            if (scores != null)
            {
                return scores.ToList();
            }
            return null;
        }
        /// <summary>
        /// 获取成绩
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        [HttpGet]
        public Score GetScore(string openID, int scoreID)
        {
            var score = scoreService.GetScores(openID).Find(m => m.ScoreID == scoreID);
            return score;
        }
        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        /// 用户id
        /// 题目id
        [HttpGet]
        public int AddScore(string openID, int examID, int score)
        {
            var result = scoreService.AddScore(openID, examID, score);
            return result;
        }
    }
}
