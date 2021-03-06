﻿using System.Collections.Generic;
using System.Web.Http;
using PortfolioManagerClient.Models;
using PortfolioManagerClient.Services;
using Proxy;
using PortfolioManagerClient.Converters;

namespace PortfolioManagerClient.Controllers
{
    /// <summary>
    /// Processes portfolio item requests.
    /// </summary>
    public class PortfolioItemsController : ApiController
    {
        private readonly PortfolioItemsService _portfolioItemsService = new PortfolioItemsService();
        private readonly UsersService _usersService = new UsersService();
        private List<PortfolioItemViewModel> _portfolioItemViewModel = new List<PortfolioItemViewModel>();
        private MediatorService _mediatorService ;
        

        public PortfolioItemsController()
        {
            _mediatorService =  new MediatorService(_usersService.GetOrCreateUser());
            _portfolioItemViewModel = _mediatorService.GetAllLocal().PortfolioItemsToPortfolioItemViewModels();
        }
        /// <summary>
        /// Returns all portfolio items for the current user.
        /// </summary>
        /// <returns>The list of portfolio items.</returns>
        [Route ("api/PortfolioItems/GetLocal")]
        public IList<PortfolioItemViewModel> GetLocal()
        {

            var userId = _usersService.GetOrCreateUser();
            
            // return _portfolioItemsService.GetItems(userId).PortfolioItemsToPortfolioItemViewModels();
            return _mediatorService.GetAllLocal().PortfolioItemsToPortfolioItemViewModels();
        }

        [Route("api/PortfolioItems/GetRemote")]
        public void GetRemote()
        {

            var userId = _usersService.GetOrCreateUser();

            // return _portfolioItemsService.GetItems(userId).PortfolioItemsToPortfolioItemViewModels();
             _mediatorService.GetAllRemote();//.PortfolioItemsToPortfolioItemViewModels();
        }

        /// <summary>
        /// Updates the existing portfolio item.
        /// </summary>
        /// <param name="portfolioItem">The portfolio item to update.</param>
        public void Put(PortfolioItemViewModel portfolioItem)
        {
            _mediatorService.Edit(portfolioItem.PortfolioItemViewModelToPortfolioItem());
            //portfolioItem.UserId = _usersService.GetOrCreateUser();
            //_portfolioItemsService.UpdateItem(portfolioItem.PortfolioItemViewModelToPortfolioItem());
        }

        /// <summary>
        /// Deletes the specified portfolio item.
        /// </summary>
        /// <param name="id">The portfolio item identifier.</param>
        public void Delete(int id)
        {
            _mediatorService.Delete(id);
            //_portfolioItemsService.DeleteItem(id);
        }

        /// <summary>
        /// Creates a new portfolio item.
        /// </summary>
        /// <param name="portfolioItem">The portfolio item to create.</param>
        public void Post(PortfolioItemViewModel portfolioItem)
        {
          //  _portfolioItemsService.CreateItem(portfolioItem.PortfolioItemViewModelToPortfolioItem());

            _mediatorService.Create(portfolioItem.PortfolioItemViewModelToPortfolioItem());
        }
    }
}
