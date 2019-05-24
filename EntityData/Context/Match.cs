namespace BS.EntityData.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Match")]
    public partial class Match
    {
        public Match()
        {
            Participants = new List<Particapant>();
        }

        public int Id { get; set; }

        public string Place { get; set; }

        public string ReffereOne { get; set; }

        public string ReffereTwo { get; set; }

        public int? TeamOneId { get; set; }
        public virtual Team TeamOne { get; set; }

        public int? TeamTwoId { get; set; }
        public virtual Team TeamTwo { get; set; }

        public DateTime? Date { get; set; }

        public virtual ICollection<Particapant> Participants { get; set; }
    }
}
