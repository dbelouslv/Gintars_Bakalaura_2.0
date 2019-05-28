using BS.BusinessLogic.Services;
using BS.EntityData.Context;
using BusinessLogic.Model;
using EntityData.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private string SelectedPath = string.Empty;
        private List<BasicModel> SaveMatches = new List<BasicModel>();

        public BasketballStats(ITeamService teamService, IParticapantService participantService, IMatchService matchService)
        {
            InitializeComponent();

            _teamService = teamService;
            _participantService = participantService;
            _matchService = matchService;

            SaveMatches = _matchService.GetMatchesForSaving();

            InitiliazeHomeStatistic();

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
                    Controls.Remove(PDFPanel);
                    break;
                case PanelType.StartGame:
                    Controls.Add(ManageGamePanel);
                    Controls.Remove(HomePanel);
                    Controls.Remove(CreateGamePanel);
                    Controls.Remove(StatisticOfTheGamePanel);
                    Controls.Remove(PDFPanel);
                    break;
                case PanelType.StatisticOfGame:
                    Controls.Add(StatisticOfTheGamePanel);
                    Controls.Remove(HomePanel);
                    Controls.Remove(CreateGamePanel);
                    Controls.Remove(ManageGamePanel);
                    Controls.Remove(PDFPanel);
                    break;
                case PanelType.SaveStatistic:
                    Controls.Add(PDFPanel);
                    Controls.Remove(HomePanel);
                    Controls.Remove(CreateGamePanel);
                    Controls.Remove(ManageGamePanel);
                    Controls.Remove(StatisticOfTheGamePanel);
                    break;
                default:
                    Controls.Add(HomePanel);
                    Controls.Remove(CreateGamePanel);
                    Controls.Remove(ManageGamePanel);
                    Controls.Remove(StatisticOfTheGamePanel);
                    Controls.Remove(PDFPanel);
                    break;
            }
        }

        private void ShowCreateParticipantBlock(bool isShow)
        {
            izveidotSpeletaju.Visible = izveidotLabel.Visible = nameInput.Visible = surnameInput.Visible =
                numberInput.Visible = savePlayerBtn.Visible = selectedTeams.Visible = teamOneName.Visible =
                teamTwoName.Visible = teamTwoRoster.Visible = teamOneRoster.Visible = toManageGameBtn.Visible =
                importBtn.Visible = isShow;

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
            ManageGamePanel.Controls.Clear();
            ManageGamePanel.Controls.Add(endGameBtn);
            ManageGamePanel.Controls.Add(removeFoulBtn);
            ManageGamePanel.Controls.Add(addFoulBtn);
            ManageGamePanel.Controls.Add(removeRebBtn);
            ManageGamePanel.Controls.Add(addRebBtn);
            ManageGamePanel.Controls.Add(removeAssistBtn);
            ManageGamePanel.Controls.Add(addAssistBtn);
            ManageGamePanel.Controls.Add(removeMissedBtn);
            ManageGamePanel.Controls.Add(addMissedBtn);
            ManageGamePanel.Controls.Add(removeOneBtn);
            ManageGamePanel.Controls.Add(addOneBtn);
            ManageGamePanel.Controls.Add(removeTwoBtn);
            ManageGamePanel.Controls.Add(addTwoBtn);
            ManageGamePanel.Controls.Add(removeThreeBtn);
            ManageGamePanel.Controls.Add(addThreeBtn);
            ManageGamePanel.Controls.Add(teamNameTwoManage);
            ManageGamePanel.Controls.Add(teamNameManage);

            ActiveParticipant = new Particapant();

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
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)204)),
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
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
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
                radiobtn.Enabled = player.Fouls < 5;
            }

            teamNameManage.Text = $"{SelectedTeamOne.Name} - {TeamOneParticipants.Sum(s => s.Points)} ({TeamOneParticipants.Sum(s => s.REB)} REB, {TeamOneParticipants.Sum(s => s.Missed)} MSD)";
            teamNameTwoManage.Text = $"{SelectedTeamTwo.Name} - {TeamTwoParticipants.Sum(s => s.Points)} ({TeamTwoParticipants.Sum(s => s.REB)} REB, {TeamTwoParticipants.Sum(s => s.Missed)} MSD)";
        }

        private void InitiliazeStatisticOfTheGame(int id)
        {
            teamOneStatistic.Text = teamTwoStatistic.Text = string.Empty;
            StatisticOfTheGamePanel.Controls.Add(teamOneStatistic);
            StatisticOfTheGamePanel.Controls.Add(teamTwoStatistic);

            var match = _matchService.GetMatch(id);
            var startY = 60;

            if (match != null)
            {
                var participants = match.Participants.ToList();
                teamOneStatistic.Text = match.TeamOne.Name + $" - {match.Participants.Where(w => w.TeamId == match.TeamOneId).Sum(s => s.Points)}";
                teamTwoStatistic.Text = match.TeamTwo.Name + $" - {match.Participants.Where(w => w.TeamId == match.TeamTwoId).Sum(s => s.Points)}";

                foreach (var pt in participants.Where(w => w.TeamId == match.TeamOneId))
                {
                    var label = new Label
                    {
                        AutoSize = true,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
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
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
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

        private void InitiliazeSaveMathces()
        {
            PDFPanel.Controls.Clear();
            PDFPanel.Controls.Add(mapeLabel);
            PDFPanel.Controls.Add(mapeBtn);

            int startY = 120;
            foreach (var match in SaveMatches)
            {
                var label = new Label
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)204)),
                    ForeColor = Color.Black,
                    Location = new Point(230, startY),
                    Name = match.Id.ToString(),
                    Size = new Size(300, 25),
                    Text = match.Name,
                    Cursor = Cursors.Hand
                };

                label.Click += new EventHandler(SavePdf);
                PDFPanel.Controls.Add(label);

                startY += 30;
            }
        }

        private void SavePdf(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedPath))
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Izvēlaties mapi!";
                return;
            }

            messageLabel.Text = string.Empty;

            var label = (Label)sender;

            if (int.TryParse(label.Name, out int matchId))
            {
                var match = _matchService.GetMatch(matchId);

                if (match != null)
                {                   
                    var path = SelectedPath + $"\\{label.Text.Replace(' ','_').Replace(':','-')}.pdf";
                    var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                    var doc = new Document();
                    var writer = PdfWriter.GetInstance(doc, fs);

                    var teamOnePoints = match.Participants.Where(w => w.Team.Id == match.TeamOneId).Sum(s => s.Points);
                    var teamTwoPoints = match.Participants.Where(w => w.Team.Id == match.TeamTwoId).Sum(s => s.Points);

                    var rosterOfFirstTeam = match.Participants.Where(w => w.Team.Id == match.TeamOneId).OrderByDescending(o => o.Points).ToList();
                    var rosterOfSecondTeam = match.Participants.Where(w => w.Team.Id == match.TeamTwoId).OrderByDescending(o => o.Points).ToList();

                    doc.Open();

                    doc.Add(new Paragraph($"Datums: { match.Date.Value.ToShortDateString() }"));
                    doc.Add(new Paragraph($"Laiks: { match.Date.Value.ToShortTimeString() }"));
                    doc.Add(new Paragraph($"Vieta: { match.Place }"));                    
                    doc.Add(new Paragraph($"Tiesneši: { match.ReffereOne } un { match.ReffereTwo }"));

                    var beforeTop = new Paragraph($"{match.TeamOne.Name} - {teamOnePoints}", new iTextSharp.text.Font { Size = 20 })
                    {
                        SpacingBefore = 50,
                        SpacingAfter = 15
                    };
                    doc.Add(beforeTop);

                    foreach (var player in rosterOfFirstTeam)
                        doc.Add(new Paragraph($"#{player.Number} {player.FirstName} {player.LastName} - {player.Points} Points ({player.Missed} missed shots - {player.Assisted} assists - {player.REB} rebounds - {player.Fouls} fouls)", new iTextSharp.text.Font { Size = 12 }));

                    beforeTop = new Paragraph($"{match.TeamTwo.Name} - {teamTwoPoints}", new iTextSharp.text.Font { Size = 20 })
                    {
                        SpacingBefore = 15,
                        SpacingAfter = 15
                    };
                    doc.Add(beforeTop);

                    foreach (var player in rosterOfSecondTeam)
                        doc.Add(new Paragraph($"#{player.Number} {player.FirstName} {player.LastName} - {player.Points} Points ({player.Missed} missed shots - {player.Assisted} assists - {player.REB} rebounds - {player.Fouls} fouls)", new iTextSharp.text.Font { Size = 12 }));

                    beforeTop = new Paragraph($"{match.ReffereOne} _____________________", new iTextSharp.text.Font { Size = 12 })
                    {
                        SpacingBefore = 150,
                    };
                    doc.Add(beforeTop);

                    beforeTop = new Paragraph($"{match.ReffereTwo} _____________________", new iTextSharp.text.Font { Size = 12 })
                    {
                        SpacingBefore = 15,
                    };
                    doc.Add(beforeTop);

                    doc.Close();
                    writer.Close();
                    fs.Close();

                    messageLabel.ForeColor = Color.Green;
                    messageLabel.Text = $"Statistika spēli {label.Text} tika saglabāta";
                }
                else
                    messageLabel.Text = "Spēle neeksistē";
            }
        }

        private void InitiliazeHomeStatistic()
        {
            HomePanel.Controls.Clear();
            HomePanel.Controls.Add(label2);
            HomePanel.Controls.Add(pedejasLabel);
            HomePanel.Controls.Add(sortDate);
            HomePanel.Controls.Add(button1);

            int startY = 120;
            foreach (var match in SaveMatches)
            {
                var label = new Label
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204),
                    ForeColor = Color.Black,
                    Location = new Point(15, startY),
                    Name = match.Id.ToString(),
                    Size = new Size(300, 25),
                    Text = match.Name,
                    Cursor = Cursors.Hand
                };

                label.Click += new EventHandler(ShowStatistic);
                HomePanel.Controls.Add(label);

                startY += 30;
            }
        }

        public void ShowStatistic(object sender, EventArgs e)
        {
            var label = (Label)sender;

            if (int.TryParse(label.Name, out int id))
            {
                SetActivePanel(PanelType.StatisticOfGame, $"{label.Text}", 285);
                InitiliazeStatisticOfTheGame(id);
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

                var teamId = SelectedTeamOne.Name == teamName 
                    ? SelectedTeamOne.Id 
                    : SelectedTeamTwo.Id;

                var currentPlayer = allParticipant
                    .FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName && f.TeamId == teamId);

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
                    messageLabel.Text = "Spēlētājs tika dzēsts";
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

                            if (int.TryParse(items[0], out int hours))
                            {
                                date = date.AddHours(hours);

                                if (items.Length == 2 && int.TryParse(items[1], out int min))
                                {
                                    date = date.AddMinutes(min);
                                }

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
            SaveMatches = _matchService.GetMatchesForSaving();

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
            StatisticOfTheGamePanel.Controls.Clear();
            InitiliazeStatisticOfTheGame(ActiveMatch.Id);
        }

        public void GoToPrintStatistic(object sender, EventArgs e)
        {
            SelectedPath = string.Empty;

            SaveMatches = _matchService.GetMatchesForSaving();

            SetActivePanel(PanelType.SaveStatistic, "Saglabāt statistiku", 400);

            InitiliazeSaveMathces();
        }       

        public void SeleceFolder(object sender, EventArgs e)
        {
            if (selectFolder.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = selectFolder.SelectedPath;
                mapeLabel.Text = SelectedPath;
            }
        }

        private void OpenStatisticPanel(object sender, EventArgs e)
        {
            SetActivePanel(PanelType.StatisticOfGame, "Statistika", 285);

            if (ActiveMatch.Id != 0 && SelectedTeamOne.Id != 0 && SelectedTeamTwo.Id != 0
                && TeamOneParticipants.Count > 0 && TeamTwoParticipants.Count > 0)
            {
                StatisticOfTheGamePanel.Controls.Clear();
                InitiliazeStatisticOfTheGame(ActiveMatch.Id);
            }
            else
            {
                if (teamOneStatistic.Text.Length == 0)
                {
                    messageLabel.ForeColor = Color.Red;
                    messageLabel.Text = "Kļūda! Izvēlaties spēli!";
                }
            }
        }

        public void OnlyLetters(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void ImportParticipants(object sender, EventArgs e)
        {
            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                var excels = new List<string>() { ".csv" };

                if (excels.Contains(Path.GetExtension(openExcel.FileName)))
                {
                    var reader = new StreamReader(openExcel.FileName);
                    string line = string.Empty;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var items = line.Split(';');

                        if (items.Length == 4)
                        {
                            var hasErrors = false;

                            if (string.IsNullOrEmpty(items[0]))
                                hasErrors = true;

                            if (string.IsNullOrEmpty(items[1]))
                                hasErrors = true;

                            if (string.IsNullOrEmpty(items[2]))
                                hasErrors = true;

                            if (string.IsNullOrEmpty(items[3]))
                                hasErrors = true;

                            if (!int.TryParse(items[2], out int number))
                                hasErrors = true;

                            var teamId = items[3] == SelectedTeamOne.Name
                                ? SelectedTeamOne.Id
                                : SelectedTeamTwo.Id;

                            if (teamId == SelectedTeamOne.Id)
                            {
                                if (TeamOneParticipants.Any(a => a.Number == number))
                                    hasErrors = true;
                            }
                            else
                            {
                                if (TeamTwoParticipants.Any(a => a.Number == number))
                                    hasErrors = true;
                            }

                            if (!hasErrors)
                            {
                                var currentPlayer = _participantService
                                    .CreateParticipant(items[0], items[1], number, teamId, ActiveMatch.Id);

                                if (teamId == SelectedTeamOne.Id)
                                    TeamOneParticipants.Add(currentPlayer);
                                else
                                    TeamTwoParticipants.Add(currentPlayer);

                                selectedTeams.Text = nameInput.Text = surnameInput.Text = numberInput.Text = string.Empty;

                                UpdateRosterLabels();
                            }
                        }
                    }
                }
            }
        }

        public void SortByDate(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;

            if (string.IsNullOrEmpty(sortDate.Text))
            {
                SaveMatches = _matchService.GetMatchesForSaving();
                InitiliazeHomeStatistic();
            }
            else if (DateTime.TryParse(sortDate.Text, out DateTime date))
            {
                SaveMatches = _matchService.GetMatchesForSaving(date);
                InitiliazeHomeStatistic();
            }
            else
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Nepareiz datums formāts";
            }
        }
    }
}
