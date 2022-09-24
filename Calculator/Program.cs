using System;

namespace Calculator
{
    class Calculator
    {       
        public static double DoOperation(double num1, double num2, string op) // Присвоение числам тип данных
        {            
            double result = double.NaN; // Значение по умолчанию — «не число», если операция, такая как деление, может привести к ошибке..
           
            switch (op) // Используйте оператор switch, чтобы сделать расчёт.
            {               
                case "a": // Код,выполняемый если выражение имеет значение a
                    result = num1 + num2;
                    break; // выход из команды
                case "s": // Код,выполняемый если выражение имеет значение s
                    result = num1 - num2;
                    break; // выход из команды
                case "m": // Код,выполняемый если выражение имеет значение m
                    result = num1 * num2;
                    break; // выход из команды
                case "d": // Код,выполняемый если выражение имеет значение d
                    if (num2 != 0) // Попросите пользователя ввести ненулевой делитель.
                    {
                        result = num1 / num2;
                    }
                    break;// выход из команды
                default: // Вернуть текст для неверного ввода параметра.
                    break;// выход из команды
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Консольный калькулятор в C#\r");// Отображать заголовок как приложение консольноuj калькулятора C#.
            Console.WriteLine("------------------------\n"); // Пропуск
            while (!endApp) // Цикл
            {
                string numInput1 = ""; // Объявление переменной "пустой".
                string numInput2 = "";
                double result = 0;
               
                Console.Write("Введите число и нажмите клавишу Enter:\n"); // Попросите пользователя ввести первое число.
                numInput1 = Console.ReadLine(); // Считывание строки 

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1)) // Цикл
                {
                    Console.Write("Это недопустимый ввод. Пожалуйста, введите целое число:\n");
                    numInput1 = Console.ReadLine(); // Считывание строки 
                }
               
                Console.Write("Введите другое чсло и нажмите клавишу Enter:\n"); // Попросите пользователя ввести второе число.
                numInput2 = Console.ReadLine(); // Считывание строки 

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2)) // Цикл
                {
                    Console.Write("Это недопустимый ввод. Пожалуйста, введите целое число:\n ");
                    numInput2 = Console.ReadLine(); // Считывание строки 
                }
                
                Console.WriteLine("Выберите оператора из следующего списка:"); // Попросите пользователя выбрать оператора.
                Console.WriteLine("\ta - Сложить");
                Console.WriteLine("\ts - Вычесть");
                Console.WriteLine("\tm - Умножить");
                Console.WriteLine("\td - Разделять");
                Console.Write("Ваш вариант? ");

                string op = Console.ReadLine(); // Считывание строки 

                try // Блок для ошибок
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result)) //Цикл
                    {
                        Console.WriteLine("Эта операция приведет к математической ошибке.\n");
                    }
                    else Console.WriteLine("Ваш результат: {0:0.##}\n", result); // Форматированный вывод
                }
                catch (Exception e) // Блок для ошибок
                {
                    Console.WriteLine("О, нет! Произошло исключение при попытке сделать математику.\n - Подробности: " + e.Message);
                }
                Console.WriteLine("------------------------\n"); // Пропуск
              
                Console.Write("Нажмите «n» и Enter, чтобы закрыть приложение, или нажмите любую другую клавишу и Enter, чтобы продолжить.: ");   // Подождите, пока пользователь ответит, прежде чем закрыть.
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Дружественный межстрочный интервал.
            }
            return; // Возвращение в начало
        }
    }
}