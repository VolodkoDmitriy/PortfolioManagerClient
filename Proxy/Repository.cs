using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ORM;

namespace Proxy
{
    public interface IRepository {

        void Create(PortfolioItem item);

        void Edit(PortfolioItem item);

        void Delete(int id);

        IEnumerable<PortfolioItem> GetAll();

    }


    public class Repository: IRepository
    {

        private readonly DbContext _context;
        private readonly DbSet<PortfolioItem> _portfolioItems;

        public Repository()
        {
            _context = new PortfolioDbModel();
            _portfolioItems = _context.Set<PortfolioItem>();
        }

        private List<PortfolioItem> _portfolioItemViewModel = new List<PortfolioItem>();

        public void Create(PortfolioItem item)
        {
            _portfolioItems.Add(item);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _portfolioItems.FirstOrDefault(c=>c.ItemId == id);
            _portfolioItems.Remove(model);
            SaveChanges();
        }

        public void Edit(PortfolioItem item)
        {
            var model = _portfolioItems.FirstOrDefault(c => c.ItemId == item.ItemId);
            model.Symbol = item.Symbol;
            model.SharesNumber = item.SharesNumber;
            model.UserId = item.UserId;
            SaveChanges();
        }

        public IEnumerable<PortfolioItem> GetAll()
        {
            return _portfolioItems;
        }


        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
