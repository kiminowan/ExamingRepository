using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    using Entity;
    public interface IAdminService
    {
        List<ShowAdmin> GetAdmins();
        int AddAdmin(Admin admin);
        IEnumerable<ShowAdmin> showAdmins(int id);
        int UpdateAdmin(Admin admin);


    }
}
