using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Вызов всех задач

        // Задача 1: Конвертер температуры
        ConvertTemperature();

        // Задача 2: Перевод времени
        ConvertTime();

        // Задача 3: Калькулятор возраста
        CalculateAge();

        // Задача 4: Обратный отсчет
        Countdown();

        // Задача 5: Анализ текста
        TextAnalysis();

        // Задача 6: Генератор паролей
        GeneratePassword();

        // Задача 7: Конвертер валют
        ConvertCurrency();

        // Задача 8: Обработка данных о погоде
        ProcessWeatherData();

        // Задача 9: Простая система управления задачами
        TaskManager();

        // Задача 10: API клиент
        CallWeatherAPI().Wait();
    }

    // Задача 1: Конвертер температуры
    static void ConvertTemperature()
    {
        Console.WriteLine("Конвертер температуры");
        Console.WriteLine("1. Цельсий -> Фаренгейт");
        Console.WriteLine("2. Фаренгейт -> Цельсий");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите температуру в Цельсиях:");
                double celsius = Convert.ToDouble(Console.ReadLine());
                double fahrenheit = CelsiusToFahrenheit(celsius);
                Console.WriteLine($"Температура в Фаренгейтах: {fahrenheit}");
                break;
            case 2:
                Console.WriteLine("Введите температуру в Фаренгейтах:");
                double fahrenheitInput = Convert.ToDouble(Console.ReadLine());
                double celsiusOutput = FahrenheitToCelsius(fahrenheitInput);
                Console.WriteLine($"Температура в Цельсиях: {celsiusOutput}");
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    static double CelsiusToFahrenheit(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }

    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    // Задача 2: Перевод времени
    static void ConvertTime()
    {
        Console.WriteLine("Перевод времени");
        Console.WriteLine("1. 12-часовой формат -> 24-часовой формат");
        Console.WriteLine("2. 24-часовой формат -> 12-часовой формат");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите время в 12-часовом формате (например, 02:30 PM):");
                string time12 = Console.ReadLine();
                string time24 = ConvertTo24HourFormat(time12);
                Console.WriteLine($"Время в 24-часовом формате: {time24}");
                break;
            case 2:
                Console.WriteLine("Введите время в 24-часовом формате (например, 14:30):");
                string time24Input = Console.ReadLine();
                string time12Output = ConvertTo12HourFormat(time24Input);
                Console.WriteLine($"Время в 12-часовом формате: {time12Output}");
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    static string ConvertTo24HourFormat(string time12)
    {
        DateTime dateTime = DateTime.ParseExact(time12, "hh:mm tt", null);
        return dateTime.ToString("HH:mm");
    }

    static string ConvertTo12HourFormat(string time24)
    {
        DateTime dateTime = DateTime.ParseExact(time24, "HH:mm", null);
        return dateTime.ToString("hh:mm tt");
    }

    // Задача 3: Калькулятор возраста
    static void CalculateAge()
    {
        Console.WriteLine("Калькулятор возраста");
        Console.WriteLine("Введите дату рождения (гггг-мм-дд):");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());
        DateTime today = DateTime.Today;

        int years = today.Year - birthDate.Year;
        if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day))
        {
            years--;
        }

        int months = today.Month - birthDate.Month;
        if (months < 0)
        {
            months += 12;
        }

        int days = (today - birthDate.AddMonths((today.Year - birthDate.Year) * 12 + today.Month - birthDate.Month)).Days;

        Console.WriteLine($"Возраст: {years} лет, {months} месяцев, {days} дней");
    }

    // Задача 4: Обратный отсчет
    static void Countdown()
    {
        Console.WriteLine("Обратный отсчет");
        Console.WriteLine("Введите количество секунд:");
        int seconds = Convert.ToInt32(Console.ReadLine());

        for (int i = seconds; i >= 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000); // Ждем 1 секунду
        }

        Console.WriteLine("Обратный отсчет завершен!");
    }

    // Задача 5: Анализ текста
    static void TextAnalysis()
    {
        Console.WriteLine("Анализ текста");
        Console.WriteLine("Введите текст:");

        string text = Console.ReadLine();

        int wordCount = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int sentenceCount = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int paragraphCount = text.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

        Console.WriteLine($"Количество слов: {wordCount}");
        Console.WriteLine($"Количество предложений: {sentenceCount}");
        Console.WriteLine($"Количество абзацев: {paragraphCount}");
    }

    // Задача 6: Генератор паролей
    static void GeneratePassword()
    {
        Console.WriteLine("Генератор паролей");
        Console.WriteLine("Введите длину пароля:");
        int passwordLength = Convert.ToInt32(Console.ReadLine());

        string password = GenerateRandomPassword(passwordLength);
        Console.WriteLine($"Сгенерированный пароль: {password}");
    }

    static string GenerateRandomPassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    // Задача 7: Конвертер валют
    static void ConvertCurrency()
    {
        Console.WriteLine("Конвертер валют");
        Console.WriteLine("Введите сумму в долларах США:");
        double usdAmount = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите текущий курс доллара к евро:");
        double exchangeRate = Convert.ToDouble(Console.ReadLine());

        double euroAmount = usdAmount * exchangeRate;
        Console.WriteLine($"Сумма в евро: {euroAmount}");
    }

    // Задача 8: Обработка данных о погоде
    static void ProcessWeatherData()
    {
        Console.WriteLine("Обработка данных о погоде");
        Console.WriteLine("Введите количество дней:");
        int days = Convert.ToInt32(Console.ReadLine());

        double[] temperatures = new double[days];
        for (int i = 0; i < days; i++)
        {
            Console.WriteLine($"Введите температуру для дня {i + 1}:");
            temperatures[i] = Convert.ToDouble(Console.ReadLine());
        }

        double maxTemperature = temperatures.Max();
        double minTemperature = temperatures.Min();
        double averageTemperature = temperatures.Average();

        Console.WriteLine($"Максимальная температура: {maxTemperature}");
        Console.WriteLine($"Минимальная температура: {minTemperature}");
        Console.WriteLine($"Средняя температура: {averageTemperature}");
    }

    // Задача 9: Простая система управления задачами
    static void TaskManager()
    {
        Console.WriteLine("Простая система управления задачами");

        List<string> tasks = new List<string>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Удалить задачу");
            Console.WriteLine("3. Просмотреть задачи");
            Console.WriteLine("4. Редактировать задачу");
            Console.WriteLine("5. Выход");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите новую задачу:");
                    string newTask = Console.ReadLine();
                    tasks.Add(newTask);
                    Console.WriteLine("Задача добавлена.");
                    break;
                case 2:
                    Console.WriteLine("Введите номер задачи для удаления:");
                    int taskNumber = Convert.ToInt32(Console.ReadLine());
                    if (taskNumber >= 1 && taskNumber <= tasks.Count)
                    {
                        tasks.RemoveAt(taskNumber - 1);
                        Console.WriteLine("Задача удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер задачи.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Список задач:");
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                    break;
                case 4:
                    Console.WriteLine("Введите номер задачи для редактирования:");
                    int taskIndex = Convert.ToInt32(Console.ReadLine());
                    if (taskIndex >= 1 && taskIndex <= tasks.Count)
                    {
                        Console.WriteLine("Введите новый текст задачи:");
                        string updatedTask = Console.ReadLine();
                        tasks[taskIndex - 1] = updatedTask;
                        Console.WriteLine("Задача отредактирована.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер задачи.");
                    }
                    break;
                case 5:
                    Console.WriteLine("Завершение работы с системой управления задачами.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    // Задача 10: API клиент


    static async Task CallWeatherAPI()
    {
        Console.WriteLine("API клиент: Получение данных о погоде");

        // Замените YOUR_API_KEY на реальный ключ доступа к OpenWeatherMap API
        string apiKey = "ac0346baa98a0bfd3310ce5d659e5807";
        string city = "London"; // Город для запроса данных о погоде

        using (var httpClient = new HttpClient())
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody); 
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Ошибка при выполнении запроса: {e.Message}");
            }
        }
    }
}




