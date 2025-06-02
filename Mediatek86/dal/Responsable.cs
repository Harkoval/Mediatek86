using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatek86.bddmanager;

namespace Mediatek86.dal
{
    internal class Responsable
    {
        private readonly BddManager bddManager;

        public Responsable()
        {
            bddManager = Connexion.GetBddManager(); // Chaîne de connexion
        }

        public bool VerifierConnexion(string login, string hash)
        {
            string query = "SELECT * FROM responsable WHERE login = @login AND pwd = @pwd";
            var parameters = new Dictionary<string, object>
        {
            { "@login", login },
            { "@pwd", hash }
        };

            var result = bddManager.ReqSelect(query, parameters);
            return result.Count > 0; // S'il y a un résultat, l'identification est valide
        }
    }
}
