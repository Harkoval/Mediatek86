using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.bddmanager;
using MySql.Data.MySqlClient;

namespace Mediatek86.dal
{
    public class PersonnelDAL
    {
        private readonly BddManager bddManager;

        /// <summary>
        /// Instancie un gestionnaire d'accès à la BDD via Connexion.
        /// </summary>
        public PersonnelDAL()
        {
            bddManager = Connexion.GetBddManager();
        }

        // Ici viendront les méthodes :
        // GetAllPersonnels(), AddPersonnel(), UpdatePersonnel(), etc.
    }
}
