using NTierArchTestProject.CoreLayer.Entities;

namespace NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities
{
    public sealed class Category:Entity
    {
  
        public string Name { get; set; }
        //Bir Kategori birden fazla ürün barındırabilir
        public ICollection<Product> Products { get; set; }
    }
}
