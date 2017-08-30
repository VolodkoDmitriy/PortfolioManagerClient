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
                SharesNumber = c.SharesNymber,
                Symbol = c.Symbol,
                UserId = c.UserId,
            }).ToList();

            return result;
        }
    }
}