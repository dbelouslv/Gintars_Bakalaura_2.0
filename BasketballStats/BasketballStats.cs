﻿using BS.BusinessLogic.Services;
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
        private Particapant ActiveParticipant = new Particapant();
        private List<RadioButton> RadioButtons = new List<RadioButton>();

        public BasketballStats(ITeamService teamService, IParticapantService participantService, IMatchService matchService)
        {
            InitializeComponent();

            _teamService = teamService;
            _participantService = participantService;
            _matchService = matchService;

            SetActivePanel(PanelType.Home, "Galvenā", 70);
        }

        private void SetActivePanel(PanelType activePanel, string header, int height)
        {
            headerName.Text = header;
            leftSmallPanel.Top = height;
            messageLabel.Text = string.Empty;

            switch (activePanel)
            {
                case PanelType.CreateGame:
                    Controls.Add(CreateGamePanel);
                    Controls.Remove(HomePanel);
                    Controls.Remove(ManageGamePanel);
                    Controls.Remove(StatisticOfTheGamePanel);
                    break;
                case PanelType.StartGame:
                    Controls.Add(ManageGamePanel);
                    Controls.Remove(HomePanel);
                    Controls.Remove(CreateGamePanel);
                    Controls.Remove(StatisticOfTheGamePanel);
                    break;
                case PanelType.StatisticOfGame:
                    Controls.Add(StatisticOfTheGamePanel);
                    Controls.Remove(HomePanel);
                    Controls.Remove(CreateGamePanel);
                    Controls.Remove(ManageGamePanel);
                    break;
                default:
                    Controls.Add(HomePanel);
                    Controls.Remove(CreateGamePanel);
                    Controls.Remove(ManageGamePanel);
                    Controls.Remove(StatisticOfTheGamePanel);
                    break;
            }

            if (activePanel != PanelType.StatisticOfGame)
                StatisticOfTheGamePanel.Controls.Clear();
        }

        private void ShowCreateParticipantBlock(bool isShow)
        {
            izveidotSpeletaju.Visible = izveidotLabel.Visible = nameInput.Visible = surnameInput.Visible =
                numberInput.Visible = savePlayerBtn.Visible = selectedTeams.Visible = teamOneName.Visible =
                teamTwoName.Visible = teamTwoRoster.Visible = teamOneRoster.Visible = toManageGameBtn.Visible = isShow;

            selectedTeams.Items.Clear();
            teamOneName.Text = teamTwoName.Text = string.Empty;

            UpdateRosterLabels();

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

            var allParticipants = new List<Particapant>();
            allParticipants.AddRange(TeamOneParticipants);
            allParticipants.AddRange(TeamTwoParticipants);

            removeParticipantBtn.Visible = dzestSpeletaju.Visible
                = removeParticipant.Visible = allParticipants.Count > 0;

            foreach (var participant in allParticipants)
            {
                var teamName = participant.TeamId == SelectedTeamOne.Id
                    ? SelectedTeamOne.Name
                    : SelectedTeamTwo.Name;

                removeParticipant.Items.Add($"{participant.FirstName},{participant.LastName},{teamName}");
            }
        }

        private void ResetCreateGamePanel()
        {
            SelectedTeamOne = new Team();
            SelectedTeamTwo = new Team();

            TeamOneParticipants = new List<Particapant>();
            TeamTwoParticipants = new List<Particapant>();

            ShowCreateParticipantBlock(false);

            var teams = _teamService.GetTeams();
            selectedTeamOne.Items.Clear();
            selectedTeamTwo.Items.Clear();

            selectedTeamOne.Items.AddRange(teams);
            selectedTeamTwo.Items.AddRange(teams);
        }

        private void InitializeManagePanel()
        {
            placeInput.Text = timeInput.Text = reffereOne.Text =
                reffereTwo.Text = dateInput.Text = string.Empty;

            teamNameManage.Text = SelectedTeamOne.Name;
            teamNameTwoManage.Text = SelectedTeamTwo.Name;

            RadioButtons.Clear();

            int startY = 50;
            foreach (var player in TeamOneParticipants)
            {
                var radioButton = new RadioButton
                {
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)204)),
                    ForeColor = Color.Black,
                    Location = new Point(10, startY),
                    Name = player.Id.ToString(),
                    Size = new Size(150, 25),
                    Text = $"#{player.Number} {player.FirstName} {player.LastName}",
                    UseVisualStyleBackColor = true
                };

                radioButton.CheckedChanged += new EventHandler(SetActivePlayer);
                ManageGamePanel.Controls.Add(radioButton);
                RadioButtons.Add(radioButton);

                startY += 25;
            }

            startY = 310;
            foreach (var player in TeamTwoParticipants)
            {
                var radioButton = new RadioButton
                {
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
                    ForeColor = Color.Black,
                    Location = new Point(10, startY),
                    Name = player.Id.ToString(),
                    Size = new Size(150, 25),
                    Text = $"#{player.Number} {player.FirstName} {player.LastName}",
                    UseVisualStyleBackColor = true
                };

                radioButton.CheckedChanged += new EventHandler(SetActivePlayer);
                ManageGamePanel.Controls.Add(radioButton);
                RadioButtons.Add(radioButton);

                startY += 25;
            }
        }

        private void SetActivePlayer(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;

            if (int.TryParse(radio.Name, out int playerId))
            {
                var player = TeamOneParticipants.FirstOrDefault(f => f.Id == playerId);

                if (player == null)
                    player = TeamTwoParticipants.FirstOrDefault(f => f.Id == playerId);

                ActiveParticipant = player;
            }
        }

        private void AddPoint(int id, int teamId, int point)
        {
            if (id != 0)
            {
                if (teamId == SelectedTeamOne.Id)
                {
                    var currentPlayer = TeamOneParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (point > 0 || point < 0 && (currentPlayer.Points + point >= 0))
                        {
                            currentPlayer.Points += point;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
                else
                {
                    var currentPlayer = TeamTwoParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (point > 0 || point < 0 && (currentPlayer.Points + point >= 0))
                        {
                            currentPlayer.Points += point;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
            }

            UpdateStatisticOfTheGame();
        }

        private void AddFoul(int id, int teamId, int foul)
        {
            if (id != 0)
            {
                if (teamId == SelectedTeamOne.Id)
                {
                    var currentPlayer = TeamOneParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (foul > 0 || foul < 0 && (currentPlayer.Fouls + foul >= 0))
                        {
                            currentPlayer.Fouls += foul;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
                else
                {
                    var currentPlayer = TeamTwoParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (foul > 0 || foul < 0 && (currentPlayer.Fouls + foul >= 0))
                        {
                            currentPlayer.Fouls += foul;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
            }

            UpdateStatisticOfTheGame();
        }

        private void AddMissed(int id, int teamId, int missed)
        {
            if (id != 0)
            {
                if (teamId == SelectedTeamOne.Id)
                {
                    var currentPlayer = TeamOneParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (missed > 0 || missed < 0 && (currentPlayer.Missed + missed >= 0))
                        {
                            currentPlayer.Missed += missed;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
                else
                {
                    var currentPlayer = TeamTwoParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (missed > 0 || missed < 0 && (currentPlayer.Missed + missed >= 0))
                        {
                            currentPlayer.Missed += missed;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
            }

            UpdateStatisticOfTheGame();
        }

        private void AddAssist(int id, int teamId, int assist)
        {
            if (id != 0)
            {
                if (teamId == SelectedTeamOne.Id)
                {
                    var currentPlayer = TeamOneParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (assist > 0 || assist < 0 && (currentPlayer.Assisted + assist >= 0))
                        {
                            currentPlayer.Assisted += assist;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
                else
                {
                    var currentPlayer = TeamTwoParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (assist > 0 || assist < 0 && (currentPlayer.Assisted + assist >= 0))
                        {
                            currentPlayer.Assisted += assist;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
            }

            UpdateStatisticOfTheGame();
        }

        private void AddREB(int id, int teamId, int reb)
        {
            if (id != 0)
            {
                if (teamId == SelectedTeamOne.Id)
                {
                    var currentPlayer = TeamOneParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (reb > 0 || reb < 0 && (currentPlayer.REB + reb >= 0))
                        {
                            currentPlayer.REB += reb;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
                else
                {
                    var currentPlayer = TeamTwoParticipants.FirstOrDefault(f => f.Id == id);

                    if (currentPlayer != null)
                    {
                        if (reb > 0 || reb < 0 && (currentPlayer.REB + reb >= 0))
                        {
                            currentPlayer.REB += reb;
                            _participantService.Update(currentPlayer);
                        }
                    }
                }
            }

            UpdateStatisticOfTheGame();
        }

        private void UpdateStatisticOfTheGame()
        {
            foreach (var radiobtn in RadioButtons)
            {
                var allParticipants = new List<Particapant>();
                allParticipants.AddRange(TeamOneParticipants);
                allParticipants.AddRange(TeamTwoParticipants);

                var player = allParticipants.FirstOrDefault(f => f.Id == int.Parse(radiobtn.Name));

                radiobtn.Text = $"#{player.Number} {player.FirstName} {player.LastName} ({player.Points} PT, {player.Assisted} AST, {player.Missed} MSD, {player.REB} REB)";
                radiobtn.ForeColor = player.Fouls >= 5 ? Color.Red : Color.Black;
            }

            teamNameManage.Text = $"{SelectedTeamOne.Name} - {TeamOneParticipants.Sum(s => s.Points)} ({TeamOneParticipants.Sum(s => s.REB)} REB, {TeamOneParticipants.Sum(s => s.Missed)} MSD)";
            teamNameTwoManage.Text = $"{SelectedTeamTwo.Name} - {TeamTwoParticipants.Sum(s => s.Points)} ({TeamTwoParticipants.Sum(s => s.REB)} REB, {TeamTwoParticipants.Sum(s => s.Missed)} MSD)";
        }

        private void InitiliazeStatisticOfTheGame(int id)
        {
            teamOneStatistic.Text = teamTwoStatistic.Text = string.Empty;
            StatisticOfTheGamePanel.Controls.Add(teamOneStatistic);
            StatisticOfTheGamePanel.Controls.Add(teamTwoStatistic);

            var match = _matchService.GetMath(id);
            var startY = 60;

            if (match != null)
            {
                var participants = match.Participants.ToList();
                teamOneStatistic.Text = match.TeamOne.Name;
                teamTwoStatistic.Text = match.TeamTwo.Name;

                foreach (var pt in participants.Where(w => w.TeamId == match.TeamOneId))
                {
                    var label = new Label
                    {
                        AutoSize = true,
                        Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
                        ForeColor = Color.Black,
                        Location = new Point(10, startY),
                        Name = pt.Id.ToString(),
                        Size = new Size(200, 25),
                        Text = $"#{pt.Number} {pt.FirstName} {pt.LastName} - {pt.Points} Points ({pt.Missed} missed shots - {pt.Assisted} assists - {pt.REB} rebounds - {pt.Fouls} fouls)"
                    };

                    StatisticOfTheGamePanel.Controls.Add(label);
                    startY += 25;
                }

                startY = 310;
                foreach (var pt in participants.Where(w => w.TeamId == match.TeamTwoId))
                {
                    var label = new Label
                    {
                        AutoSize = true,
                        Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
                        ForeColor = Color.Black,
                        Location = new Point(10, startY),
                        Name = pt.Id.ToString(),
                        Size = new Size(200, 25),
                        Text = $"#{pt.Number} {pt.FirstName} {pt.LastName} - {pt.Points} Points ({pt.Missed} missed shots - {pt.Assisted} assists - {pt.REB} rebounds - {pt.Fouls} fouls)"
                    };

                    StatisticOfTheGamePanel.Controls.Add(label);
                    startY += 25;
                }
            }
            else
                messageLabel.Text = "Spēle neeksistē";

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
                ResetCreateGamePanel();
        }

        public void Exit(object sender, EventArgs e)
        {
            Close();
        }

        public void CreateNewGame(object sender, EventArgs e)
        {
            SetActivePanel(PanelType.CreateGame, "Izveidot Spēli", 185);

            ActiveMatch = _matchService.CreateMatch();

            ResetCreateGamePanel();
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
                var allParticipant = new List<Particapant>();
                allParticipant.AddRange(TeamOneParticipants);
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
                ActiveMatch.TeamOneId = SelectedTeamOne.Id;
                ActiveMatch.TeamTwoId = SelectedTeamTwo.Id;

                if (!string.IsNullOrEmpty(reffereOne.Text) && !string.IsNullOrEmpty(reffereTwo.Text))
                {
                    ActiveMatch.ReffereOne = reffereOne.Text;
                    ActiveMatch.ReffereTwo = reffereTwo.Text;

                    if (!string.IsNullOrEmpty(placeInput.Text))
                    {
                        ActiveMatch.Place = placeInput.Text;

                        if (DateTime.TryParse(dateInput.Text, out DateTime date))
                        {
                            var items = timeInput.Text.Split(':');

                            if (int.TryParse(items[0], out int hours) && int.TryParse(items[1], out int min))
                            {
                                date = date.AddHours(hours);
                                date = date.AddMinutes(min);

                                ActiveMatch.Date = date;
                                if (TeamOneParticipants.Count > 0 && TeamTwoParticipants.Count > 0)
                                {
                                    _matchService.UpdateMath(ActiveMatch);
                                    SetActivePanel(PanelType.StartGame, "Kontrolēt spēli", 185);
                                    InitializeManagePanel();
                                }
                                else
                                    messageLabel.Text = "Komandas sostavā nav spēlētāju!";
                            }
                            else
                                messageLabel.Text = "Nepareizs laika formāts!";
                        }
                        else
                            messageLabel.Text = "Nepareizs datuma formāts!";
                    }
                    else
                        messageLabel.Text = "Vieta bija tukša!";
                }
                else
                    messageLabel.Text = "Tiesnešu nav!";
            }
            else
                messageLabel.Text = "Izvēlaties komandas!";
        }

        public void GoToHome(object sender, EventArgs e)
        {
            SetActivePanel(PanelType.Home, "Galvenā", 70);
        }

        public void AddThreePoint(object sender, EventArgs e)
        {
            AddPoint(ActiveParticipant.Id, ActiveParticipant.TeamId, 3);
        }

        public void AddTwoPoint(object sender, EventArgs e)
        {
            AddPoint(ActiveParticipant.Id, ActiveParticipant.TeamId, 2);
        }

        public void AddOnePoint(object sender, EventArgs e)
        {
            AddPoint(ActiveParticipant.Id, ActiveParticipant.TeamId, 1);
        }

        public void RemoveThreePoint(object sender, EventArgs e)
        {
            AddPoint(ActiveParticipant.Id, ActiveParticipant.TeamId, -3);
        }

        public void RemoveTwoPoint(object sender, EventArgs e)
        {
            AddPoint(ActiveParticipant.Id, ActiveParticipant.TeamId, -2);
        }

        public void RemoveOnePoint(object sender, EventArgs e)
        {
            AddPoint(ActiveParticipant.Id, ActiveParticipant.TeamId, -1);
        }

        public void AddOneFoul(object sender, EventArgs e)
        {
            AddFoul(ActiveParticipant.Id, ActiveParticipant.TeamId, 1);
        }       

        public void RemoveOneFoul(object sender, EventArgs e)
        {
            AddFoul(ActiveParticipant.Id, ActiveParticipant.TeamId, -1);
        }

        public void AddOneMissed(object sender, EventArgs e)
        {
            AddMissed(ActiveParticipant.Id, ActiveParticipant.TeamId, 1);
        }

        public void RemoveOneMissed(object sender, EventArgs e)
        {
            AddMissed(ActiveParticipant.Id, ActiveParticipant.TeamId, -1);
        }

        public void AddOneAssist(object sender, EventArgs e)
        {
            AddAssist(ActiveParticipant.Id, ActiveParticipant.TeamId, 1);
        }

        public void RemoveOneAssist(object sender, EventArgs e)
        {
            AddAssist(ActiveParticipant.Id, ActiveParticipant.TeamId, -1);
        }

        public void AddOneREB(object sender, EventArgs e)
        {
            AddREB(ActiveParticipant.Id, ActiveParticipant.TeamId, 1);
        }       

        public void RemoveOneREB(object sender, EventArgs e)
        {
            AddREB(ActiveParticipant.Id, ActiveParticipant.TeamId, -1);
        }

        public void EndGame(object sender, EventArgs e)
        {
            SetActivePanel(PanelType.StatisticOfGame, "Statistika", 285);
            InitiliazeStatisticOfTheGame(ActiveMatch.Id);
        }        
    }
}
