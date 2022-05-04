using AppShopping.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System.Collections.Generic;

namespace AppShopping.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public NewsService _newsService { get; set; }
        public List<News> News { get; set; }
        public NewsViewModel()
        {
            _newsService = new NewsService();

            News = _newsService.GetNews();
        }
    }
}
