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
                numberInput.Visible = savePlayerBtn.Visible = selectedTeams.Visible = teamOneName.Visible =
                teamTwoName.Visible = teamTwoRoster.Visible = teamOneRoster.Visible = isShow;

            if (isShow)
            {
                selectedTeams.Items.Add(SelectedTeamOne.Name);
                selectedTeams.Items.Add(SelectedTeamTwo.Name);

                teamOneName.Text = SelectedTeamOne.Name;
                teamTwoName.Text = SelectedTeamTwo.Name;
            }
        }

        private void UpdateRosterLabels()
        {
            teamOneRoster.Text = teamTwoRoster.Text = string.Empty;

            foreach (var participant in TeamOneParticipants)
                teamOneRoster.Text += $"#{participant.Number} {participant.FirstName} {participant.LastName}\n";

            foreach (var participant in TeamTwoParticipants)
                teamTwoRoster.Text += $"#{participant.Number} {participant.FirstName} {participant.LastName}\n";

            UpdateRemoveDropDown();
        }

        private void UpdateRemoveDropDown()
        {
            removeParticipant.Items.Clear();

            var allParticipnats = TeamOneParticipants;
            allParticipnats.AddRange(TeamTwoParticipants);

            removeParticipantBtn.Visible = dzestSpeletaju.Visible 
                = removeParticipant.Visible = allParticipnats.Count > 0;

            foreach (var participant in allParticipnats)
            {
                var teamName = participant.TeamId == SelectedTeamOne.Id
                    ? SelectedTeamOne.Name
                    : SelectedTeamTwo.Name;

                removeParticipant.Items.Add($"{participant.FirstName},{participant.LastName},{teamName}");
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
            {
                messageLabel.Text = "Ievadiet spēlētāja vārdu!";
                return;
            }

            if (string.IsNullOrEmpty(surnameInput.Text))
            {
                messageLabel.Text = "Ievadiet spēlētāja uzvārdu!";
                return;
            }

            if (string.IsNullOrEmpty(numberInput.Text))
            {
                messageLabel.Text = "Ievadiet spēlētāja numuru!";
                return;
            }
            else
            {
                if (!int.TryParse(numberInput.Text, out number))
                {
                    messageLabel.Text = "Nepareizs numura formāts!";
                    return;
                }
                else
                {
                    if (SelectedTeamOne.Name == selectedTeams.Text)
                    {
                        if (TeamOneParticipants.Any(a => a.Number == number))
                        {
                            messageLabel.Text = "Šis numurs jau ir aizņemts!";
                            return;
                        }
                    }
                    else
                    {
                        if (TeamTwoParticipants.Any(a => a.Number == number))
                        {
                            messageLabel.Text = "Šis numurs jau ir aizņemts!";
                            return;
                        }
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

                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Spēlētājs tika izveidots";

                UpdateRosterLabels();                
            }
        }        

        public void RemoveParticipant(object sender, EventArgs e)
        {
            var selectedItem = removeParticipant.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedItem))
            {
                var allParticipant = TeamOneParticipants;
                allParticipant.AddRange(TeamTwoParticipants);

                var items = selectedItem.Split(',');
                var firstName = items[0];
                var lastName = items[1];
                var teamName = items[2];

                var currentPlayer = allParticipant
                    .FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName && f.Team.Name == teamName);

                if (currentPlayer != null)
                {                                     
                    if (SelectedTeamOne.Name == teamName)
                    {
                        TeamOneParticipants.Remove(currentPlayer);
                    }
                    else
                    {
                        TeamTwoParticipants.Remove(currentPlayer);
                    }

                    _participantService.RemoveParticipant(currentPlayer.Id);

                    messageLabel.ForeColor = Color.Green;
                    messageLabel.Text = "Spēlētājs tika nodzēst";
                    removeParticipant.SelectedItem = string.Empty;

                    UpdateRosterLabels();
                }
                else
                {
                    messageLabel.ForeColor = Color.Red;
                    messageLabel.Text = "Spēlētājs neeksistē!";
                }
            }
        }

        private void ToManageGame(object sender, EventArgs e)
        {
            messageLabel.ForeColor = Color.Red;            

            if (SelectedTeamOne.Id != 0 && SelectedTeamTwo.Id != 0)
            {

            }
            else
                messageLabel.Text = "Izvēlaties komandas!";
        }
    }
}
