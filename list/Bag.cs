using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using list;

namespace list
{
    public class Bag
    {
        public List<Items> items = new List<Items>();
        public void Info()
        {
            Console.WriteLine("\nВы откыли инвентарь");
        }
        public void PrintItems()
        {
            Console.WriteLine("Содержмое инвентаря: ");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        public void AddItems(Items name)
        {
            if (items.Count >= 4)
            {
                Console.WriteLine("Место в инвентаре закончилось");
                return;
            }
            else if (items.Contains(name))
            {
                Console.WriteLine($"Предмет {name} уже есть в инвентаре");
                return;
            }
            else items.Add(name);
            Console.WriteLine($"Вы положили {name} в инвентарь");
        }
        public void GetItem(Items name)
        {
            if (!items.Contains(name))
            {
                Console.WriteLine($"Предмета {name} нет в инвентаре");
                return;
            }
            foreach (var item in items)
            {
                if (item.Equals(name))
                {
                    items.Remove(name);
                    break;
                }
            }
            Console.WriteLine($"Вы удалили {name} из инвентаря");
        }
        public override bool Equals(object obj)
        {
            if (obj is Bag other)
            {
                return items == other.items;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(items);
        }
        public override string ToString()
        {
            return $"{items}";
        }
    }
}
