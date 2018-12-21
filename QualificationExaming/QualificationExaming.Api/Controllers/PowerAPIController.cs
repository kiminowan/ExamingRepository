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
    public class PowerAPIController : ApiController
    {
        [Dependency]
        public IPowerService powerService { get; set; }
        /// <summary>
        /// 权限表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Power> GetPowers()
        {
            return powerService.GetPowers();
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddPowers(Power power)
        {
            return powerService.AddPowers(power);
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public int DelPowers(int id)
        {
            return powerService.DelPowers(id);
        }
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Power GetPowerById(int id)
        {
            return powerService.GetPowerById(id);
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        [HttpPost]
        public int Updatepower(Power power)
        {
            return powerService.Updatepower(power);
        }
    }
}
