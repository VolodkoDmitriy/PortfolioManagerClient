using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace Proxy
{


    public class MediatorService { 

        private IRepository _repositoryService;
        private PortfolioItemsService _remoteService;
        private int _userId;

        public MediatorService(int userId)
        {
            _remoteService = new PortfolioItemsService();
            _repositoryService = new Repository();
            _userId = userId;
        }

        public void Create(PortfolioItem item)
        {
            item.UserId = _userId;
            _repositoryService.Create(item);
            //_remoteService.CreateItem(item);
        }

        public void Edit(PortfolioItem item)
        {
            item.UserId = _userId;
            _repositoryService.Edit(item);
        }

        public void Delete(int id)
        {
            _repositoryService.Delete(id);
        }


        public IEnumerable<PortfolioItem> GetAllLocal()
        {
            return _repositoryService.GetAll();
        }

        public IEnumerable<PortfolioItem> GetAllRemote()
        {
            return _repositoryService.GetAll();
        }
    }
}
