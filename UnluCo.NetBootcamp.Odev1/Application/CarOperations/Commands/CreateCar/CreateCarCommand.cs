using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.NetBootcamp.Odev1.DBOperations;
using UnluCo.NetBootcamp.Odev1.Entities.Concrete;
using UnluCo.NetBootcamp.Odev1.Services;

namespace UnluCo.NetBootcamp.Odev1.Application.CarOperations.Commands.CreateCar
{
    public class CreateCarCommand
    {
        public CreateCarModel Model { get; set; }
        private readonly CarSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCarCommand(CarSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var car = _dbContext.Cars.SingleOrDefault(x => x.BrandId == Model.BrandId && x.ModelName == Model.ModelName);//CarSystemDbContext altinda tanimli Cars listesinde Modele ait BrandId ve ModelName ile eslesen kayit var mi diye kontrol eder. Birden fazla eslesme olursa hata verir. 
            if (car is not null)
                throw new InvalidOperationException("Arac sistemde kayitli!");
            car = _mapper.Map<Car>(Model); //Model ile gelen bilgileri Car nesnesine map et/esle. 
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }
        public class CreateCarModel
        {
            public int BrandId { get; set; }
            public string Color { get; set; }
            public string ModelName { get; set; }
            public int ModelYear { get; set; }
            public bool IsActive { get; set; }

            [Required(ErrorMessage = "Şifre girilmesi zorunlu!")]
            [Auth(MinLength = 5)]//Password kontrol islemi icin opsiyonel parametre verildi
            public string Password { get; set; }
        }
    }
}
