using NTierArchTestProject.CoreLayer.Entities;


namespace NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities
{
    public sealed class Product:Entity
    {
     
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        //scalar hatası olduğundan bu sütunu kaldırıyorum
        //public Category Category { get; set; }
    }
}
