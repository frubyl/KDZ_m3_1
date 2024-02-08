namespace AdditionalClasses
{
    public class Car
    {
        private readonly int _carID;
        private readonly string _brand;
        private readonly string _model;
        private readonly int _year;
        private readonly double _price;
        private readonly bool _isUsed;
        private readonly string[] _features;

        public int CarID => _carID;

        public string Brand => _brand;

        public string Model => _model;

        public int Year => _year;

        public double Price => _price;

        public bool IsUsed => _isUsed;

        public string[] Features => _features;

        /// <summary>
        /// Метод для вывода данных об объекте.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"\"car_id\": {_carID},");
            Console.WriteLine($"\"brand\": \"{_brand}\",");
            Console.WriteLine($"\"model\": \"{_model}\",");
            Console.WriteLine($"\"year\": {_year},");
            Console.WriteLine($"\"price\": {_price}".Replace(',', '.') + ",");
            Console.WriteLine($"\"is_used\": {_isUsed},".ToLower());
            printFeatures();
        }
        /// <summary>
        /// Метод для вывода данных массива.
        /// </summary>
        private void printFeatures()
        {
            Console.WriteLine("\"features\": [");
            for (int i = 0; i < _features.Length - 1; i++)
            {
                Console.WriteLine("\"" + _features[i] + "\"" + ",");
            }
            Console.WriteLine("\"" + _features[_features.Length - 1] + "\"");
            Console.WriteLine("]");
        }
        /// <summary>
        /// Конструктор, инициализирующий все поля.
        /// </summary>
        /// <exception cref="ArgumentException"> Генерирует исключение, если хотя бы одно поле null. </exception>
        public Car(int? carID, string? brand, string? model, int? year, double? price, bool? isUsed, string[]? features)
        {
            _carID = carID ?? throw new ArgumentException();

            _brand = brand ?? throw new ArgumentException();

            _model = model ?? throw new ArgumentException();

            _year = year ?? throw new ArgumentException();

            _price = price ?? throw new ArgumentException();

            _isUsed = isUsed ?? throw new ArgumentException();

            _features = features ?? throw new ArgumentException();
        }
        public Car() { }
    }
}