using EP.BusinessLogic.Services;
using System;
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
            MessageLabel.Text = _teamService.CreateTeam(newTeamInput.Text)
                ? "Komanda tika izveidota"
                : "Kļuda, komanda ar to pašu nosaukuma jau eksistē";
        }
    }
}
