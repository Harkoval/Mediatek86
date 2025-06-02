using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mediatek86.controller;
using Mediatek86.dal;
using Mediatek86.model;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mediatek86.view
{
    /// <summary>
    /// Fenêtre de gestion du personnel et des absences de la médiathèque.
    /// </summary>
    public partial class FormMediatheque : Form
    {
        private readonly PersonnelController controller;
        /// <summary>
        /// Initialisation de la fenêtre de gestion.
        /// </summary>
        public FormMediatheque()
        {
            InitializeComponent();
            controller = new PersonnelController();
            tabPersoAbs.SelectedIndex = 0;
            dgvPersonnel.ReadOnly = true;
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPersonnel.MultiSelect = false;
            RemplirPersonnel();
            dgvPersonnel.AutoGenerateColumns = true;
            dgvPersonnel.Columns["Nom"].Width = 70;
            dgvPersonnel.Columns["Prenom"].Width = 75;
            dgvPersonnel.Columns["Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPersonnel.Columns["Tel"].Width = 100;
            this.MinimumSize = new Size(885, this.Height);
            this.MaximumSize = new Size(885, 9999);
            dgvPersonnel.Columns["IdService"].Visible = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void Raffraichir()
        {
            tabPersoAbs.SelectedIndex = 0;
            dgvPersonnel.ReadOnly = true;
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPersonnel.MultiSelect = false;
            RemplirPersonnel();
            dgvPersonnel.AutoGenerateColumns = true;
            dgvPersonnel.Columns["Nom"].Width = 70;
            dgvPersonnel.Columns["Prenom"].Width = 75;
            dgvPersonnel.Columns["Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPersonnel.Columns["Tel"].Width = 100;
            this.MinimumSize = new Size(885, this.Height);
            this.MaximumSize = new Size(885, 9999);
            dgvPersonnel.Columns["IdService"].Visible = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void RemplirPersonnel()
        {
            List<Personnel> personnels = controller.GetPersonnels();

            dgvPersonnel.Columns.Clear();
            dgvPersonnel.DataSource = null;
            dgvPersonnel.AutoGenerateColumns = true;
            dgvPersonnel.DataSource = personnels;
        }
        private void FormMediatheque_Load(object sender, EventArgs e)
        {
            Access access = new Access(); // ou ton contrôleur
            List<ServiceInfo> services = access.GetAllServices();

            comboService.DataSource = services;
            comboService.DisplayMember = "Libelle";
            comboService.ValueMember = "IdService";
            /* int selectedIdService = (int)comboService.SelectedValue;/// Sert à récupérer la valeur selectionnées*/
        }

        private void btnAjouterPerso_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string tel = txtTel.Text;
            string mail = txtMail.Text;
            int idService = (int)comboService.SelectedValue;

            if (!string.IsNullOrWhiteSpace(nom) && !string.IsNullOrWhiteSpace(prenom))
            {
                try
                {
                    controller.AjouterPersonnel(nom, prenom, tel, mail, idService);
                    MessageBox.Show("Personnel ajouté avec succès !");
                    RemplirPersonnel(); // Pour rafraîchir la liste dans le DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
                    dgvPersonnel.Columns.Clear();
                    dgvPersonnel.DataSource = null;
                    dgvPersonnel.AutoGenerateColumns = true;
                }
            }
            else
            {
                MessageBox.Show("Nom et prénom sont obligatoires.");
            }
            Raffraichir();
        }
    }
}
