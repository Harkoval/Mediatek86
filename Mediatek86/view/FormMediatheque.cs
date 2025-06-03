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

        /////////////////////////////////////////////////  INITIALISATION DE LA FENÊTRE  ////////////////////////////////////////////////
        string boutonSelection = ""; /// Valeur pour déterminer quel bouton de Ajouter, Modifier, ou Supprimer est selectionné.
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
            txtMail.Enabled = false;
            txtNom.Enabled = false;
            txtTel.Enabled = false;
            txtPrenom.Enabled = false;
            comboService.Enabled = false;
            btnValider.Enabled = false;
            Raffraichir();

        }
        /// <summary>
        /// Fonction qui met à jour les mesures des composants
        /// </summary>
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
            dgvPersonnel.Columns["Id"].Visible = false;

        }


        /////////////////////////////////////////////////  SCRIPT DE LA PARTIE PERSONNEL  ///////////////////////////////////////////////
        
        private void btnAjouterPerso_Click(object sender, EventArgs e)
        {
            boutonSelection = "ajouter";
            btnAjouterPerso.Focus();
            txtMail.Enabled = true;
            txtNom.Enabled = true;
            txtTel.Enabled = true;
            txtPrenom.Enabled = true;
            comboService.Enabled = true;
            /*string nom = txtNom.Text;
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
            */
        }
        private void ActiverBoutons()
        {
            txtMail.Enabled = true;
            txtNom.Enabled = true;
            txtTel.Enabled = true;
            txtPrenom.Enabled = true;
            comboService.Enabled = true;
        }
        private void DesactiverBoutons()
        {
            txtMail.Enabled = false;
            txtNom.Enabled = false;
            txtTel.Enabled = false;
            txtPrenom.Enabled = false;
            comboService.Enabled = false;
            btnValider.Enabled = false;
        }

        private void btnModifierPerso_Click(object sender, EventArgs e)
        {
            boutonSelection = "modifier";
            btnModifierPerso.Focus();
            ActiverBoutons();
        }

        private void dgvPersonnel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VerifierChampsEtActiverBoutons();
        }

        private void dgvPersonnel_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            VerifierChampsEtActiverBoutons();
        }
        private void VerifierChampsEtActiverBoutons()
        {
            bool champsRemplis = !string.IsNullOrWhiteSpace(txtNom.Text)
                              && !string.IsNullOrWhiteSpace(txtPrenom.Text)
                              && !string.IsNullOrWhiteSpace(txtMail.Text)
                              && !string.IsNullOrWhiteSpace(txtTel.Text);

            if (boutonSelection != "") 
            {
                btnValider.Enabled = champsRemplis;
            }

        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            VerifierChampsEtActiverBoutons();
        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {
            VerifierChampsEtActiverBoutons();
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            VerifierChampsEtActiverBoutons();
        }

        private void comboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerifierChampsEtActiverBoutons();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (boutonSelection == "ajouter")
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
                boutonSelection = "";
                btnValider.Enabled = false;
            }
            else if (boutonSelection == "modifier")
            {
                // Vérifie que le nom et prénom ne sont pas vides - Fonction supprimer
                if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text) || string.IsNullOrWhiteSpace(txtMail.Text) || string.IsNullOrWhiteSpace(txtTel.Text))
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
                    boutonSelection = "";
                    btnValider.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la modification : " + ex.Message);
                }
            }
            else if (boutonSelection == "")
            { 
            if (txtNom.Enabled == false)
                {
                    btnValider.Enabled = false;
                }
            }
            else if (boutonSelection == "supprimer")
            {
                // Vérifie que le nom et prénom ne sont pas vides - Fonction supprimer
                if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text) || string.IsNullOrWhiteSpace(txtMail.Text) || string.IsNullOrWhiteSpace(txtTel.Text))
                {
                    MessageBox.Show("Veuillez selectionner un membre du personnel");
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

                    controller.SupprimerPersonnel(id, nom, prenom, tel, mail, idService);
                    MessageBox.Show("Modification réussie !");
                    Raffraichir();

                    // Réinitialise les champs texte
                    txtNom.Text = "";
                    txtPrenom.Text = "";
                    txtTel.Text = "";
                    txtMail.Text = "";
                    boutonSelection = "";
                    btnValider.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la modification : " + ex.Message);
                }
            }
        }
        ///
        private void FormMediatheque_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNom.Enabled == false)
            {
                btnValider.Enabled = false;
            }
            Surligner();
        }

        private void dgvPersonnel_MouseClick(object sender, MouseEventArgs e)
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
            Surligner();
        }

        private void dgvPersonnel_Click(object sender, EventArgs e)
        {
            Surligner();
        }
        /// <summary>
        /// Fonction permettant de mettre en valeur le bouton associé à la fonction active.(Ajouter, modifier, supprimer)
        /// </summary>
        public void Surligner()
        {
            if (boutonSelection == "ajouter")
            {
                btnAjouterPerso.Focus();
                ActiverBoutons();
            }
            else if (boutonSelection == "modifier")
            {
                btnModifierPerso.Focus();
                ActiverBoutons();
            }
            else if (boutonSelection == "supprimer")
            {
                btnSupprimerPerso.Focus();
                DesactiverBoutons();
                btnValider.Enabled = true;
            }
        }

        private void btnSupprimerPerso_Click(object sender, EventArgs e)
        {
            boutonSelection = "supprimer";
            DesactiverBoutons();
            btnValider.Enabled = true;
        }

        private void tabPerso_Click(object sender, EventArgs e)
        {
            Surligner();
        }

        /////////////////////////////////////////////////  SCRIPT DE LA PARTIE ABSENCE  /////////////////////////////////////////////////








    }
}
