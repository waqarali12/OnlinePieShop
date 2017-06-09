using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlinePieShop.Models;
using OnlinePieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlinePieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            categoryRepository = _categoryRepository;
        }

        public ViewResult List()
        {
            PieListViewModel pieListViewModel = new PieListViewModel()
            {
                Pies = _pieRepository.Pies,
                CurrentCategory = "Cheese Cake!"
            };  
            return View(pieListViewModel);
        }
    }
}
