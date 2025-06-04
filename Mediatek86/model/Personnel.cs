using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Datatypes.Scalar.Types;

namespace Mediatek86.model
{
    /// <summary>
    /// Représente un membre du personnel
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// ID du personnel
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nom du membre
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Prénom du membre
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Numéro de téléphone du membre
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// Id du service du membre.
        /// (1= Administratif, 2= médiation culturelle, 3= prêt)
        /// </summary>
        public string IdService { get; set; }
        /// <summary>
        /// Nom du service du membre
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Adresse mail du membre
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// Informations du personnel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="idservice"></param>
        /// <param name="service"></param>
        /// <param name="mail"></param>
        public Personnel(int id, string nom, string prenom, string tel, string mail, int idservice, string service)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            IdService = idservice.ToString();
            Mail = mail;
            Service = service;
        }
    }
    /// <summary>
    /// Permet d'accéder aux services
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Id du service du membre.
        /// (1= Administratif, 2= médiation culturelle, 3= prêt)
        /// </summary>
        public string IdService { get; set; }
        /// <summary>
        /// Nom du service du membre
        /// </summary>
        public string LibelleService { get; set; }
        /// <summary>
        /// Infos sur le service
        /// </summary>
        /// <param name="idservice"></param>
        /// <param name="libelleservice"></param>
        public Service(int idservice, string libelleservice)
        {
            int IdService = idservice;
            LibelleService = libelleservice;
        }
    }
}
