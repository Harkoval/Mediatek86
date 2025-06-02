using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.model
{
    /// <summary>
    /// Représente le type de service auquel est affilié un des membres du personnel.
    /// </summary>
    public class ServiceInfo
    {
        /// <summary>
        /// L'id du service!
        /// </summary>
        public int IdService { get; set; }
        /// <summary>
        /// Le nom du service
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur avec deux paramètres : idService et libelle
        /// </summary>
        public ServiceInfo(int idService, string libelle)
        {
            IdService = idService;
            Libelle = libelle;
        }

        /// <summary>
        /// Retourne le libellé du service (utile pour les ComboBox)
        /// </summary>
        public override string ToString()
        {
            return Libelle;
        }
    }
}
