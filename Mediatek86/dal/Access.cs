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
        /// Requête SQL qui ajoute un personnel quand on appuis sur le bouton ajout
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

        /// <summary>
        /// Requête SQL permettant de supprimer un membre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        /// <param name="idService"></param>
        public void SupprimerPersonnel(int id, string nom, string prenom, string tel, string mail, int idService)
        {
            string query = @"DELETE FROM personnel WHERE idpersonnel = @id";

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


        /// <summary>
        /// Fonction qui vérifie l'existence d'un membre du personnel pour éviter les suppressions malencontreuses.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistePersonnel(int id)
        {
            string query = "SELECT COUNT(*) FROM personnel WHERE idpersonnel = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@id", id } };

            List<object[]> result = bddManager.ReqSelect(query, parameters);

            if (result.Count == 0 || result[0].Length == 0)
            {
                return false;
            }

            return Convert.ToInt32(result[0][0]) > 0;
        }

        /// <summary>
        /// Permet d'accéder aux absences de la base de donnée avec le SQL
        /// </summary>
        /// <returns></returns>
        public List<Absence> GetAllAbsences()
        {
            string query = @"
        SELECT p.idpersonnel, p.nom, a.datedebut, a.datefin, m.libelle
        FROM absence a
        JOIN personnel p ON p.idpersonnel = a.idpersonnel
        JOIN motif m ON m.idmotif = a.idmotif;
    ";

            List<object[]> records = bddManager.ReqSelect(query);
            List<Absence> absences = new List<Absence>();

            foreach (object[] row in records)
            {
                int idPersonnel = Convert.ToInt32(row[0]);
                string nom = row[1].ToString();
                DateTime dateDebut = Convert.ToDateTime(row[2]);
                DateTime? dateFin = row[3] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[3]);
                string motif = row[4].ToString();

                absences.Add(new Absence(idPersonnel, nom, dateDebut, dateFin, motif));
            }

            return absences;
        }


        /// <summary>
        /// Requête SQL permettant d'obtenir tous les motifs
        /// </summary>
        /// <returns></returns>
        public List<Motif> GetAllMotifs()
        {
            string query = @"SELECT m.idmotif, libelle AS motif FROM motif m";

            List<object[]> records = bddManager.ReqSelect(query);
            List<Motif> motifs = new List<Motif>();

            foreach (object[] row in records)
            {
                int idmotif = Convert.ToInt32(row[0]);
                string motif = row[1].ToString();

                motifs.Add(new Motif(idmotif, motif));
            }

            return motifs;
        }


        /// <summary>
        /// Requête SQL pour ajouter une absence
        /// </summary>
        /// <param name="idPersonnel"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="idMotif"></param>
        public void AjouterAbsence(int idPersonnel, DateTime dateDebut, DateTime? dateFin, int idMotif)
        {
            string query = @"INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif)
                     VALUES (@idpersonnel, @datedebut, @datefin, @idmotif)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@idpersonnel", idPersonnel },
        { "@datedebut", dateDebut },
        { "@datefin", dateFin.HasValue ? dateFin.Value : (object)DBNull.Value },
        { "@idmotif", idMotif }
    };

            bddManager.ReqUpdate(query, parameters);
        }


        /// <summary>
        /// Requête SQL pour modifier une absence
        /// </summary>
        /// <param name="idPersonnel"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="idMotif"></param>
        public void ModifierAbsence(int idPersonnel, DateTime dateDebut, DateTime? dateFin, int idMotif)
        {
            string query = @"UPDATE absence 
                     SET datefin = @datefin, idmotif = @idmotif 
                     WHERE idpersonnel = @idpersonnel AND datedebut = @datedebut";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@idpersonnel", idPersonnel },
        { "@datedebut", dateDebut },
        { "@datefin", dateFin.HasValue ? dateFin.Value : (object)DBNull.Value },
        { "@idmotif", idMotif }
    };

            bddManager.ReqUpdate(query, parameters);
        }

        /// <summary>
        /// Requête SQL pour supprimer une absence
        /// </summary>
        /// <param name="idPersonnel"></param>
        /// <param name="dateDebut"></param>
        public void SupprimerAbsence(int idPersonnel, DateTime dateDebut)
        {
            string query = @"DELETE FROM absence 
                             WHERE idpersonnel = @idPersonnel 
                             AND DATE(datedebut) = @dateDebutDateOnly";
            var parameters = new Dictionary<string, object>
            {
                { "@idPersonnel", idPersonnel },
                { "@dateDebutDateOnly", dateDebut.Date }
            };

            bddManager.ReqUpdate(query, parameters);
        }
    }
}
