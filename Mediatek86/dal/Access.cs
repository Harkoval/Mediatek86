using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatek86.bddmanager;
using MySql.Data.MySqlClient;
using Mediatek86.model;
using System.Windows.Forms;

namespace Mediatek86.dal
{
    /// <summary>
    /// Programme de connexion à la base de données mediatek86
    /// </summary>
    public class Access
    {
        private readonly BddManager bddManager;

        /// <summary>
        /// Instancie un gestionnaire d'accès à la BDD via Connexion.
        /// </summary>
        public Access()
        {
            bddManager = Connexion.GetBddManager();
        }

        /// <summary>
        /// Permet d'accéder au personnel de la base de donnée avec le SQL
        /// </summary>
        /// <returns></returns>
        public List<Personnel> GetAllPersonnel()
        {
            string query = @"SELECT p.idpersonnel, p.nom, p.prenom, p.tel, p.mail, 
                            s.idservice, s.nom AS libelleService
                            FROM personnel p
                            JOIN service s ON p.idservice = s.idservice
                            ORDER BY p.nom, p.prenom";

            List<object[]> records = bddManager.ReqSelect(query);
            List<Personnel> personnels = new List<Personnel>();

            foreach (object[] row in records)
            {
                int id = Convert.ToInt32(row[0]);
                string nom = row[1].ToString();
                string prenom = row[2].ToString();
                string tel = row[3].ToString();
                string mail = row[4].ToString();
                int idService = Convert.ToInt32(row[5]);
                string libelleService = row[6].ToString();

                personnels.Add(new Personnel(id, nom, prenom, tel, mail, idService, libelleService));
            }

            return personnels;
        }
        /// <summary>
        /// Requête SQL qui permet d'accéder aux services de la base de donnée avec le SQL
        /// </summary>
        /// <returns></returns>
        public List<ServiceInfo> GetAllServices()
        {
            string query = @"SELECT s.idservice, s.nom AS libelleService FROM service s";
            List<object[]> records = bddManager.ReqSelect(query);
            List<ServiceInfo> services = new List<ServiceInfo>();

            foreach (object[] row in records)
            {
                int idService = Convert.ToInt32(row[0]);
                string libelleService = row[1].ToString();

                services.Add(new ServiceInfo(idService, libelleService));
            }

            return services;
        }
        /// <summary>
        /// Requête SQL qui ajoute un personnel quand on appuis sur le bouton magique
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        /// <param name="idService"></param>
        public void AjouterPersonnel(string nom, string prenom, string tel, string mail, int idService)
        {
            string query = @"INSERT INTO personnel (nom, prenom, tel, mail, idservice) 
                                VALUES (@nom, @prenom, @tel, @mail, @idservice)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
            { "@nom", nom },
            { "@prenom", prenom },
            { "@tel", tel },
            { "@mail", mail },
            { "@idservice", idService }
            };

            bddManager.ReqUpdate(query, parameters);
        }
        /// <summary>
        /// Requête SQL permettant de Modifier un personnel.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        /// <param name="idService"></param>
        public void ModifierPersonnel(int id, string nom, string prenom, string tel, string mail, int idService)
        {
            string query = @"UPDATE personnel 
                 SET nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idservice = @idservice 
                 WHERE idpersonnel = @id";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@id", id },
        { "@nom", nom },
        { "@prenom", prenom },
        { "@tel", tel },
        { "@mail", mail },
        { "@idservice", idService }
    };

            bddManager.ReqUpdate(query, parameters);
        }
    }
}
