using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.model
{
    /// <summary>
    /// Représente l'absence d'un des membres du personnel
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// ID du membre absent
        /// </summary>
        public int IdPersonnel { get;}
        /// <summary>
        /// Nom du membre absent
        /// </summary>
        /// 
        public string Nom { get; }
        /// <summary>
        /// Date de début d'absence
        /// </summary>
        public DateTime DateDebut { get; set; }
        /// <summary>
        /// Date de fin d'absence si l'absence est fini (peut être nullable)
        /// </summary>
        public DateTime? DateFin { get; set; }
        /// <summary>
        /// Motif de l'absence
        /// </summary>
        public string Motif { get; set; }

        /// <summary>
        /// Infos sur l'absence
        /// </summary>
        /// <param name="idPersonnel"></param>
        /// <param name="nom"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="motif"></param>
        public Absence(int idPersonnel, string nom, DateTime dateDebut, DateTime? dateFin, string motif)
        {
            IdPersonnel = idPersonnel;
            Nom = nom;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Motif = motif;
        }
    }
}
