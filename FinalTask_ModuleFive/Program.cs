namespace FinalTask_ModuleFive
{
    internal class Program
    {
        // метод заполнения анкеты
        public static (string Name, string LastName, int Age, bool HasPet, int NumberOfPets, string[] PetNames, int CountOfFavColors, string[] FavColors) CreateForm()
        {
            (string Name, string LastName, int Age, bool HasPet, int NumberOfPets,
                string[] PetNames, int CountOfFavColors, string[] FavColors) form;

            form.HasPet = true;
            form.NumberOfPets = 0;
            form.PetNames = null;
            form.CountOfFavColors = 0;
            form.FavColors = null;

            Console.Write("Здравствуйте! Введите имя: ");
            form.Name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            form.LastName = Console.ReadLine();

            string age;
            int intage;

            do
            {
                Console.Write("Укажите возраст цифрами: ");
                age = Console.ReadLine();
            }
            while (CheckNum(age, out intage));

            form.Age = intage;

            Console.WriteLine($"Замечательно, {form.Name}! Скажите, у вас есть домашнее животное? Да или нет?");
            string answer = Console.ReadLine();

            string numpet;
            int intpet;

            // проверка условия на наличие питомца
            if (answer == "Да" || answer == "да" || answer == "ДА")
            {
                form.HasPet = true;
                do
                {
                    Console.WriteLine("Сколько у вас питомцев?");
                    numpet = Console.ReadLine();
                }
                while (CheckNum(numpet, out intpet));
                form.NumberOfPets = intpet;

                form.PetNames = Pets(intpet);
            }
            else form.HasPet = false;

            string color;
            int countcol;

            do
            {
                Console.WriteLine($"Наверняка у вас есть любимые цвета, {form.Name}! Сколько их?");
                color = Console.ReadLine();
            }
            while (CheckNum(color, out countcol));
            form.CountOfFavColors = countcol;

            form.FavColors = Colors(countcol);

            return form;
        }

        // метод для ввода информации о питомцах
        static string[] Pets(int num)
        {
            var PetNames = new string[num];

            if (num == 1)
            {
                Console.Write("Введите кличку: ");
                PetNames[0] = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Введите клички:");
                for (int i = 0; i < num; i++)
                {
                    PetNames[i] = Console.ReadLine();
                }
            }
            return PetNames;
        }

        // метод для ввода цветов
        static string[] Colors(int num)
        {
            string[] FavColors = new string[num];

            Console.WriteLine("Перечислите их:");
            for (int i = 0; i < num; i++)
                FavColors[i] = Console.ReadLine();

            for (int i = 0; i < num; i++)
                Console.WriteLine($"Любимый цвет №{i + 1}: {FavColors[i]}");

            return FavColors;
        }

        //метод для проверки числовых данных
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                corrnumber = 0;
                return true;
            }
        }

        // метод, принимающий кортеж и выводящий его на экран
        static void PrintForm((string Name, string LastName, int Age, bool HasPet, int NumberOfPets, string[] PetNames, int CountOfFavColors, string[] FavColors) userform)
        {
            Console.WriteLine($"Ваше имя: {userform.Name}");
            Console.WriteLine($"Ваша фамилия: {userform.LastName}");
            Console.WriteLine($"Ваш возраст: {userform.Age}");

            if (userform.HasPet == true)
            {
                Console.WriteLine("Наличие питомца: да");

                Console.WriteLine($"У вас {userform.NumberOfPets} питомца(-ев)");
                if (userform.NumberOfPets == 1)
                    Console.WriteLine($"Кличка питомца: {userform.PetNames}");
                else
                {
                    Console.WriteLine($"Клички питомцев: ");
                    for (int i = 0; i < userform.NumberOfPets; i++)
                        Console.WriteLine(userform.PetNames[i]);
                }
            }
            else Console.WriteLine("Наличие питомца: нет");

            if (userform.CountOfFavColors == 1)
            {
                Console.WriteLine($"У вас {userform.CountOfFavColors} любимый цвет");
            }
            else
            {
                Console.WriteLine($"У вас {userform.CountOfFavColors} любимых цвета(-ов)");
            }

            for (int i = 0; i < userform.CountOfFavColors; i++)
                Console.WriteLine($"Любимый цвет №{i + 1}: {userform.FavColors[i]}");
        }
        static void Main(string[] args)
        {
            PrintForm(CreateForm());
        }
    }
}
