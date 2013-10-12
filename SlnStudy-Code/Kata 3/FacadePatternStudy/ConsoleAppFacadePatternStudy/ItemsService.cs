namespace ConsoleAppFacadePatternStudy
{
    public class ItemsService
    {
        public Item GetLast5BuyedItems(Associate associate)
        {
            //Should return the buyed items from this associate

            return new Item
                {
                    Id = 1,
                    Name = "Item 2",
                    Price = 12.00
                };
        }
    }
}