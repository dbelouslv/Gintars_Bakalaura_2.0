using EP.BusinessLogic.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BasketballStats
{
    public partial class BasketballStats : Form
    {
        private readonly ITeamService _teamService;

        public BasketballStats(ITeamService teamService)
        {
            InitializeComponent();

            _teamService = teamService;
        }

        public void CreateTeam(object sender, EventArgs e)
        {
            var success = _teamService.CreateTeam(newTeamInput.Text);

            MessageLabel.Text = success ? "Komanda tika izveidota" : "Kļūda, komanda ar šādu nosaukumu jau eksistē";
            MessageLabel.ForeColor = success ? Color.Green : Color.Red;
        }

        public void Exit(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateNewGame(object sender, EventArgs e)
        {

        }
    }
}
