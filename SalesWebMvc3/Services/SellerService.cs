using SalesWebMvc3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc3.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc3.Models;
using SalesWebMvc3.Services.Exceptions;

namespace SalesWebMvc3.Services
{
    public class SellerService
    {
        private readonly SalesWebMvc3Context _context;

        public SellerService(SalesWebMvc3Context context)
        {
            _context = context;
        }


        public List<Saller> FindAll()
        {
            return _context.Saller.ToList();
        }
        public void Insert(Saller obj)
        {

            _context.Add(obj);
            _context.SaveChanges();
        }

        public Saller FindById(int id)
        {
            return _context.Saller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Saller.Find(id);
            _context.Saller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Saller obj)
        {
            if (!_context.Saller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        
        }

    }
}
