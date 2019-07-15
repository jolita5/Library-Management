using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.ViewModel;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public HomeController(IAuthorRepository authorRepository, ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var homeVM = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x => true),
                BookCount = _bookRepository.Count(x => true),
                LendBookCount = _bookRepository.Count(x => x.Borrower != null)
            };

            return View(homeVM);
        }

       
    }
}
