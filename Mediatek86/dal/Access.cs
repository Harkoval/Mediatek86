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
                            JOIN service s ON p.idservice = s.idservice";

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
    }
} 
