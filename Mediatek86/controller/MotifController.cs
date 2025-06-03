using Mediatek86.dal;
using Mediatek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.controller
{
    internal class MotifController
    {
        private readonly Access access;

        public MotifController()
        {
            access = new Access();
        }

        public List<Motif> GetAllMotifs()
        {
            return access.GetAllMotifs();
        }
    }
}
