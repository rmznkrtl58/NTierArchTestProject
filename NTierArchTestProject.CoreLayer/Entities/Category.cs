namespace NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities
{
    public sealed class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //Bir Kategori birden fazla ürün barındırabilir
        public ICollection<Product> Products { get; set; }
    }
}
