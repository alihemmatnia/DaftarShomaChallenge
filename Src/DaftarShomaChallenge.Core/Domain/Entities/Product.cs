using DaftarShomaChallenge.Core.Domain.Entities.Base;

namespace DaftarShomaChallenge.Core.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Title { get; private set; }
        public int Price { get; private set; }

        public Product(string title, int price)
        {
            ProductTitleValidation(title);
            Title = title;
            Price = price;
        }

        #region Behaviour

        public void ChangeTitle(string title)
        {
            ProductTitleValidation(title);
            Title = title;
        }

        public void ChangePrice(int price)
        {
            Price = price;
        }

        #endregion


        private void ProductTitleValidation(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("product title can't be empty or null");
        }
    }
}
