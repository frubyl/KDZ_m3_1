using AdditionalClasses;
using System.Text;
using WorkWithJsonFile;
namespace GetAndSaveData
{
    public static class GetData
    {
        /// <summary>
        /// Получение данных.
        /// </summary>
        /// <returns> Лист из объектов.</returns>
        /// <param name="path"> Путь к файлу, из которого была получена информация, если информация была получена из консоли, то значение null. </param>
        public static List<Car> ReceivingData(out string? path)
        {
            do
            {
                try
                {
                    string? input = null;
                    path = null;
                    string[] menuItemst = { "Ввести данные через консоль", "Предоставить путь к файлу для чтения данных" };
                    int menuItemIndex = Menu.CreateMenu(menuItemst, "Выберите, каким образом Вы хотите ввести данные:");
                    switch (menuItemIndex)
                    {
                        case 0:
                            input = getDataFromConsole();
                            break;
                        case 1:
                            input = getDataFromFile(out path);
                            break;
                    }
                    List<Car> cars = JsonParser.ReadJson(input);
                    return cars;
                }
                // Ошибка, которая возникает из-за неправильной структуры.
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Environment.NewLine}Неверный формат, повторите попытку!");
                    Console.ResetColor();
                    Thread.Sleep(2500);
                    continue;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Environment.NewLine}Возникла ошибка, проверьте формат и повторите попытку!");
                    Console.ResetColor();
                    Thread.Sleep(2500);
                    continue;
                }
            } while (true);
        }
        /// <summary>
        /// Получение данных из консоли.
        /// </summary>
        /// <returns> Данные, преобразованные в строку. </returns>
        private static string? getDataFromConsole()
        {
            Console.WriteLine("Для завершения ввода введите пустую строку");
            StringBuilder input = new StringBuilder();
            string? s;
            do
            {
                s = Console.ReadLine();
                input.Append(s);
            } while (s != null & s != String.Empty);
            return input.ToString();
        }
        /// <summary>
        /// Получение данных из консоли.
        /// </summary>
        /// <param name="path"> Путь, по которому были получены данные.</param>
        /// <returns> Данные, преобразованные в строку. </returns>
        private static string getDataFromFile(out string path)
        {
            do
            {
                // Получаем путь и проверяем существование файла.
                Console.WriteLine("Введите абсолютный путь к файлу с данными:");
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Файл не найден, повторите попытку!");
                    Console.ResetColor();
                    Thread.Sleep(2500);
                }
                else
                {
                    try
                    {
                        return readDataFromFile(path);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Возникла непредвиденная ошибка, повторите попытку!");
                        Console.ResetColor();
                        Thread.Sleep(2500);
                        continue;
                    }
                }
            } while (true);
        }
        /// <summary>
        ///  Чтение данных из файла.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <returns> Данные, преобразованные в строку. </returns>
        private static string readDataFromFile(string path)
        {
            StringBuilder input = new StringBuilder();
            using StreamReader dataInput = new StreamReader(path);
            {
                // Перенаправляем стандартный поток ввода.
                Console.SetIn(dataInput);
                while (true)
                {
                    string s = Console.ReadLine();
                    if (s == null) { break; }
                    input.Append(s);
                }
            }
            // Возвращаем стандартный поток ввода.
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            return input.ToString();
        }
    }
}

