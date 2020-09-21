using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departament.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any()){
                return; // DB já foi populado
            }

            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Eletronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green ", "maria@gmail.com", new DateTime(1999, 5, 24), 1000.0, d1);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1997, 6, 23), 1000.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1995, 7, 22), 1000.0, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SalesStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 26), 11100.0, SalesStatus.Billed, s1);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 10, 27), 11110.0, SalesStatus.Billed, s1);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 11, 28), 11111.0, SalesStatus.Billed, s1);

            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecord.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();
        }
    }
}


