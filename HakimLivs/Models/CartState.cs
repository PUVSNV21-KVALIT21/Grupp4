namespace HakimLivs.Models
{
    public class CartState
    {
        public List<Product>? selectedProduct = new List<Product>();


        public event Action OnChange;
        //public List<Product> Products
        //{
        //    get => selectedProduct ?? null; 
        //    set
        //    {
        //        selectedProduct.Add(value);
        //        NotifyStateChanged();

        //    }
        //}
        public void AddProduct(Product product)
        {
            selectedProduct.Add(product);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();


    }
}
