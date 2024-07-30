using System;
using System.Collections.Generic;
namespace AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();

            //созданеи объектов
            Book book1 = new Book("Капитанская дочка", "А.С. Пушкин", 500, "ООО Питер", 12);
            Toy toy1 = new Toy("Мячик", 105.5, "ООО ВладИгра", "Резина", 3);
            SportItem sportItem1 = new SportItem("Эспандер", 659, "ИП Спортмастер", 16);
            Toy toy2 = new Toy("Мячик2", 110, "ООО ВладИгра", "Резина", 3);
            items.Add(book1);
            items.Add(sportItem1);
            items.Add(toy1);
            items.Add(toy2);

            foreach (Item item in items)
            {
                item.PrintInfo();
            }


            List<Item> itemsByType = new List<Item>();
            string nesaccaryType = Enum.GetName(typeof(Types), Types.Toy);

            Console.WriteLine("\n" + "Searching \"{0}\"..." + "\n", nesaccaryType);
            foreach (Item item in items)
            {
                if (item.ISMatch(nesaccaryType)) item.PrintInfo();
            }
        }
    }

    enum Types
    {
        Book,
        SportItem,
        Toy
    }
    abstract class Item
    {
        public abstract void PrintInfo();
        protected string TYPE;
        public bool IsType(string type)
        {
            return type == TYPE;
        }
        public bool ISMatch(string type)
        {
            return this.GetType().Name == type;
        }
    }
    class Toy : Item
    {
        private string name;
        private double price;
        private string manufacturer;
        private string material;
        private int ableAge;

        public Toy(string name, double price, string manufacturer, string material, int ableAge)
        {
            base.TYPE = Enum.GetName(typeof(Types), Types.Toy);
            this.name = name;
            this.price = price;
            this.manufacturer = manufacturer;
            this.material = material;
            this.ableAge = ableAge;
        }
        public override void PrintInfo()
        {
            string info = "Name " + name +
                "\nPrice " + price +
                "\nManufacturer " + manufacturer +
                "\nMaterial " + material +
                "\nAble age " + ableAge + "\n";
            Console.Write(info);
        }
    }
    class Book : Item
    {
        private string name;
        private string auther;
        private double price;
        private string publisher;
        private int ableAge;

        public Book(string name, string auther, double price, string publisher, int ableAge)
        {
            base.TYPE = Enum.GetName(typeof(Types), Types.Book);
            this.name = name;
            this.auther = auther;
            this.price = price;
            this.publisher = publisher;
            this.ableAge = ableAge;
        }
        public override void PrintInfo()
        {
            string info = "Name " + name +
            "\nAuther " + auther +
            "\nPrice " + price +
            "\nPublisher " + publisher +
            "\nAble age " + ableAge + "\n";
            Console.Write(info);
        }
    }
    class SportItem : Item
    {
        private string name;
        private double price;
        private string manufacturer;
        private int ableAge;

        public SportItem(string name, double price, string manufacturer, int ableAge)
        {
            base.TYPE = Enum.GetName(typeof(Types), Types.SportItem);
            this.name = name;
            this.price = price;
            this.manufacturer = manufacturer;
            this.ableAge = ableAge;
        }
        public override void PrintInfo()
        {
            string info = "Name " + name +
               "\nPrice " + price +
               "\nManufacturer " + manufacturer +
               "\nAble age " + ableAge + "\n";
            Console.Write(info);
        }
    }
}
