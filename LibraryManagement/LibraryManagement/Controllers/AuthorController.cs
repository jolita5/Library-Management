using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {

        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [Route("Author")]

        public IActionResult List()
        {
            var authors = _authorRepository.GetAllWithBooks();

            if(authors.Count() == 0)
            {
                return View("Empty");
            }

            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Author author)
        {
            _authorRepository.Create(author);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var author = _authorRepository.GetById(id);

            if(author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]

        public IActionResult Update(Author author)
        {
            _authorRepository.Update(author);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var author = _authorRepository.GetById(id);

           _authorRepository.Delete(author);

            return RedirectToAction("List");
        }
    }
}
