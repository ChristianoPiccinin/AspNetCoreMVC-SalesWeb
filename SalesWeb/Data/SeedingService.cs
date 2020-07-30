using Microsoft.EntityFrameworkCore.Internal;
using SalesWeb.Models;
using SalesWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SalesWeb.Data
{
    public class SeedingService
    {
        //registrar uma dependencia
        private SalesWebContext _context;

        public SeedingService(SalesWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.SalesRecord.Any() ||
                _context.Seller.Any())
            {
                return;
            }


            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1,"Maria","maria@email.com", new DateTime(1998,05,23), 1000, d1);
            Seller s2 = new Seller(2, "Ana", "ana@email.com", new DateTime(2000, 05, 23), 5000, d2);
            Seller s3 = new Seller(3, "Beatriz", "beatriz@email.com", new DateTime(1996, 05, 23), 1500, d3);
            Seller s4 = new Seller(4, "Camila", "camila@email.com", new DateTime(2001, 05, 23), 2000, d1);
            Seller s5 = new Seller(5, "Elen", "elen@email.com", new DateTime(2002, 05, 23), 4000, d2);
            Seller s6 = new Seller(6, "Rafaela", "rafaela@email.com", new DateTime(1999, 05, 23), 3000, d4);

            SalesRecord sr1 = new SalesRecord(1,new DateTime(2020,07,29),5000,SalesStatus.Billed,s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2020, 07, 29), 2000, SalesStatus.Pending, s1);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2020, 07, 29), 1000, SalesStatus.Pending, s6);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2020, 07, 29), 2000, SalesStatus.Canceled, s1);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2020, 07, 29), 3000, SalesStatus.Billed, s1);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2020, 07, 29), 4000, SalesStatus.Billed, s2);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2020, 07, 29), 6000, SalesStatus.Canceled, s3);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2020, 07, 29), 5000, SalesStatus.Billed, s4);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2020, 07, 29), 6000, SalesStatus.Billed, s5);




            _context.Department.AddRange(d1,d2,d3,d4);
            _context.Seller.AddRange(s1,s2,s3,s4,s5,s6);
            _context.SalesRecord.AddRange(sr1,sr2,sr3,sr4,sr5,sr6,sr7,sr8,sr9);

            _context.SaveChanges();


        }

    }
}
