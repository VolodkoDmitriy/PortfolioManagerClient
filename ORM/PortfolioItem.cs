namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PortfolioItem
    {
        public int? ItemId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string Symbol { get; set; }

        public int? SharesNumber { get; set; }

        public int Id { get; set; }
    }
}
