﻿using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base (context)
        {

        }

        public IEnumerable<Author> GetAllWithBooks()
        {
            return _context.Authors.Include(a => a.Books);
        }

        public Author GetWithBooks(int id)
        {
            return _context.Authors
                .Where(a => a.AuthorId == id)
                .Include(a => a.Books)
                .FirstOrDefault();
        }
    }
}
