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
    public class Service
    {
        /// <summary>
        /// Type de service
        /// </summary>
        public string ServiceType { get; set; }
        /// <summary>
        /// Information sur le type de service de l'employer
        /// </summary>
        /// <param name="serviceType"></param>
        public Service(string serviceType)
        {
            {
                ServiceType = serviceType;
            }
        }
    }
}
