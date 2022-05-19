﻿

using HakimLivs.Data;

namespace HakimLivs.Models

{
    public class CartState
    {
        private readonly ApplicationDbContext _context;

        public CartState(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BasketProduct>? selectedProducts = new List<BasketProduct>();

        public decimal? totalPrice { get; set; } = 0;
        public event Action OnChange;



        public async Task AddProduct(Product product)
        {
            BasketProduct basketProduct = new BasketProduct();

            var isAlreadyInBasket = selectedProducts.Where(bp => bp.Product == product).SingleOrDefault(new BasketProduct());

            if (isAlreadyInBasket.Product != null && (product.Stock + isAlreadyInBasket.ProductQuantity) > isAlreadyInBasket.ProductQuantity)
            {
                isAlreadyInBasket.ProductQuantity++;
                totalPrice = totalPrice + product.Price;
                product.Stock--;
            }
            else if (product.Stock > 0 && isAlreadyInBasket.Product == null)
            {
                isAlreadyInBasket.Product = product;
                isAlreadyInBasket.ProductQuantity = 1;
                selectedProducts.Add(isAlreadyInBasket);
                totalPrice = totalPrice + product.Price;
                product.Stock--;
            }
            _context.Products.Update(product);
            _context.SaveChanges();

            NotifyStateChanged();
        }



        public async Task AddProductQuantity(BasketProduct basketProduct)
        {
            var productIndex = selectedProducts.IndexOf(basketProduct);
            if (selectedProducts[productIndex].Product.Stock + basketProduct.ProductQuantity > basketProduct.ProductQuantity)
            {

            selectedProducts[productIndex].ProductQuantity++;
            totalPrice = totalPrice + selectedProducts[productIndex].Product.Price;
                basketProduct.Product.Stock--;
                _context.Products.Update(basketProduct.Product);
                _context.SaveChanges();
                NotifyStateChanged();
            }
        }
        public async Task SubtractProductQuantity(BasketProduct basketProduct)
        {
            var product = selectedProducts.IndexOf(basketProduct);

            if (selectedProducts[product].ProductQuantity > 1)
            {
                selectedProducts[product].ProductQuantity--;
                totalPrice = totalPrice - selectedProducts[product].Product.Price;
                basketProduct.Product.Stock++;
            }
            else
            {
                totalPrice = totalPrice - selectedProducts[product].Product.Price;

                selectedProducts.Remove(selectedProducts[product]);
                basketProduct.Product.Stock++;
            }
            _context.Products.Update(basketProduct.Product);
            _context.SaveChanges();
            NotifyStateChanged();
        }

        public async Task ClearCart()
        {
            selectedProducts.Clear();
            totalPrice = 0;
            NotifyStateChanged();
            //for (int i = 0; i < selectedProducts.Count(); i++)
            //{

            //    SubtractProductQuantity();
            //}
        }


        public void NotifyStateChanged() => OnChange?.Invoke();


    }
}
