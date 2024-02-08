using AdditionalClasses;
namespace WorkWithJsonFile
{
    public static class CreateObjFromDict
    {
        /// <summary>
        ///  Создаем объект с помощью данных из словаря.
        /// </summary>
        /// <param name="dict"> Словарь с данными. </param>
        /// <param name="car"> Созданный объект. </param>
        /// <returns> true, удалось создать объект, false иначе.</returns>
        public static bool CreateCar(Dictionary<string, string?> dict, out Car car)
        {
            car = new Car();
            try
            {
                // Получаем значения из словаря, если не удалось получить, то значение null.
                // Если у поля недопустимое или пустое значение, присваиваем null.
                string? brand = dict.TryGetValue("brand", out string b) && !(b is null) && b.Trim().Trim('"').Trim().Length != 0 ? b.Trim(' ').Trim('"') : null;
                string? model = dict.TryGetValue("model", out string m) && !(m is null) && m.Trim().Trim('"').Trim().Length != 0 ? m.Trim(' ').Trim('"') : null;

                string? carIDDict = dict.TryGetValue("car_id", out string id) ? id : null;
                int? carID = int.TryParse(carIDDict, out int c) && c > 0 ? c : null;

                string? yearDict = dict.TryGetValue("year", out string? y) ? y : null;
                int? year = int.TryParse(yearDict, out int ye) && ye > 0 ? ye : null;

                string? priceDict = dict.TryGetValue("price", out string? p) ? p.Replace('.', ',') : null;
                double? price = double.TryParse(priceDict, out double pr) && pr > 0 ? pr : null;

                string? isUsedDict = dict.TryGetValue("is_used", out string? u) ? u : null;
                bool? isUsed = bool.TryParse(isUsedDict, out bool bo) ? bo : null;

                string? featuresDict = dict.TryGetValue("features", out string feat) ? feat : null;
                string[]? features = null;
                if (!(featuresDict is null))
                {
                    featuresDict = featuresDict.Trim().Trim(']').Trim('[');
                    features = featuresDict.Split(',').Length != 0 ? featuresDict.Split(',') : null;
                    if (features != null)
                    {
                        for (int i = 0; i < features.Length; i++)
                        {
                            features[i] = features[i].Trim().Trim('"');
                        }
                    }
                }
                // Создаем объект.
                car = new Car(carID, brand, model, year, price, isUsed, features);
                return true;
            }
            // Если не удалось создать объект, генерируем исключение.
            catch (ArgumentException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
