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
    
        public void AjouterPersonnel(string nom, string prenom, string tel, string mail, int idService)
        {
            access.AjouterPersonnel(nom, prenom, tel, mail, idService);
        }
        public void ModifierPersonnel(int id, string nom, string prenom, string tel, string mail, int idService)
        {
            access.ModifierPersonnel(id, nom, prenom, tel, mail, idService);
        }
    }
}