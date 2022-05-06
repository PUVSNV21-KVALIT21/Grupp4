using HakimLivs.Data;
using HakimLivs.Models;

namespace HakimLivs.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void LoadTestData()
        {

            var categoryList = new Category[] { 
                new Category { Name ="Skafferi" },
                new Category { Name ="Träning" },
                new Category { Name ="Snacks" },
                new Category { Name ="Drycker" },
            };

            if (!_context.Products.Any())
            {
                string path = @"Data\BasProdukter1.csv";
                //string path2 = @"Data\BasKategorier1.csv";
                string[] lines = System.IO.File.ReadAllLines(path, System.Text.Encoding.Latin1);


                foreach (string line in lines)
                {
                    var values = line.Split(';');
                    Product product = new Product();

                    product.Name = values[0];
                    product.Brand = values[1];
                    product.Description = values[2];
                    product.Unit = int.Parse(values[3]);
                    product.UnitType = values[4];
                    product.TableOfContent = values[5];
                    product.Price = decimal.Parse(values[6]);
                    product.Category = categoryList[int.Parse(values[7]) - 1];
                    product.Stock = int.Parse(values[8]);
                    product.ImgPath = values[9];

                    _context.Products.Add(product);
                }
                await _context.SaveChangesAsync();


                //string[] lines2 = System.IO.File.ReadAllLines(path2, System.Text.Encoding.Latin1);
                //foreach (string line in lines2)
                //{
                //    var values = line.Split(';');
                //    Category category = new Category();

                //    category.Name = values[0];

                //    _context.Categories.Add(category);
                //}

                //await _context.SaveChangesAsync();

            }


        }

    }
}

