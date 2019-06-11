using System;

namespace LawnJournalApi.Exceptions
{
    public class ProductApplicationNotFoundException: Exception
    {
        public string LawnId { get; }
        public string ProductApplicationId { get; }

        public ProductApplicationNotFoundException(string lawnId, string productApplicationId)
        {
            LawnId = lawnId;
            ProductApplicationId = productApplicationId;
        }
    }
}