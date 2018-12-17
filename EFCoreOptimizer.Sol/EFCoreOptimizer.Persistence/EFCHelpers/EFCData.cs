using EFCoreOptimizer.Domain;
using EFCoreOptimizer.Persistence.Context;
using System.Collections.Generic;

namespace EFCoreOptimizer.Persistence.EFCHelpers
{
    public static class EfcData
    {
        public static void SeedDatabaseProducts(this DataContext dataContext)
        {
            dataContext.Products.AddRange(CreateProducts());
            dataContext.SaveChanges();
        }

        private static IEnumerable<Product> CreateProducts() =>
            new List<Product>(new Product[]
            {
                new Product
                {
                    Name = "Product 1", Description = "Descrpition 1", Price = 10,
                    Reviews = new List<Review>(new Review[]
                    {
                        new Review
                        {
                            Stars = 3,
                            VoterName = "Dr. Slump"
                        },
                        new Review
                        {
                            Stars = 5,
                            VoterName = "Arale"
                        },
                        new Review
                        {
                            Stars = 1,
                            VoterName = "Yamabuki"
                        }
                    })
                },
                new Product
                {
                    Name = "Product 2", Description = "Description 2", Price = 20,
                    Reviews = new List<Review>(new Review[]
                    {
                        new Review
                        {
                            Stars = 5,
                            VoterName = "Son Goku"
                        },
                        new Review
                        {
                            Stars = 0,
                            VoterName = "Vegeta"
                        }
                    })
                },
                new Product
                {
                    Name = "Product 3", Description = "Description 3", Price = 30
                }
            });
    }
}
