using ClownOnThisSIde.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownOnThisSIde.Helper
{
    static class GetProduct
    {
        public static List<NewProduct> GetPorducts()
        {
            using (ModelBD model = new ModelBD())
            {
                var product = from p in model.Product
                              select new
                              {
                                  Title = p.Title,
                                  Price = p.MinCostForAgent,
                                  Image = p.Image,
                                  Article = p.ArticleNumber,
                                  PwNumber = p.ProductionWorkshopNumber,
                                  PType = p.ProductTypeID

                              };

                NewProduct newProduct = new NewProduct();
                List<NewProduct> newProducts = new List<NewProduct>();

                foreach(var item in product)
                {
                    var PathImage = "";
                    if (item.Image == "none") PathImage = "/products/picture.png";
                    else PathImage = item.Image.Replace("\\", "/").Replace("jpg", "jpeg");


                    newProduct = new NewProduct()
                    {

                        Title = item.Title,
                        Price = item.Price,
                        Image = PathImage,
                        Article = item.Article,
                        PwNumber = item.PwNumber,
                        PType = item.PType
                    };

                    newProducts.Add(newProduct);
                }
                return newProducts;
            }  
            
        }
    }
}
