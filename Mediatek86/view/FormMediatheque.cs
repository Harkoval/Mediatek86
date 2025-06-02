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
            Raffraichir();
        }
        private void Raffraichir()
        {
            tabPersoAbs.SelectedIndex = 0;
            dgvPersonnel.ReadOnly = true;
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                    RemplirPersonnel();
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
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtTel.Text = "";
            txtMail.Text = "";
        }

        private void btnModifierPerso_Click(object sender, EventArgs e)
        {
            // Vérifie que le nom et prénom ne sont pas vides
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Le nom et le prénom sont obligatoires.");
                return;
            }

            try
            {
                // Vérifie qu'au moins une ligne est sélectionnée
                if (dgvPersonnel.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un personnel.");
                    return;
                }

                DataGridViewRow row = dgvPersonnel.SelectedRows[0];

                if (row.Cells["Id"].Value == null || !int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                {
                    MessageBox.Show("ID invalide.");
                    return;
                }

                string nom = txtNom.Text;
                string prenom = txtPrenom.Text;
                string tel = txtTel.Text;
                string mail = txtMail.Text;
                int idService = (int)comboService.SelectedValue;

                controller.ModifierPersonnel(id, nom, prenom, tel, mail, idService);
                MessageBox.Show("Modification réussie !");
                Raffraichir();

                // Réinitialise les champs texte
                txtNom.Text = "";
                txtPrenom.Text = "";
                txtTel.Text = "";
                txtMail.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void dgvPersonnel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPersonnel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPersonnel.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvPersonnel.CurrentRow;

                txtNom.Text = selectedRow.Cells["Nom"].Value.ToString();
                txtPrenom.Text = selectedRow.Cells["Prenom"].Value.ToString();
                txtTel.Text = selectedRow.Cells["Tel"].Value.ToString();
                txtMail.Text = selectedRow.Cells["Mail"].Value.ToString();

                string serviceNom = selectedRow.Cells["LibelleService"].Value.ToString();

                // Parcours des items pour sélectionner celui dont le texte correspond
                for (int i = 0; i < comboService.Items.Count; i++)
                {
                    var item = (ServiceInfo)comboService.Items[i];
                    if (item.Libelle == serviceNom)
                    {
                        comboService.SelectedIndex = i;
                        break;
                    }
                }
            }

        }
    }
}
