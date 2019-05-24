namespace BS.EntityData.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Team")]
    public partial class Team
    {
        public Team()
        {
            Participants = new List<Particapant>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ICollection<Particapant> Participants { get; set; }
    }
}
