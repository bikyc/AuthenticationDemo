namespace AuthenticationDemo.Domain.Entities
{
    public static class ItemStore
    {
        public static List<Item> Items { get; set; } = new List<Item>();
        private static int _id = 1;

        public static int GetNextId()
        {
            return _id++;
        }
    }

}
