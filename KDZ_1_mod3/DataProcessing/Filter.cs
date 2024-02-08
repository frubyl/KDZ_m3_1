using AdditionalClasses;
namespace DataProcessing
{
    public static class Filter
    {
        /// <summary>
        /// Фильтр.
        /// </summary>
        /// <param name="cars"> Объекты для фильтрации. </param>
        /// <returns> Отфильтрованный лист. </returns>
        public static List<Car> Filtration(List<Car> cars)
        {
            int menuIndex = getFieldIndex();
            string[] fields = getFilterData();
            List<Car> filteredData = new List<Car>();
            switch (menuIndex)
            {
                case 0:
                    filteredData = carIdFilter(cars, fields);
                    break;
                case 1:
                    filteredData = brandFilter(cars, fields);
                    break;
                case 2:
                    filteredData = modelFilter(cars, fields);
                    break;
                case 3:
                    filteredData = yearFilter(cars, fields);
                    break;
                case 4:
                    filteredData = priceFilter(cars, fields);
                    break;
                case 5:
                    filteredData = isUsedFilter(cars, fields);
                    break;
                case 6:
                    filteredData = featuresFilter(cars, fields);
                    break;
            };
            // Если нет подходящих строк, возвращаем изначальный массив.
            if (filteredData.Count == 0)
            {
                Console.WriteLine("Нет подходящих объектов, данные останутся без изменений");
                Thread.Sleep(2500);
                return cars;
            }
            Console.WriteLine("Данные отфильтрованы!");
            Thread.Sleep(2500);
            return filteredData;
        }
        /// <summary>
        /// Получаем индекс поля для фильтра.
        /// </summary>
        /// <returns> Индекс поля для фильтра. </returns>
        private static int getFieldIndex()
        {
            string[] menuItems =
            {
            "car_id",
            "brand",
            "model",
            "year",
            "price",
            "is_ised",
            "features"
            };
            int menuItemIndex = Menu.CreateMenu(menuItems, "Выберите поле для фильтра.");
            return menuItemIndex;
        }
        /// <summary>
        /// Получаем данные, по которым будем фильтровать.
        /// </summary>
        /// <returns> Массив строк, которые должны содержаться в поле. </returns>
        private static string[] getFilterData()
        {
            do
            {
                Console.WriteLine("Введите через запятую, данные для фильтра");
                string s = Console.ReadLine();
                if (s == String.Empty)
                {
                    Console.WriteLine("Пустая строка, повторите попытку!");
                }
                // Убираем лишние пробелы.
                else
                {
                    string[] input = s.Split(',');
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = input[i].Trim();
                    }
                    return input;
                }
            } while (true);
        }
        /// <summary>
        /// Фильтр по полю carId.
        /// </summary>
        /// <param name="cars"> Объекты для фильтрации. </param>
        /// <param name="fields"> Массив строк, которые должны содержаться в поле. </param>
        /// <returns> Отфильтрованный список. </returns>
        private static List<Car> carIdFilter(List<Car> cars, string[] fields)
        {
            List<Car> ans = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                // flag - переменная которая показывает, подходит объект или нет.
                bool flag = true;
                for (int j = 0; j < fields.Length; j++)
                {
                    if (!cars[i].CarID.ToString().Contains(fields[j]))
                    {
                        // Если хотя бы одна строка из fields отсутсвует, объект не подходит, выходим из цикла.
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ans.Add(cars[i]);
                }
            }
            return ans;
        }
        /// <summary>
        /// Фильтр по полю brand.
        /// </summary>
        /// <param name="cars"> Объекты для фильтрации. </param>
        /// <param name="fields"> Массив строк, которые должны содержаться в поле. </param>
        /// <returns> Отфильтрованный список. </returns>
        private static List<Car> brandFilter(List<Car> cars, string[] fields)
        {
            List<Car> ans = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                // flag - переменная которая показывает, подходит объект или нет.
                bool flag = true;
                for (int j = 0; j < fields.Length; j++)
                {
                    if (!cars[i].Brand.Contains(fields[j]))
                    {
                        // Если хотя бы одна строка из fields отсутсвует, объект не подходит, выходим из цикла.
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ans.Add(cars[i]);
                }
            }
            return ans;
        }
        /// <summary>
        /// Фильтр по полю model.
        /// </summary>
        /// <param name="cars"> Объекты для фильтрации. </param>
        /// <param name="fields"> Массив строк, которые должны содержаться в поле. </param>
        /// <returns> Отфильтрованный список. </returns>
        private static List<Car> modelFilter(List<Car> cars, string[] fields)
        {
            List<Car> ans = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                // flag - переменная которая показывает, подходит объект или нет.
                bool flag = true;
                for (int j = 0; j < fields.Length; j++)
                {
                    if (!cars[i].Model.Contains(fields[j]))
                    {
                        // Если хотя бы одна строка из fields отсутсвует, объект не подходит, выходим из цикла.
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ans.Add(cars[i]);
                }
            }
            return ans;
        }
        /// <summary>
        /// Фильтр по полю year.
        /// </summary>
        /// <param name="cars"> Объекты для фильтрации. </param>
        /// <param name="fields"> Массив строк, которые должны содержаться в поле. </param>
        /// <returns> Отфильтрованный список. </returns>
        private static List<Car> yearFilter(List<Car> cars, string[] fields)
        {
            List<Car> ans = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                // flag - переменная которая показывает, подходит объект или нет.
                bool flag = true;
                for (int j = 0; j < fields.Length; j++)
                {
                    if (!cars[i].Year.ToString().Contains(fields[j]))
                    {
                        // Если хотя бы одна строка из fields отсутсвует, объект не подходит, выходим из цикла.
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ans.Add(cars[i]);
                }
            }
            return ans;
        }
        /// <summary>
        /// Фильтр по полю price.
        /// </summary>
        /// <param name="cars"> Объекты для фильтрации. </param>
        /// <param name="fields"> Массив строк, которые должны содержаться в поле. </param>
        /// <returns> Отфильтрованный список. </returns>
        private static List<Car> priceFilter(List<Car> cars, string[] fields)
        {
            List<Car> ans = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                // flag - переменная которая показывает, подходит объект или нет.
                bool flag = true;
                for (int j = 0; j < fields.Length; j++)
                {
                    if (!cars[i].Price.ToString().Contains(fields[j]))
                    {
                        // Если хотя бы одна строка из fields отсутсвует, объект не подходит, выходим из цикла.
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ans.Add(cars[i]);
                }
            }
            return ans;
        }
        /// <summary>
        /// Фильтр по полю isUsed.
        /// </summary>
        /// <param name="cars"> Объекты для фильтрации. </param>
        /// <param name="fields"> Массив строк, которые должны содержаться в поле. </param>
        /// <returns> Отфильтрованный список. </returns>
        private static List<Car> isUsedFilter(List<Car> cars, string[] fields)
        {
            List<Car> ans = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                // flag - переменная которая показывает, подходит объект или нет.
                bool flag = true;
                for (int j = 0; j < fields.Length; j++)
                {
                    if (!cars[i].IsUsed.ToString().Contains(fields[j]))
                    {
                        // Если хотя бы одна строка из fields отсутсвует, объект не подходит, выходим из цикла.
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ans.Add(cars[i]);
                }
            }
            return ans;
        }
        /// <summary>
        /// Фильтр по полю features.
        /// </summary>
        /// <param name="cars"> Объекты для фильтрации. </param>
        /// <param name="fields"> Массив строк, которые должны содержаться в поле. </param>
        /// <returns> Отфильтрованный список. </returns>
        private static List<Car> featuresFilter(List<Car> cars, string[] fields)
        {
            List<Car> ans = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                // flag - переменная которая показывает, подходит объект или нет.
                bool flag = true;
                for (int j = 0; j < fields.Length; j++)
                {
                    // Проверяем, входит ли строка из fields, хотя бы в один элемент массива.
                    bool flagContainsField = false;
                    foreach (string s in cars[i].Features)
                    {
                        if (s.Contains(fields[j]))
                        {
                            flagContainsField = true;
                            break;
                        }
                    }
                    if (!flagContainsField)
                    {
                        // Если строка не входит ни в один элемент массива, объект не подходит.
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ans.Add(cars[i]);
                }
            }
            return ans;
        }
    }
}