using BS.BusinessLogic.Services;
using BS.EntityData.Context;
using EntityData.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private void ShowCreateParticipantBlock(bool isShow)
        {
            izveidotSpeletaju.Visible = izveidotLabel.Visible = nameInput.Visible = surnameInput.Visible =
                numberInput.Visible = savePlayerBtn.Visible = selectedTeams.Visible = isShow;

            if (isShow)
            {
                selectedTeams.Items.Add(SelectedTeamOne.Name);
                selectedTeams.Items.Add(SelectedTeamTwo.Name);
            }
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

            if (SelectedTeamOne.Id != 0 && SelectedTeamTwo.Id != 0)
                ShowCreateParticipantBlock(true); 
            else
                ShowCreateParticipantBlock(false);
        }

        public void SavePlayer(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            messageLabel.ForeColor = Color.Red;
            int number = 0;

            if (string.IsNullOrEmpty(nameInput.Text))
                messageLabel.Text = "Ievadiet spēlētāja vārdu!";

            if (string.IsNullOrEmpty(surnameInput.Text))
                messageLabel.Text = "Ievadiet spēlētāja uzvārdu!";

            if (string.IsNullOrEmpty(numberInput.Text))
                messageLabel.Text = "Ievadiet spēlētāja numuru!";
            else
            {
                if (!int.TryParse(numberInput.Text, out number))
                    messageLabel.Text = "Nepareizs numura formāts!";
                else
                {
                    if (SelectedTeamOne.Name == selectedTeams.Text)
                    {
                        if (TeamOneParticipants.Any(a => a.Number == number))
                            messageLabel.Text = "Šis numurs jau ir aizņemts!";
                    }
                    else
                    {
                        if (TeamTwoParticipants.Any(a => a.Number == number))
                            messageLabel.Text = "Šis numurs jau ir aizņemts!";
                    }
                }
            }

            if (selectedTeams.Text == string.Empty)
                messageLabel.Text = "Izvēlaties komandu!";

            if (messageLabel.Text == string.Empty)
            {
                var currentPlayer = new Particapant();

                if (SelectedTeamOne.Name == selectedTeams.Text)
                {
                    currentPlayer = _participantService.CreateParticipant(nameInput.Text, surnameInput.Text, number, SelectedTeamOne.Id, ActiveMatch.Id);
                    TeamOneParticipants.Add(currentPlayer);
                }
                else
                {
                    currentPlayer = _participantService.CreateParticipant(nameInput.Text, surnameInput.Text, number, SelectedTeamTwo.Id, ActiveMatch.Id);
                    TeamTwoParticipants.Add(currentPlayer);
                }

                selectedTeams.Text = nameInput.Text = surnameInput.Text = numberInput.Text = string.Empty;
            }
        }
    }
}
