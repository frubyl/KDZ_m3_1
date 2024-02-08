using System.Text;
using AdditionalClasses;
namespace WorkWithJsonFile
{
    public static class JsonParser
    {
        /// <summary>
        /// Обработка json файла.
        /// </summary>
        /// <param name="input"> Строка для обработки. </param>
        /// <returns> Лист созданных объектов. </returns>
        public static List<Car> ReadJson(string? input)
        {
            States currentState = States.None;
            // Словарь для записи информации о текущем объекте.
            Dictionary<string, string?> currentCarInfo = new Dictionary<string, string?>(); ;
            StringBuilder fieldName = new StringBuilder();
            StringBuilder fieldValue = new StringBuilder();
            List<Car> cars = new List<Car>();
            foreach (char sym in input ?? "")
            {
                switch (currentState)
                {
                    case States.None when sym == '[':
                        currentState = States.Start;
                        break;
                    case States.Start when sym == '{':
                        currentState = States.Object;
                        break;
                    case States.Object when sym == '\"':
                        fieldName.Clear();
                        currentState = States.FieldName;
                        break;
                    case States.FieldName when sym != '\"':
                        fieldName.Append(sym);
                        break;
                    case States.FieldName when sym == '\"':
                        currentState = States.FieldNameEnd;
                        break;
                    case States.FieldNameEnd when sym == ':':
                        fieldValue.Clear();
                        currentState = States.FieldValue;
                        break;
                    case States.FieldValue when sym != ',' & sym != '[':
                        fieldValue.Append(sym);
                        break;
                    case States.FieldValue when sym == '[':
                        currentState = States.FieldValueArray;
                        break;
                    case States.FieldValue when sym == ',':
                        currentCarInfo.Add(fieldName.ToString(), fieldValue.ToString());
                        currentState = States.Object;
                        break;
                    case States.FieldValueArray when sym != ']':
                        fieldValue.Append(sym);
                        break;
                    case States.FieldValueArray when sym == ']':
                        currentCarInfo.Add(fieldName.ToString(), fieldValue.ToString().Trim('['));
                        currentState = States.Object;
                        break;
                    // Когда выходим из объекта добавляем его в list, очищаем словарь.
                    case States.Object when sym == '}':
                        // Проверяем, получилось ли создать объект.
                        if (CreateObjFromDict.CreateCar(currentCarInfo, out Car currCar))
                        {
                            cars.Add(currCar);
                        }
                        currentCarInfo.Clear();
                        currentState = States.None;
                        break;
                    case States.None when sym == '{':
                        currentState = States.Object;
                        break;
                    case States.None when sym == ']':
                        currentState = States.End;
                        break;
                };
            }
            // Если нет подходящих объектов или у файла неправильный формат, то генерируем исключение.
            if (currentState != States.End || cars.Count == 0)
            {
                throw new FormatException();
            }
            return cars;
        }
        /// <summary>
        /// Запись данных в файл формата json.
        /// </summary>
        /// <param name="cars"> Объекты для записи. </param>
        /// <param name="path"> Путь к файлу,в который будет записана информация.</param>
        public static void WriteJson(List<Car> cars, string path)
        {
            // Запоминаем кодировку потока вывода.
            var consoleOutputEncoding = Console.OutputEncoding;
            try
            {
                // Меняем поток вывода и записываем данные.
                using StreamWriter writer = new StreamWriter(path);
                Console.SetOut(writer);
                Console.WriteLine("[");
                for (int i = 0; i < cars.Count - 1; i++)
                {
                    Console.WriteLine("{");
                    cars[i].Print();
                    Console.WriteLine("},");
                }
                Console.WriteLine("{");
                cars[cars.Count - 1].Print();
                Console.WriteLine("}");
                Console.WriteLine("]");
                // Возвращаем стандартный поток вывода.
                StreamWriter streamConsole = new StreamWriter(Console.OpenStandardOutput(), consoleOutputEncoding);
                Console.SetOut(streamConsole);
                streamConsole.AutoFlush = true;
                Console.WriteLine("Данные успешно записаны!");
                Thread.Sleep(2500);
            }
            catch (Exception e)
            {
                // Если возникла ошибка во время исполнения, также меняем вывод на стандартный.
                StreamWriter streamConsole = new StreamWriter(Console.OpenStandardOutput(), consoleOutputEncoding);
                Console.SetOut(streamConsole);
                streamConsole.AutoFlush = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.WriteLine("Возникла непредвиденная ошибка, повторите попытку!");
                Console.ResetColor();
                Thread.Sleep(2500);
            }
        }
    }
}
