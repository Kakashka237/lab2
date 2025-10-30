using System.Xml.Serialization;

namespace list
{
    public class CommandWorker
    {
        List<Person> MainList;
        public bool work = true;
        public FileWork file;

        public CommandWorker(List<Person> list, FileWork file)
        {
            this.MainList = list;
            this.file = file;
        }
        public void Help()
        {
            Console.WriteLine("СПРАВКА ПО ДОСТУПНЫМ КОМАНДАМ");
            Console.WriteLine("info - информация о коллекции");
            Console.WriteLine("show - все элементы коллекции");
            Console.WriteLine("insert - добавить новый элемент");
            Console.WriteLine("update - обновить элемент по идентификатору");
            Console.WriteLine("remove - удалить элемент по идентификатору");
            Console.WriteLine("additem - положить предмет в инвентарь");
            Console.WriteLine("showbag - посмотреть инвентарь");
            Console.WriteLine("delitem - удалить предмет из инвенторя");
            Console.WriteLine("exfile - выполнить команды из файла");
            Console.WriteLine("printuniq - вывести уникальные значения полей");
            Console.WriteLine("printasc - вывести значения поля по возрастанию");
            Console.WriteLine("clear - очистить всю коллекцию");
            Console.WriteLine("save {filename} - сохранить коллекцию в файл");
            Console.WriteLine("exit - завершить работу");
        }
        public void Info(List<Person> list)
        {
            Console.WriteLine($"Тип коллекции: List<T>, дата инициализации {DateTime.Now}, количество элементов: {list.Count}");
        }

        public void Show(List<Person> list)
        {
            int count = 0;
            if (list.Count > 0)
            {
                foreach (Person person in list)
                {
                    count++;
                    Console.WriteLine();
                    Console.WriteLine($"{count} элемент:");
                    Console.WriteLine(person);
                }
            }
            else
            {
                Console.WriteLine("Коллекция пуста");
            }
        }

        public string InputString(string mes)
        {
            string input;
            while (true)
            {
                Console.Write($"{mes} ");
                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.Write("Некорректный ввод");
                }
            }
        }
        public int InputInt(string mes)
        {
            string input;
            while (true)
            {
                Console.Write($"{mes} ");
                input = Console.ReadLine();

                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.Write("Некорректный ввод");
                }
            }
        }
        public double InputDouble(string mes)
        {
            string input;
            while (true)
            {
                Console.Write($"{mes} ");
                input = Console.ReadLine();

                if (double.TryParse(input, out double result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.Write("Некорректный ввод");
                }
            }
        }
        public string InputOptString(string mes, string current)
        {
            Console.Write($"{mes} ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.Write("Без изменений");
                return current;
            }
            else if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            else
            {
                Console.Write("Введена пустая строка, без изменений");
                return current;
            }
        }
        public int InputOptInt(string mes, int current)
        {
            Console.Write($"{mes} ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.Write("Без изменений");
                return current;
            }
            else
            {
                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.Write("Некорректный ввод, без изменений");
                    return current;
                }
            }
        }
        public double InputOptDouble(string mes, double current)
        {
            Console.Write($"{mes} ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.Write("Без изменений");
                return current;
            }
            else
            {
                if (double.TryParse(input, out double result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.Write("Некорректный ввод, без изменений");
                    return current;
                }
            }
        }

        private int FindIndex(string mes, List<Person> list)
        {
            Console.WriteLine(mes);
            string inputid = Console.ReadLine();

            if (!int.TryParse(inputid, out int Id))
            {
                Console.WriteLine("Некорректный ввод");
                return -1;
            }
            int index = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == Id)
                {
                    index = i;
                    return index;
                }
            }
            return -1;
        }

        public Items InputItem(string mes)
        {
            Console.WriteLine(mes);
            string input = Console.ReadLine();
            if (Enum.TryParse(input, out Items result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Некорректное название");
                return 0;
            }
        }

        public void AddPerson(List<Person> list)
        {
            Console.WriteLine("ДОБАВЛЕНИЕ НОВОГО ЭЛЕМЕНТА В КОЛЛЕКЦИЮ");

            string name = InputString("\nВведите имя");
            int age = InputInt("\nВведите возраст");
            double height = InputDouble("\nВведите рост");

            if (age > 100 || height > 220)
            {
                Console.WriteLine("Возраст или рост недопустимо большие, изменения не вступят в силу");
                return;
            }
            else
            {
                Person person = new Person(name, age, height);
                foreach(Person p in list)
                {
                    if(p.id == person.id)
                    {
                        person.id = p.id + 1;
                    }
                }
                
                list.Add(person);
                Console.WriteLine("Элемент успешно добавлен");
            }
        }

        public void UpdateId(List<Person> list)
        {
            int index = FindIndex("Введите ID элемента который хотите обновить", list);

            if (index == -1)
            {
                Console.WriteLine($"Элемент не найден");
                return;
            }

            Person updateperson = list[index];
            Console.WriteLine($"Текущие данные элемента: Имя: {updateperson.Name}, возраст: {updateperson.Age}, рост: {updateperson.Height}");
            Console.WriteLine("ОБНОВЛЕНИЕ ЭЛЕМЕНТА");

            updateperson.Name = InputOptString("\nВведите имя, чтобы оставить текущее, нажмите Enter", updateperson.Name);
            int age = InputOptInt("\nВведите возраст, чтобы оставить текущий, нажмите Enter", updateperson.Age);
            double height = InputOptDouble("\nВведите рост, чтобы оставить текущий, нажмите Enter", updateperson.Height);

            if (age > 100 || height > 220)
            {
                Console.WriteLine("Возраст или рост недопустимо большие, изменения не вступят в силу");
                return;
            }
            else
            {
                updateperson.Age = age;
                updateperson.Height = height;
                Console.WriteLine("\nЭлемент успешно обновлен");
            }
        }

        public void RemoveId(List<Person> list)
        {
            int index = FindIndex("Введите ID элемента который хотите удалить", list);

            if (index == -1)
            {
                Console.WriteLine($"Элемент не найден");
                return;
            }

            list.RemoveAt(index);
            Console.WriteLine($"Элемент успешно удален");
        }

        public void AddItem(List<Person> list)
        {
            Console.WriteLine("\nДОСТУПНЫЕ ПРЕДМЕТЫ");
            foreach (Items item in Enum.GetValues(typeof(Items)))
            {
                Console.WriteLine(item);
            }

            int index = FindIndex("Введите ID элемента к которому в инвентарь вы хотите положить предмет", list);
            if (index == -1)
            {
                Console.WriteLine($"Элемент не найден");
                return;
            }

            Items additem = InputItem("Введите название предмета для добавления");


            Person person = list[index];
            person.getInventory.AddItems(additem);
        }

        public void ShowBag(List<Person> list)
        {
            int index = FindIndex("Введите ID элемента у которого хотите посмотреть инвентарь", list);

            if (index == -1)
            {
                Console.WriteLine($"Элемент не найден");
                return;
            }

            Person person = list[index];
            person.getInventory.PrintItems();
        }

        public void RemoveItem(List<Person> list)
        {
            int index = FindIndex("Введите ID элемента у которого хотите удалить предмет", list);

            if (index == -1)
            {
                Console.WriteLine("Элемент не найден");
                return;
            }
            Person person = list[index];

            Items delitem = InputItem("Введите название предмета для удаления");
            person.getInventory.GetItem(delitem);
        }

        public void Clear(List<Person> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Коллекция уже пуста");
                return;
            }

            Console.WriteLine("Вы уверены что хотите удалить всю коллекцию? (y/n)");
            string input = Console.ReadLine();

            if (input == "y")
            {
                list.Clear();
                Console.WriteLine("Коллекция успешно очищена");
            }
            else
            {
                Console.WriteLine("Очистка отменена");
            }
        }

        public void PrintUnique(List<Person> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }

            Console.WriteLine("От какого поля выводить уникальные значения?");
            Console.WriteLine("Доступные поля: name, age, height");
            string input = Console.ReadLine().ToLower();
            if (input == "name")
            {
                HashSet<string> names = new HashSet<string>();
                foreach (Person person in list)
                {
                    names.Add(person.Name);
                }

                Console.WriteLine("Уникальные имена: ");
                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }
            }
            else if (input == "age")
            {
                HashSet<int> ages = new HashSet<int>();
                foreach (Person person in list)
                {
                    ages.Add(person.Age);
                }

                Console.WriteLine("Уникальные возраста: ");
                foreach (int age in ages)
                {
                    Console.WriteLine(age);
                }
            }
            else if (input == "height")
            {
                HashSet<double> heights = new HashSet<double>();
                foreach (Person person in list)
                {
                    heights.Add(person.Height);
                }

                Console.WriteLine("Уникальные росты");
                foreach (double height in heights)
                {
                    Console.WriteLine(height);
                }
            }
            else
            {
                Console.WriteLine("Неизвестное поле");
            }
        }

        public void PrintAsc(List<Person> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Коллекция пуста");
            }

            Console.WriteLine("Значения какого поля вывести по возрастанию?");
            Console.WriteLine("Доступные поля: name, age, height");
            string input = Console.ReadLine().ToLower();

            if (input != "name" && input != "age" && input != "height")
            {
                Console.WriteLine("Неизвестное поле");
                return;
            }

            List<object> sorted = new List<object>();
            foreach (Person person in list)
            {
                if (input == "name")
                {
                    sorted.Add(person.Name);
                }
                else if (input == "age")
                {
                    sorted.Add(person.Age);
                }
                else if (input == "height")
                {
                    sorted.Add(person.Height);
                }
            }
            sorted.Sort();

            Console.WriteLine($"Значения поля {input} по возрастанию: ");
            foreach (object value in sorted)
            {
                Console.WriteLine(value);
            }
        }
        public void ExcecuteFile()
        {
            Console.WriteLine("Введите название вашего файла");
            string filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }
            try
            {
                StreamReader sr = new StreamReader(filename);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    CommandExcecute(line);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не найден: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Доступ к файлу запрещён: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Имя файла не может быть пустым: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Недопустимое имя файла: {ex.Message}");
            }
        }
        public void CommandExcecute(string command)
        {
            switch (command)
            {
                case "info":
                    Info(MainList);
                    Console.WriteLine();
                    break;

                case "show":
                    Show(MainList);
                    Console.WriteLine();
                    break;

                case "insert":
                    AddPerson(MainList);
                    Console.WriteLine();
                    break;

                case "update":
                    UpdateId(MainList);
                    Console.WriteLine();
                    break;

                case "remove":
                    RemoveId(MainList);
                    Console.WriteLine();
                    break;

                case "additem":
                    AddItem(MainList);
                    Console.WriteLine();
                    break;

                case "clear":
                    Clear(MainList);
                    Console.WriteLine();
                    break;

                case "showbag":
                    ShowBag(MainList);
                    Console.WriteLine();
                    break;

                case "delitem":
                    RemoveItem(MainList);
                    Console.WriteLine();
                    break;

                case "exfile":
                    ExcecuteFile();
                    Console.WriteLine();
                    break;

                case "printuniq":
                    PrintUnique(MainList);
                    Console.WriteLine();
                    break;

                case "printasc":
                    PrintAsc(MainList);
                    Console.WriteLine();
                    break;

                case "save":
                    file.WriteToFile(MainList);
                    Console.WriteLine();
                    break;

                case "exit":
                    Console.WriteLine("Работа завершена");
                    work = false;
                    break;

                default:
                    Console.WriteLine("Неизвестная команда, попробуйте еще раз");
                    Console.WriteLine();
                    break;
            }

        }
    }

    public class FileWork
    {
        public List<Person> ReadToList()
        {
            List<Person> list;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
                using (FileStream fs = new FileStream("read.xml", FileMode.Open))
                {
                    list = serializer.Deserialize(fs) as List<Person>;
                }
                return list;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не найден: {ex.Message}");
                return null;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
                return null;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Нет прав на чтение файла: {ex.Message}");
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка десериализации XML: {ex.Message}");
                return null;
            }
        }

        public void WriteToFile(List<Person> list)
        {
            Console.WriteLine("Введите имя файла для сохранения: ");
            string file = Console.ReadLine();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fs, list);
                }
                Console.WriteLine($"Данные успешно сохранились в файл {file}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Ошибка доступа к файлу: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Имя файла не может быть пустым: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Недопустимое имя файла: {ex.Message}");
            }
        }
    }
}
