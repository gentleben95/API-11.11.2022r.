namespace API.Entities
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TableTennisShopId { get; set; }

        public virtual TableTennisShop TableTennisShop { get; set; }

    }
}
