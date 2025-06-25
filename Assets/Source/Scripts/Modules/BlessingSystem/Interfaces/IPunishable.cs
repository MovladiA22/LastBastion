using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastBastion.BlessingSystem
{
    public interface IPunishable : IDivineIntervention
    {
        void TakePunish(int damage);
    }
}
