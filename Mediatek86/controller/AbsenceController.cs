using Mediatek86.dal;
using Mediatek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.controller
{
    internal class AbsenceController
    {
        private readonly Access access;

        public AbsenceController()
        {
            access = new Access();
        }

        public List<Absence> GetAllAbsences()
        {
            return access.GetAllAbsences();
        }

        public void AjouterAbsence(int idPersonnel, DateTime dateDebut, DateTime? dateFin, int idMotif)
        {
            Access access = new Access();
            access.AjouterAbsence(idPersonnel, dateDebut, dateFin, idMotif);
        }

        public void ModifierAbsence(int idPersonnel, DateTime dateDebut, DateTime? dateFin, int idMotif)
        {
            access.ModifierAbsence(idPersonnel, dateDebut, dateFin, idMotif);
        }


        public void SupprimerAbsence(int idPersonnel, DateTime dateDebut)
        {
            access.SupprimerAbsence(idPersonnel, dateDebut);
        }
    }
}
