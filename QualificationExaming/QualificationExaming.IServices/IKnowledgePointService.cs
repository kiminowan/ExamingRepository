using QualificationExaming.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    
    public interface IKnowledgePointService
    {
        /// <summary>
        /// 知识点类型表
        /// </summary>
        /// <returns></returns>
        List<KnowledgePoint> GetKnowledgePoint();
    }
}
