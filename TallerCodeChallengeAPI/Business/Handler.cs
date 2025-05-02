using System;
using TallerCodeChallengeAPI.Models;

namespace TallerCodeChallengeAPI.Business
{
	public class Handler
	{
		public Handler()
		{
			
		}
		public List<Product> GetAll(List<Product> products)
		{
			return  products;
		}
		public Product GetById(int id, List<Product> products)
		{
			try
			{
				return products.FirstOrDefault(x => x.Id == id);
			}
			catch
			{
				return null;
			}
			
		}
		public int CreateNewProduct(Product prod, int incrementalId, List<Product> Product)
		{
			prod.Id = incrementalId;

            try
			{
				if (prod.Price <= 0 || prod.Id == 0 || string.IsNullOrEmpty(prod.Name))
				{
					return 0;
				}
				else
				{
                    Product.Add(prod);
                    return prod.Id;
                }

			}
			catch
			{
				return 0;
			}
		}
		public bool UpdateProduct(Product product, int id, List<Product> Products)
		{
			var existingProduct = Products.FirstOrDefault(p => p.Id == id);
			if (existingProduct == null)
			{
				return false;
			}
			else
			{
				existingProduct.Name = product.Name;
				existingProduct.Price = product.Price;
				return true;
			}
		}
		public bool DeleteProductById(int productId, List<Product>Products)
		{
			var exisitng = Products.SingleOrDefault(p => p.Id == productId);

			if (exisitng == null)
			{
				return false;
			}
			else
			{
				Products.Remove(exisitng);
				return true;
			}
			
		}
		public bool DummyBulkAdd(List<Product> products, int incrementalId)
		{
			try
			{
				for (var i = incrementalId; i <= 50; i++)
				{
					products.Add(new Product(i, "Some product" + i, (decimal)10.5 * i));
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
    }
}

