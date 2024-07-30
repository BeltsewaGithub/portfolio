using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            //считывание файла в массив строк
            string path = @"G:\АиП\Материалы\Input.txt"; 
            string text = File.ReadAllText(path);
            text.Trim();
            string[] items = text.Split('\n');
            
            //границы возраста
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            //массив объектов класса Toy
            List<Toy> toyList = new List<Toy>();
            
            //занесение новых объектов с параметрами из файла в массив объектов класса Toy
            foreach (string line in items)
            {
                string[] info = line.Split(' ');
                if (info.Length != 3) throw new Exception("Некорректная строка");
                
                string name = info[0];
                double price = double.Parse(info[1]);
                int ableAge = int.Parse(info[2].Replace("+", ""));
                if (ableAge <= M && ableAge >= N) toyList.Add(new Toy(name, price, ableAge));
            }

            //сортировка согласно заданному критерию (по price)
            ToyComparator comparator = new ToyComparator();
            toyList.Sort(comparator);

            //формирование выходной строки для последующей записи в output.txt
            StringBuilder output = new StringBuilder();
            foreach (Toy toy in toyList)
            {
                output.Append(toy.ToString() + "\n");
            }

            //запись выходной строки в output.txt
            string outputPath = @"G:\АиП\Материалы\Output.txt";
            StreamWriter writer = new StreamWriter(outputPath);
            writer.Write(output);
            writer.Close();
        }
    }
    class Toy
    {
        private string name;
        private double price;
        private int ableAge;
        public Toy(string name, double price, int ableAge)
        {
            this.name = name;
            this.price = price;
            this.ableAge = ableAge;
        }
        public string Name
        { 
            get { return name; }
        }
        public double Price
        {
            get { return price; }
        }
        public int AbleAge
        {
            get { return ableAge; }
        }
        public override string ToString()
        {
            return "Название - " + name + ", цена - " + price + ", " + ableAge + "+";
        }

    }
        
    class ToyComparator : IComparer<Toy>
    {
        public int Compare(Toy t1, Toy t2) //компаратор по возрастанию
        {
            if (t1.Equals(null) || t2.Equals(null)) throw new ArgumentException("Некорректное значение параметра!");
                
            if (t1.Price < t2.Price) return -1;
            if (t1.Price > t2.Price) return 1;
            else return 0;
        }
    }
}
