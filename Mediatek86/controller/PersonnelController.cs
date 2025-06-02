using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatek86.dal;
using Mediatek86.bddmanager;
using Mediatek86.model;

namespace Mediatek86.controller
{
    internal class PersonnelController
    {
        private readonly Access access;

        public PersonnelController()
        {
            access = new Access();
        }

        public List<Personnel> GetPersonnels()
        {
            return access.GetAllPersonnel();
        }
    }
}
