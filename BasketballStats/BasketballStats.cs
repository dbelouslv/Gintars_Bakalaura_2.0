using BS.BusinessLogic.Services;
using BS.EntityData.Context;
using EntityData.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BasketballStats
{
    public partial class BasketballStats : Form
    {
        private readonly ITeamService _teamService;
        private readonly IParticapantService _participantService;
        private readonly IMatchService _matchService;

        private Team SelectedTeamOne = new Team();
        private Team SelectedTeamTwo = new Team();
        private List<Particapant> TeamOneParticipants = new List<Particapant>();
        private List<Particapant> TeamTwoParticipants = new List<Particapant>();
        private Match ActiveMatch = new Match();

        public BasketballStats(ITeamService teamService, IParticapantService participantService, IMatchService matchService)
        {
            InitializeComponent();

            _teamService = teamService;
            _participantService = participantService;
            _matchService = matchService;
        }

        private void SetActivePanel(PanelType activePanel)
        {

        }

        public void CreateTeam(object sender, EventArgs e)
        {
            var success = _teamService.CreateTeam(newTeamInput.Text);
            newTeamInput.Text = string.Empty;

            messageLabel.Text = !success
                ? "Kļūda, komanda ar šādu nosaukumu jau eksistē"
                : "Komanda tika izveidota";

            messageLabel.ForeColor = success ? Color.Green : Color.Red;

            if (success)
                CreateNewGame(sender, e);
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

            ActiveMatch = _matchService.CreateMatch(); 
        }

        public void SelectTeam(object sender, EventArgs e)
        {
            var clickedItem = (ComboBox)sender;
            var item = clickedItem.SelectedItem.ToString();

            if (clickedItem.Name == "selectedTeamOne")
            {              
                SelectedTeamOne = _teamService.GetTeamByName(item);
                selectedTeamTwo.Items.Remove(item);
            }
            else
            {
                SelectedTeamTwo = _teamService.GetTeamByName(clickedItem.SelectedItem.ToString());
                selectedTeamOne.Items.Remove(item);
            }
        }

        private void SavePlayer(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            messageLabel.ForeColor = Color.Red;

            if (string.IsNullOrEmpty(nameInput.Text))
                messageLabel.Text = "Ievadiet spēlētāja vārdu!";

            if (string.IsNullOrEmpty(surnameInput.Text))
                messageLabel.Text = "Ievadiet spēlētāja uzvārdu!";

            if (!int.TryParse(numberInput.Text, out int number))
                messageLabel.Text = "Ievadiet spēlētāja numuru!";

            if (selectedTeams.Text == string.Empty)
                messageLabel.Text = "Izvēlaties komandu!";

            if (messageLabel.Text == string.Empty)
            {
                var currentPlayer = new Particapant();

                if (SelectedTeamOne.Name == selectedTeams.Text)
                {
                    currentPlayer = _participantService.CreateParticipant(nameInput.Text, surnameInput.Text, number, SelectedTeamOne.Id, ActiveMatch.Id);
                }
                else
                {
                    currentPlayer = _participantService.CreateParticipant(nameInput.Text, surnameInput.Text, number, SelectedTeamTwo.Id, ActiveMatch.Id);

                }

                selectedTeams.Text = nameInput.Text = surnameInput.Text = numberInput.Text = string.Empty;
            }
        }
    }
}
