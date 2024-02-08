using AdditionalClasses;
namespace DataProcessing
{
    public static class Sort
    {
        /// <summary>
        /// Сортировка.
        /// </summary>
        /// <param name="cars"> Объекты для сортировки. </param>
        /// <param name="ascending"> Если true проводится сортировка по возрастанаию, если false - по убыванию. </param>
        /// <returns> Отсортированный массив. </returns>
        public static List<Car> Sorting(List<Car> cars, bool ascending)
        {
            int index = getFieldIndex();
            switch (index)
            {
                case 0:
                    cars = carIdSortAcsending(cars);
                    break;
                case 1:
                    cars = brandSortAcsending(cars);
                    break;
                case 2:
                    cars = modelSortAcsending(cars);
                    break;
                case 3:
                    cars = yearSortAcsending(cars);
                    break;
                case 4:
                    cars = priceSortAcsending(cars);
                    break;
                case 5:
                    cars = isUsedSortAcsending(cars);
                    break;
                case 6:
                    cars = featuresSortAcsending(cars);
                    break;
            }
            if (!ascending) { cars.Reverse(); }
            return cars;
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
            "is_ised (Предполагается, что true > false)",
            "features (По количеству элементов)"
            };
            int menuItemIndex = Menu.CreateMenu(menuItems, "Выберите поле для сортировки.");
            return menuItemIndex;
        }
        /// <summary>
        /// Сортировка по возрастанию по полю isUsed, предполагается, что true > false.
        /// </summary>
        /// <param name="cars"> Объекты для сортировки. </param>
        /// <returns> Отсортированный массив. </returns>
        private static List<Car> isUsedSortAcsending(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = i + 1; j < cars.Count; j++)
                {
                    if (cars[i].IsUsed)
                    {
                        Car remember = cars[i];
                        cars[i] = cars[j];
                        cars[j] = remember;
                    }
                }
            }
            return cars;
        }
        /// <summary>
        /// Сортировка по возрастанию по полю brand.
        /// </summary>
        /// <param name="cars"> Объекты для сортировки. </param>
        /// <returns> Отсортированный массив. </returns>
        private static List<Car> brandSortAcsending(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = i + 1; j < cars.Count; j++)
                {
                    int result = String.Compare(cars[i].Brand, cars[j].Brand);
                    if (result < 0)
                    {
                        Car remember = cars[i];
                        cars[i] = cars[j];
                        cars[j] = remember;
                    }
                }
            }
            return cars;
        }
        /// <summary>
        /// Сортировка по возрастанию по полю model.
        /// </summary>
        /// <param name="cars"> Объекты для сортировки. </param>
        /// <returns> Отсортированный массив. </returns>
        private static List<Car> modelSortAcsending(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = i + 1; j < cars.Count; j++)
                {
                    int result = String.Compare(cars[i].Model, cars[j].Model);
                    if (result < 0)
                    {
                        Car remember = cars[i];
                        cars[i] = cars[j];
                        cars[j] = remember;
                    }
                }
            }
            return cars;
        }
        /// <summary>
        /// Сортировка по возрастанию по полю carId.
        /// </summary>
        /// <param name="cars"> Объекты для сортировки. </param>
        /// <returns> Отсортированный массив. </returns>
        private static List<Car> carIdSortAcsending(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = i + 1; j < cars.Count; j++)
                {
                    if (cars[i].CarID > cars[j].CarID)
                    {
                        Car remember = cars[i];
                        cars[i] = cars[j];
                        cars[j] = remember;
                    }
                }
            }
            return cars;
        }
        /// <summary>
        /// Сортировка по возрастанию по полю year.
        /// </summary>
        /// <param name="cars"> Объекты для сортировки. </param>
        /// <returns> Отсортированный массив. </returns>
        private static List<Car> yearSortAcsending(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = i + 1; j < cars.Count; j++)
                {
                    if (cars[i].Year > cars[j].Year)
                    {
                        Car remember = cars[i];
                        cars[i] = cars[j];
                        cars[j] = remember;
                    }
                }
            }
            return cars;
        }
        /// <summary>
        /// Сортировка по возрастанию по полю price.
        /// </summary>
        /// <param name="cars"> Объекты для сортировки. </param>
        /// <returns> Отсортированный массив. </returns>
        private static List<Car> priceSortAcsending(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = i + 1; j < cars.Count; j++)
                {
                    if (cars[i].Price > cars[j].Price)
                    {
                        Car remember = cars[i];
                        cars[i] = cars[j];
                        cars[j] = remember;
                    }
                }
            }
            return cars;
        }
        /// <summary>
        /// Сортировка по возрастанию по полю features (по количеству элементов).
        /// </summary>
        /// <param name="cars"> Объекты для сортировки. </param>
        /// <returns> Отсортированный массив. </returns>
        private static List<Car> featuresSortAcsending(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = i + 1; j < cars.Count; j++)
                {
                    if (cars[i].Features.Length > cars[j].Features.Length)
                    {
                        Car remember = cars[i];
                        cars[i] = cars[j];
                        cars[j] = remember;
                    }
                }
            }
            return cars;
        }
    }
}
