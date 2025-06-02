using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mediatek86.controller;
using Mediatek86.view;
using MySql.Data.MySqlClient;

namespace Mediatek86
{
    public partial class FormAuthentification : Form
    {
        /// <summary>
        /// Formulaire d'identification pour accéder aux données
        /// </summary>
        public FormAuthentification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            /*
            string login = txtUtilisateur.Text;
            string pwd = txtMdp.Text;

            Authentification auth = new Authentification();
            if (auth.Connexion(login, pwd))
            {
                MessageBox.Show("Connexion réussie !");
                this.Hide();
                FormMediatheque form = new FormMediatheque();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.");
            }*/
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string login = txtUtilisateur.Text.Trim();
            string pwd = txtMdp.Text;

            Authentification auth = new Authentification();
            if (auth.Connexion(login, pwd))
            {
                
                this.Hide();
                FormMediatheque form = new FormMediatheque();
                
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.");
            }
        }
    }
}
