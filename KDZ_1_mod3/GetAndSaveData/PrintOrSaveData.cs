using AdditionalClasses;
using WorkWithJsonFile;
namespace GetAndSaveData
{
    public static class PrintOrSaveData
    {
        /// <summary>
        /// Выводим данные в консоль или сохраняем в файл.
        /// </summary>
        /// <param name="cars"> Объекты для вывода/записи в файл. </param>
        /// <param name="path"> Путь к файлу, из которого была получена информация, если из консоли, то значение null. </param>
        public static void PrintingOrSavingData(List<Car> cars, string? path)
        {
            string[] menuItems =
                   {
                "Вывести данные в консоль",
                "Перезаписать данные в файле, из котрого считывалась информация",
                "Записать данные в другой файл"
                };
            int menuItemIndex = Menu.CreateMenu(menuItems, "Выберить, каким образом нужно записать данные");
            switch (menuItemIndex)
            {
                case 0:
                    foreach (Car car in cars)
                    {
                        car.Print();
                        Console.WriteLine();
                    }
                    // Пользователь может просматривать данные, пока не нажмет ENTER.
                    Console.WriteLine("Для возвращения в меню нажмите ENTER");
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        Console.ReadKey();
                    }
                    break;
                case 1:
                    // Если данные получены из консоли, переходим к выполнению case 2 - записи в другой файл. 
                    if (path == null)
                    {
                        Console.WriteLine($"{Environment.NewLine}Данные были введены через консоль, сейчас Вам будет предложено ввести путь к новому файлу");
                        goto Link;
                    }
                    else
                    {
                        JsonParser.WriteJson(cars, path);
                    }
                    break;
                case 2:
                Link:
                    path = getAndCheckPath();
                    JsonParser.WriteJson(cars, path);
                    break;
            }
        }
        /// <summary>
        /// Получаем абсолютный путь к файлу.
        /// </summary>
        /// <returns> Абсолютный путь к файлу. </returns>
        private static string getAndCheckPath()
        {
            do
            {
                // Получаем директорию, где находится файл, и проверяем, существует ли она.
                Console.WriteLine($"{Environment.NewLine}Введите директорию, где хотите сохранить файл.{Environment.NewLine}Пример для Windows: C:\\Users\\frubyl\\Desktop\\KDZ\\ClassLibrary");
                string path = Console.ReadLine();
                path = String.IsNullOrEmpty(path) ? "empty" : path;
                DirectoryInfo di = new DirectoryInfo(path);
                // Если не существует, оповещаем пользователя, запрашиваем директорию еще раз.
                if (!di.Exists)
                {
                    Console.WriteLine("Такой директории не существует, повторите попытку!");
                }
                // Если существует, запрашиваем имя файла, формируем абсолютный путь.
                else
                {
                    string fileName = getAndCheckFileName();
                    path = path + Path.DirectorySeparatorChar + fileName + ".json";
                    return path;
                }
            } while (true);
        }
        /// <summary>
        /// Получаем и проверяем имя файла.
        /// </summary>
        /// <returns> Имя файла. </returns>
        private static string getAndCheckFileName()
        {
            do
            {
                Console.WriteLine("Введите имя файла без расширения. Пример: name.");
                string fileName = Console.ReadLine();
                if (!validateFileName(fileName))
                {
                    Console.WriteLine("Недопустимое имя файла, повторите попытку!");
                    continue;
                }
                else { return fileName; }
            } while (true);
        }

        /// <summary>
        /// Проверяем имя файла.
        /// </summary>
        /// <param name="filename"> Имя файла.</param>
        /// <returns> true, если имя корректно, false иначе.</returns>
        private static bool validateFileName(string filename)
        {
            try
            {
                FileStream fs = File.Open(filename, FileMode.Open);
                if (fs != null) fs.Close();
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (Exception)
            {
                return true;
            }
            return true;
        }
    }
}
