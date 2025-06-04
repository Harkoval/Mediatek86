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
        string boutonSelection = ""; /// Valeur pour déterminer quel bouton de Ajouter, Modifier, ou Supprimer est selectionné dans Personnel
        string boutonSelectionAbs = ""; /// Valeur pour déterminer quel bouton de Ajouter, Modifier, ou Supprimer est selectionné dans Absent
        string tabSelection = "Personnel";/// Valeur pour déterminer si l'on se trouve sur la page d'éditeur du personnel ou du service
        private readonly PersonnelController controller;
        private readonly MotifController motifController;
        
        /// <summary>
        /// Initialisation de la fenêtre de gestion.
        /// </summary>
        public FormMediatheque()
        {
            InitializeComponent();
            controller = new PersonnelController();
            motifController = new MotifController();
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
            dgvPersonnel.Rows[0].Selected = true;
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
                if (MessageBox.Show("Ajouter ce personnel?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            }
            else if (boutonSelection == "modifier")
                {
                if (MessageBox.Show("Modifier ce personnel?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    
                    if (MessageBox.Show("Voulez vous vraiment supprimer ce personnel?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string nom = txtNom.Text;
                        string prenom = txtPrenom.Text;
                        string tel = txtTel.Text;
                        string mail = txtMail.Text;
                        int idService = (int)comboService.SelectedValue;

                        controller.SupprimerPersonnel(id, nom, prenom, tel, mail, idService);
                        MessageBox.Show("Supression réussie !");
                        Raffraichir();

                        // Réinitialise les champs texte
                        txtNom.Text = "";
                        txtPrenom.Text = "";
                        txtTel.Text = "";
                        txtMail.Text = "";
                        boutonSelection = "";
                        btnValider.Enabled = false;
                    }
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
            if (tabSelection == "Personnel")
            {
                if (txtNom.Enabled == false)
                {
                    btnValider.Enabled = false;
                }
                Surligner();
            }
            else
            {
                Surligner();
            }
            
        }

        /// <summary>
        /// Quand un click est réalisé dans la liste(Data Grid Viewer), les zones d'information de 
        /// l'éditeur se définissent par la ligne selectionnée!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPersonnel_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabSelection == "Personnel")
            {
                if (dgvPersonnel.CurrentRow != null)
                {
                    DataGridViewRow selectedRow = dgvPersonnel.CurrentRow;

                    txtNom.Text = selectedRow.Cells["Nom"].Value.ToString();
                    txtPrenom.Text = selectedRow.Cells["Prenom"].Value.ToString();
                    txtTel.Text = selectedRow.Cells["Tel"].Value.ToString();
                    txtMail.Text = selectedRow.Cells["Mail"].Value.ToString();

                    string serviceNom = selectedRow.Cells["Service"].Value.ToString();

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
            else
            {
                SelectionCellule();
            }
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
            if (tabSelection == "Personnel")
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
            else
            {
                if (boutonSelectionAbs == "ajouter")
                {
                    bntAjouterAbs.Focus();
                    ActiverBoutonsAbs();
                }
                else if (boutonSelectionAbs == "modifier")
                {
                    btnModifierAbs.Focus();
                    ActiverBoutonsAbs();
                }
                else if (boutonSelectionAbs == "supprimer")
                {
                    btnSupprimerAbs.Focus();
                    DesactiverBoutonsAbs();
                    btnValiderAbs.Enabled = true;
                }
            }
            
        }

        private void btnSupprimerPerso_Click(object sender, EventArgs e)
        {
            boutonSelection = "supprimer";
            DesactiverBoutons();
            btnValider.Enabled = true;

            if (dgvPersonnel.CurrentRow == null)
            {
                MessageBox.Show("Veuillez selectionner une ligne.");
                return;
            }
            DataGridViewRow Row = dgvPersonnel.CurrentRow;
            txtNom.Text = Row.Cells["Nom"].Value.ToString();
            txtPrenom.Text = Row.Cells["Prenom"].Value.ToString();
            txtTel.Text = Row.Cells["Tel"].Value.ToString();
            txtMail.Text = Row.Cells["Mail"].Value.ToString();

        }

        private void tabPerso_Click(object sender, EventArgs e)
        {
            Surligner();
        }

        /////////////////////////////////////////////////  SCRIPT DE LA PARTIE ABSENCE  /////////////////////////////////////////////////

        private readonly AbsenceController absenceController = new AbsenceController(); // Créé une instance de AbsenceController pour l'utiliser

        private void RemplirAbsences()
        {
            // 1. Récupérer les absences depuis le contrôleur
            List<Absence> absences = absenceController.GetAllAbsences();

            // 2. Réinitialiser et recharger le DataGridView
            dgvPersonnel.Columns.Clear();
            dgvPersonnel.DataSource = null;
            dgvPersonnel.AutoGenerateColumns = true;
            dgvPersonnel.DataSource = absences;

            // 3. Afficher les noms de colonnes pour vérification

            // 4. Cacher la colonne contenant l'ID du personnel si elle existe
            if (dgvPersonnel.Columns.Contains("IdPersonnel"))
            {
                dgvPersonnel.Columns["IdPersonnel"].Visible = false;
            }

            // 5. Mise en forme des entêtes
            if (dgvPersonnel.Columns.Count >= 3)
            {
                dgvPersonnel.Columns[1].HeaderText = "Date de début";
                dgvPersonnel.Columns[2].HeaderText = "Date de fin";
            }

            // 6. Combobox des absents
            cbNomAbsent.DataSource = null;
            List<Personnel> personnels = controller.GetPersonnels();
            cbNomAbsent.DataSource = personnels;
            cbNomAbsent.DisplayMember = "Nom";
            cbNomAbsent.ValueMember = "Id";

            // 7. Combobox des motifs
            List<Motif> motifs = motifController.GetAllMotifs();
            cbMotif.DataSource = null;
            cbMotif.DisplayMember = "Libelle";
            cbMotif.ValueMember = "IdMotif";
            cbMotif.DataSource = motifs;
        }

        /// <summary>
        /// Fonction pour raffraichir l'affichage des absences et l'adapter correctement.
        /// </summary>
        public void RaffraichirAbs()
        {
            dgvPersonnel.DataSource = null;
            dgvPersonnel.Columns.Clear();
            dgvPersonnel.ClearSelection();
            tabSelection = "Absences";
            RemplirAbsences();
            dgvPersonnel.Columns[0].Width = 120;
            dgvPersonnel.Columns["DateFin"].Width = 120;
            dgvPersonnel.Columns["DateDebut"].Width = 120;
            dgvPersonnel.Columns["Motif"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void tabPersoAbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPersoAbs.SelectedIndex == 1)
            {
                RaffraichirAbs();
            }
            else
            {
                dgvPersonnel.DataSource = null;
                dgvPersonnel.Columns.Clear();
                dgvPersonnel.ClearSelection();
                tabSelection = "Personnel";
                RemplirPersonnel();
                Raffraichir();
            }
        }





        /// <summary>
        /// Quand une des cellules du tableau est selectionnée
        /// </summary>
        public void SelectionCellule()
        {
            if (dgvPersonnel.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvPersonnel.CurrentRow;

                string nom = selectedRow.Cells["Nom"].Value.ToString();
                DateTime dateDebutValue = Convert.ToDateTime(selectedRow.Cells["DateDebut"].Value);
                object rawDateFin = selectedRow.Cells["DateFin"].Value;
                string motif = selectedRow.Cells["Motif"].Value.ToString();

                // Sélectionne le motif correspondant
                foreach (Motif item in cbMotif.Items)
                {
                    if (item.Libelle == motif)
                    {
                        cbMotif.SelectedItem = item;
                        break;
                    }
                }

                // Sélectionne le personnel correspondant
                foreach (Personnel p in cbNomAbsent.Items)
                {
                    if (p.Nom == nom)
                    {
                        cbNomAbsent.SelectedItem = p;
                        break;
                    }
                }

                // Affecte la date de début
                dateDebut.Value = dateDebutValue;

                // Gestion de la date de fin (null ou réelle)
                if (rawDateFin != DBNull.Value && rawDateFin is DateTime dateFinValue)
                {
                    // Vérifie si la valeur est dans l'intervalle autorisé par le DateTimePicker
                    if (dateFinValue >= dateFin.MinDate && dateFinValue <= dateFin.MaxDate)
                    {
                        dateFin.Value = dateFinValue;
                    }
                    else
                    {
                        dateFin.Value = DateTime.Now;
                    }
                    checkNonDef.Checked = false;
                }
                else
                {
                    dateFin.Value = DateTime.Now;
                    checkNonDef.Checked = true;
                }
            }

            Surligner();
        }


        private void ActiverBoutonsAbs()
        {
            cbNomAbsent.Enabled = true;
            dateDebut.Enabled = true;
            dateFin.Enabled = true;
            cbMotif.Enabled = true;
        }
        private void DesactiverBoutonsAbs()
        {
            cbNomAbsent.Enabled = false;
            dateDebut.Enabled = false;
            dateFin.Enabled = false;
            cbMotif.Enabled = false;
        }
        private void bntAjouterAbs_Click(object sender, EventArgs e)
        {
            boutonSelectionAbs = "ajouter";
            btnAjouterPerso.Focus();
            ActiverBoutonsAbs();
        }

        private void btnModifierAbs_Click(object sender, EventArgs e)
        {
            boutonSelectionAbs = "modifier";
            btnModifierAbs.Focus();
            ActiverBoutonsAbs();
        }

        private void btnSupprimerAbs_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner une ligne.");
                return;
            }

            DataGridViewRow selectedRow = dgvPersonnel.CurrentRow;

            // Récupération des valeurs par colonne
            int idPersonnel = Convert.ToInt32(selectedRow.Cells["IdPersonnel"].Value);
            string nom = selectedRow.Cells["Nom"].Value.ToString();
            DateTime debutAbs = Convert.ToDateTime(selectedRow.Cells["DateDebut"].Value);
            DateTime? finAbs = selectedRow.Cells["DateFin"].Value == DBNull.Value
                ? (DateTime?)null
                : Convert.ToDateTime(selectedRow.Cells["DateFin"].Value);

            string motif = selectedRow.Cells["Motif"].Value.ToString();

            // Préparer les champs
            cbNomAbsent.SelectedValue = idPersonnel;
            dateDebut.Value = debutAbs;

            if (finAbs.HasValue && finAbs.Value >= dateFin.MinDate && finAbs.Value <= dateFin.MaxDate)
            {
                dateFin.Value = finAbs.Value;
                checkNonDef.Checked = false;
            }
            else
            {
                dateFin.Value = DateTime.Now;
                checkNonDef.Checked = true;
            }
            foreach (Motif m in cbMotif.Items)
            {
                if (m.Libelle == motif)
                {
                    cbMotif.SelectedItem = m;
                    break;
                }
            }

            boutonSelectionAbs = "supprimer";
            DesactiverBoutonsAbs();
            btnValiderAbs.Enabled = true;
        }




        private void btnValiderAbs_Click(object sender, EventArgs e)
        {
            if (boutonSelectionAbs == "ajouter")
            {
                if (cbNomAbsent.SelectedItem is Personnel personnel && cbMotif.SelectedItem is Motif motif)
                {
                    DateTime dateDebutAbs = dateDebut.Value;
                    DateTime? dateFinAbs = checkNonDef.Checked ? (DateTime?)null : dateFin.Value;
                    int idMotif = motif.IdMotif;

                    try
                    {
                        absenceController.AjouterAbsence(personnel.Id, dateDebutAbs, dateFinAbs, idMotif);
                        MessageBox.Show("Absence ajoutée !");
                        RemplirAbsences();
                        RaffraichirAbs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un nom et un motif.");
                }
            }
            else if (boutonSelectionAbs == "modifier")
            {
                if (cbNomAbsent.SelectedItem is Personnel personnel && cbMotif.SelectedItem is Motif motif)
                {
                    DateTime dateDebutAbs = dateDebut.Value;
                    DateTime? dateFinAbs = checkNonDef.Checked ? (DateTime?)null : dateFin.Value;
                    int idMotif = motif.IdMotif;

                    try
                    {
                        absenceController.ModifierAbsence(personnel.Id, dateDebutAbs, dateFinAbs, idMotif);
                        MessageBox.Show("Absence modifiée !");
                        RemplirAbsences();
                        RaffraichirAbs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un nom et un motif.");
                }
            }
            else if (boutonSelectionAbs == "")
            {
                if (cbNomAbsent.Enabled == false)
                {
                    btnValiderAbs.Enabled = false;
                }
            }
            else if (boutonSelectionAbs == "supprimer")
            {
                if (dgvPersonnel.CurrentRow != null)
                {
                    int idPersonnel = Convert.ToInt32(dgvPersonnel.CurrentRow.Cells["IdPersonnel"].Value);
                    DateTime dateDebutAbs = Convert.ToDateTime(dgvPersonnel.CurrentRow.Cells["DateDebut"].Value);

                    if (MessageBox.Show("Supprimer cette absence ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        absenceController.SupprimerAbsence(idPersonnel, dateDebutAbs);
                        MessageBox.Show("Absence supprimée !");
                        RemplirAbsences();
                        RaffraichirAbs();
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une ligne.");
                }
            }
        }

        private void tabAbsence_Click(object sender, EventArgs e)
        {
            Surligner();
        }
    }
}
