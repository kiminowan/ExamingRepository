using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using Entity;
    public interface ISourceService
    {
        /// <summary>
        /// 获取资料
        /// </summary>
        /// <returns></returns>
        List<Source> GetSources();
    }
}
