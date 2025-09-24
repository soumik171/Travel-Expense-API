using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public interface IRepoG<CLASS, ID, RET>
    {
        List<CLASS> Get();
        RET Create(CLASS obj);
        RET Update(CLASS obj);
        bool Delete(ID id);

    }
    
}
