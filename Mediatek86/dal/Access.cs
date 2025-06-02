using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatek86.bddmanager;
using MySql.Data.MySqlClient;

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

        // Ici viendront les méthodes :
        // GetAllPersonnels(), AddPersonnel(), UpdatePersonnel(), etc.
    }
} 
