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
        /// 获取成绩根据OpenId
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
        /// 获取成绩根据用户id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Score> GetScoreByid(int id)
        {
            var score = scoreService.GetScoresByid(id);
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
        public int AddScore(string openID, int examID, int score, bool isRandom)
        {
            var result = scoreService.AddScore(openID, examID, score,isRandom);
            return result;
        }
    }
}
