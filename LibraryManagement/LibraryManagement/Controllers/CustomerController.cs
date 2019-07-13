
using LibraryManagement.Data.Interfaces;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();
            var customers = _customerRepository.GetAll();

            if(customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach(var customer in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _bookRepository.Count(x => x.BorrowerId == customer.CustomerId)
                });

            }

            return View(customerVM);
        }
    }
}
