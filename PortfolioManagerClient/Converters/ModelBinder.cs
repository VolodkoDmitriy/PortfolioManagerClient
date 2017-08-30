using ORM;
using PortfolioManagerClient.Models;
using Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManagerClient.Converters
{
    public static class ModelBinder
    {
        public static List<PortfolioItemViewModel> PortfolioItemsToPortfolioItemViewModels(this IEnumerable<PortfolioItem> list)
        {
            var result =  list.Select(c => new PortfolioItemViewModel
            {
                ItemId = c.ItemId,
                SharesNumber = c.SharesNumber,
                Symbol = c.Symbol,
                UserId = c.UserId,
            }).ToList();

            return result;
        }

        public static PortfolioItemViewModel PortfolioItemToPortfolioItemViewModel(this PortfolioItem item)
        {
            return new PortfolioItemViewModel
            {
                ItemId = item.ItemId,
                SharesNumber = item.SharesNumber,
                Symbol = item.Symbol,
                UserId = item.UserId,
            };
        }

        public static PortfolioItem PortfolioItemViewModelToPortfolioItem(this PortfolioItemViewModel item)
        {
            return new PortfolioItem
            {
                ItemId = item.ItemId,
                SharesNumber = item.SharesNumber,
                Symbol = item.Symbol,
                UserId = item.UserId,
            };
        }
    }
}