using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using list;

namespace list
{
    public enum Items
    {
        Bible,
        Tabaco,
        Lamp,
        Towel,
        Apple,
        Bottle,
        Cigarette,
        Fish,
        Meat
    }

    public enum Status
    {
        Sick,
        Tired,
        Hungry,
        Happy
    }
    public class Person
    {

        public string Name;
        public void setName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Имя не может быть пустым");
            }
            Name = value;

        }
        private string Spot;
        public void setSpot(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Место не может быть пустым");
            }
            Spot = value;
        }
        private static int nextId = 1;
        private bool IsSick { get; set; }
        private bool IsTired { get; set; }
        private bool IsHungry { get; set; }
        private bool IsMoney { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public int id { get; set; }

        private Status status { get; set; }
        private Bag Inventory { get; set; } = new Bag();

        public Bag getInventory
        {
            get { return Inventory; }
        }

        public Person(string name, int age, double height)
        {
            Name = name;
            Age = age;
            Height = height;
            id = GetNextId();
        }

        private static int GetNextId()
        {
            return nextId++;
        }
        public Person() { }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Рост: {Height}, ID: {id}";
        }
    }
}
