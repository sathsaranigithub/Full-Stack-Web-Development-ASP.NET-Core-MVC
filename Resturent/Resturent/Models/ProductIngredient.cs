namespace Resturent.Models
{

    //this is joint table
    public class ProductIngredient
    {
        public int ProductId { get; set; } // foregin key
        public Product Product { get; set; }//navigation properties
        public int IngredientId { get; set; } //foregin key
        public Ingredient Ingredient { get; set; }
    }
}