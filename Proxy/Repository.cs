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

        PortfolioItem GetById(int id);

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
            _portfolioItemViewModel.Add(item);
        }

        public void Delete(int id)
        {
            var model = _portfolioItemViewModel.Find(c => c.ItemId == id);
            _portfolioItemViewModel.Remove(model);
        }

        public void Edit(PortfolioItem item)
        {
            var model = _portfolioItemViewModel.Find(c => c.ItemId == item.ItemId);
            model.Symbol = item.Symbol;

            throw new NotImplementedException();
        }

        public IEnumerable<PortfolioItem> GetAll()
        {
            return _portfolioItems;
           // return _portfolioItemViewModel;
        }

        public PortfolioItem GetById(int id)
        {
            var item = _portfolioItemViewModel.Find(c=>c.ItemId == id);
            return item;
        }
    }
}
