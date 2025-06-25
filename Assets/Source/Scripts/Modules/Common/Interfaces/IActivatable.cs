using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IActivable
    {
        bool IsActivated { get; }

        void Activate();
        void Deactivate();
    }
}
