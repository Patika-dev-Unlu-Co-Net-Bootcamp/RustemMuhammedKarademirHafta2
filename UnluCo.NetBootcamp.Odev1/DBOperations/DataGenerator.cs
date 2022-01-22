using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.NetBootcamp.Odev2.Entities.Concrete;

namespace UnluCo.NetBootcamp.Odev2.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CarSystemDbContext(serviceProvider.GetRequiredService<DbContextOptions<CarSystemDbContext>>()))
            {
                if (context.Cars.Any())
                {
                    return;
                }
                context.Cars.AddRange(
                    new Car { BrandId = 1, Color = "Mavi", ModelName = "5.2", ModelYear = 2015},
                    new Car { BrandId = 2, Color = "Kırmızı", ModelName = "A3", ModelYear = 2020},
                    new Car { BrandId = 3, Color = "Siyah", ModelName = "Auris", ModelYear = 2014 },
                    new Car { BrandId = 4, Color = "Beyaz", ModelName = "c180", ModelYear = 2018, IsActive = false }
                );
                context.SaveChanges();

                if (context.Brands.Any())
                {
                    return;
                }
                context.Brands.AddRange(
                    new Brand { BrandName = "BMW" },
                    new Brand { BrandName = "Audi" },
                    new Brand { BrandName = "Toyota" },
                    new Brand { BrandName = "Mercedes" }
                );
                context.SaveChanges();
            }
        }
    }
}
