using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LastBastion.BlessingSystem
{
    public interface IProtectable : IDivineIntervention
    {
        bool IsInvulnerable { get; set; }
    }
}
