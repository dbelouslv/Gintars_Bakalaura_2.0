namespace BS.EntityData.Context
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Particapant")]
    public partial class Particapant
    {
        public int Id { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Number { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int Points { get; set; }

        public int REB { get; set; }

        public int Missed { get; set; }

        public int Assisted { get; set; }

        public int Fouls { get; set; }
    }
}
