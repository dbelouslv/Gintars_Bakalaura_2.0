using BS.BusinessLogic.Services;
using BS.EntityData.Context;
using EntityData.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BasketballStats
{
    public partial class BasketballStats : Form
    {
        private readonly ITeamService _teamService;

        private Team SelectedTeamOne = new Team();
        private Team SelectedTeamTwo = new Team();

        public BasketballStats(ITeamService teamService)
        {
            InitializeComponent();

            _teamService = teamService;
        }

        private void SetActivePanel(PanelType activePanel)
        {

        }

        public void CreateTeam(object sender, EventArgs e)
        {
            var success = _teamService.CreateTeam(newTeamInput.Text);

            messageLabel.Text = success ? "Komanda tika izveidota" : "Kļūda, komanda ar šādu nosaukumu jau eksistē";
            messageLabel.ForeColor = success ? Color.Green : Color.Red;
        }

        public void Exit(object sender, EventArgs e)
        {
            Close();
        }

        public void CreateNewGame(object sender, EventArgs e)
        {
            var teams = _teamService.GetTeams();

            selectedTeamOne.Items.AddRange(teams);
            selectedTeamTwo.Items.AddRange(teams);
        }

        public void SelectTeam(object sender, EventArgs e)
        {
            ComboBox clickedItem = (ComboBox)sender;

            if (clickedItem.Name == "selectedTeamOne")
                SelectedTeamOne = clickedItem.SelectedItem;
            else
                SelectedTeamTwo = clickedItem.SelectedItem;
        }
    }
}
