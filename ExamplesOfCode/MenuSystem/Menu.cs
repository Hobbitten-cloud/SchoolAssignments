namespace MenuSystem
{
    internal class Menu
    {
        public string Title;
        public string hej;
        public MenuItem[] MenuItems;
        public int ItemCount = 0;

        public void Show()
        {
            Console.WriteLine(Title);
            Console.WriteLine(hej);

            for (int i = 0; i < ItemCount; i++)
            {
                Console.WriteLine(MenuItems[i].Title);
            }
        }
    }
}