using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.model
{
    /// <summary>
    /// Représente le motif d'absence d'un des membres du personnel
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// ID du motif
        /// </summary>
        public int IdMotif { get; set; }
        /// <summary>
        /// Nom du motif
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Informations sur le motif
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libelle"></param>
        public Motif(int id, string libelle)
        {
            IdMotif = id;
            Libelle = libelle;
        }
    }
}
