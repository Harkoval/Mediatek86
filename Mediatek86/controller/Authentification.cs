using Mediatek86.bddmanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatek86.dal;
using System.Security.Cryptography;

namespace Mediatek86.controller
{
    /// <summary>
    /// Programme qui gère l'autentification
    /// </summary>
    public class Authentification
    {
        private readonly Responsable responsable;
        /// <summary>
        /// Permet au responsable de s'identifier
        /// </summary>
        public Authentification()
        {
            responsable = new Responsable();
        }
        /// <summary>
        /// Permet la connexion et la gestion du hachage du mot de passe
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Connexion(string login, string pwd)
        {
            string hash = HashSHA256(pwd); // Transforme le mot de passe clair
            return responsable.VerifierConnexion(login, hash);
        }

        private string HashSHA256(string input)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
        /// <summary>
        /// Test de hachage - non necessaire mais a permit de tester le hachage de mots de passe au SHA256!
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string TestHash(string input)
        {
            return HashSHA256(input);
        }
    }
}

