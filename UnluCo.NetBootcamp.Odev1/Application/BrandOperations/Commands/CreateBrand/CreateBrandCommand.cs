﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.NetBootcamp.Odev1.DBOperations;
using UnluCo.NetBootcamp.Odev1.Entities.Concrete;
using UnluCo.NetBootcamp.Odev1.Services;

namespace UnluCo.NetBootcamp.Odev1.BrandOperations.CreateBrand
{
    public class CreateBrandCommand
    {
        public CreateBrandModel Model { get; set; }
        private readonly CarSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBrandCommand(CarSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Brands.SingleOrDefault(x => x.BrandName == Model.BrandName);//CarSystemDbContext altinda tanimli Brands listesinde Modele ait BrandName ile eslesen kayit var mi diye kontrol eder. Birden fazla eslesme olursa hata verir. 
            if (book is not null)
                throw new InvalidOperationException("Marka sistemde kayitli!");
            book = _mapper.Map<Brand>(Model); //Model ile gelen bilgileri Brand nesnesine map et/esle. 
            _dbContext.Brands.Add(book);
            _dbContext.SaveChanges();
        }
        public class CreateBrandModel
        {
            public string BrandName { get; set; }

            [Required(ErrorMessage = "Şifre girilmesi zorunlu!")]
            [Auth(MinLength = 5)]//Password kontrol islemi icin opsiyonel parametre verildi
            public string Password { get; set; }
        }
    }
}
