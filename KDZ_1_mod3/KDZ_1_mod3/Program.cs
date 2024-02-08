using AdditionalClasses;
using GetAndSaveData;
using DataProcessing;
class Program
{
    static void Main(string[] args)
    {
        string[] menuItems =
            {
            "Ввести данные",
            "Отсортировать по возрастанию данные по одному из полей",
            "Отсортировать по убыванию данные по одному из полей",
            "Отфильтровать данные по одному из полей",
            "Вывести (сохранить) данные в System.Console или файл",
            "Выйти из программы"
            };
        int menuItemIndex = Menu.CreateMenu(menuItems, "Чтобы проводить операции над данными, введите их, выбрав первый пункт меню");
        List<Car> cars = new List<Car>();
        string? path;
        // При первом выводе меню обязательно получаем данные.
        switch (menuItemIndex)
        {
            case 0:
                cars = GetData.ReceivingData(out path);
                Console.WriteLine("Данные считаны!");
                Thread.Sleep(2500);
                break;
            // Если выбран любой другой пункт, оповещаем пользователя, что нужно ввести данные.
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данные не введены, сейчас Вам предложат ввести данные.");
                Console.ResetColor();
                Thread.Sleep(2500);
                cars = GetData.ReceivingData(out path);
                Console.WriteLine("Данные считаны!");
                Thread.Sleep(2500);
                break;
        };
        do
        {
            menuItemIndex = Menu.CreateMenu(menuItems, "Для вывода результата выберите соответствующий пункт меню после операции над данными.");
            switch (menuItemIndex)
            {
                case 0:
                    cars = GetData.ReceivingData(out path);
                    Console.WriteLine("Данные считаны!");
                    Thread.Sleep(2500);
                    break;
                case 1:
                    cars = Sort.Sorting(cars, true);
                    Console.WriteLine("Данные отсортированы!");
                    Thread.Sleep(2500);
                    break;
                case 2:
                    cars = Sort.Sorting(cars, false);
                    Console.WriteLine("Данные отсортированы!");
                    Thread.Sleep(2500);
                    break;
                case 3:
                    cars = Filter.Filtration(cars);
                    break;
                case 4:
                    PrintOrSaveData.PrintingOrSavingData(cars, path);
                    break;
                case 5: return;
            }
        } while (true);
    }
}