namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PortfolioDbModel : DbContext
    {

        public PortfolioDbModel()
            : base("name=PortfolioDbModel")
        {
        }


        DbSet<PortfolioItem> PortfolioItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }


}