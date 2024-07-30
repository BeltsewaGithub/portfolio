using System;
using System.Collections.Generic;
namespace AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();

            Book book1 = new Book("Капитанская дочка", "А.С. Пушкин", 500, "ООО Питер", 12);
            Toy toy1 = new Toy("Мячик", 105.5, "ООО ВладИгра", "Резина", 3);
            SportItem sportItem1 = new SportItem("Эспандер", 659, "ИП Спортмастер", 16);
            Toy toy2 = new Toy("Мячик2", 110, "ООО ВладИгра", "Резина", 3);
            items.Add(book1);
            items.Add(sportItem1);
            items.Add(toy1);
            items.Add(toy2);

            Console.WriteLine("Items list:\n");
            foreach (Item item in items)
            {
                item.PrintInfo();
            }


            List<Item> itemsByType = new List<Item>();
            string nesaccaryType = Enum.GetName(typeof(Types), Types.TOY);

            Console.WriteLine("\n" + "Searching \"{0}\"..." + "\n", nesaccaryType);
            foreach (Item item in items)
            {
                if (item.IsType(nesaccaryType)) item.PrintInfo();
            }
        }
    }

    enum Types
    {
        BOOK,
        SPORT_ITEM,
        TOY
    }
    abstract class Item
    {
		protected string typename;
        public abstract void PrintInfo();
        public bool IsType(string type) {
			return type == typename;
		};
		
		public string MyClassName() {
			return this.GetType().Name;
		}
		
		public string MyClassName2() {
			return typeof(Item).Name;
		}
    }
    class Toy : Item
    {
        private string TYPE = Enum.GetName(typeof(Types), Types.TOY);
        private string name;
        private double price;
        private string manufacturer;
        private string material;
        private int ableAge;
		protected string typename;

        public Toy(string name, double price, string manufacturer, string material, int ableAge)
        {
			this.typename = Enum.GetName(typeof(Types), Types.TOY);
            this.name = name;
            this.price = price;
            this.manufacturer = manufacturer;
            this.material = material;
            this.ableAge = ableAge;
        }
       /* public override bool IsType(string type)
        {
            if (type == TYPE) return true;
            else return false;
        }*/
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
        private string TYPE = Enum.GetName(typeof(Types), Types.BOOK);
        private string name;
        private string auther;
        private double price;
        private string publisher;
        private int ableAge;

        public Book(string name, string auther, double price, string publisher, int ableAge)
        {
            this.name = name;
            this.auther = auther;
            this.price = price;
            this.publisher = publisher;
            this.ableAge = ableAge;
        }
        public override bool IsType(string type)
        {
            if (type == TYPE) return true;
            else return false;
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
        private string TYPE = Enum.GetName(typeof(Types), Types.SPORT_ITEM);
        private string name;
        private double price;
        private string manufacturer;
        private int ableAge;

        public SportItem(string name, double price, string manufacturer, int ableAge)
        {
            this.name = name;
            this.price = price;
            this.manufacturer = manufacturer;
            this.ableAge = ableAge;
        }
        public override bool IsType(string type)
        {
            if (type == TYPE) return true;
            else return false;
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
