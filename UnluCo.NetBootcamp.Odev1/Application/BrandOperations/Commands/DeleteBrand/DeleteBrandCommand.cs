﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.NetBootcamp.Odev1.DBOperations;

namespace UnluCo.NetBootcamp.Odev1.BrandOperations.DeleteBrand
{
    public class DeleteBrandCommand
    {
        private readonly CarSystemDbContext _dbContext;
        public int brandId { get; set; }
        public DeleteBrandCommand(CarSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var brand = _dbContext.Brands.Find(brandId);
            if (brand is null)
                throw new InvalidOperationException("Marka sistemde kayitli degil!");
            _dbContext.Brands.Remove(brand);
            _dbContext.SaveChanges();
        }
    }
}
