using LibraryManagement.Data.Model;
using System.Collections.Generic;


namespace LibraryManagement.ViewModel
{
    public class LendViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
