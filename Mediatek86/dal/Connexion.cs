using Mediatek86.bddmanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatek86.dal
{
    /// <summary>
    /// Connexion à la base de données mediatek86.
    /// </summary>
    public class Connexion
    {

        private static readonly string connectionString = "server=localhost;user=Admin01;database=mediatek86;password=strat_Pswd999";

            /// <summary>
            /// Accès à la base de données sous bddManager.
            /// </summary>
            public static BddManager GetBddManager()
            {
                    return BddManager.GetInstance(connectionString);
            }

            // méthodes pour get/insert/update/supprimer les personnels à faire
    }
}
