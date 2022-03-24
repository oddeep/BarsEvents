using System;

namespace BarsEvents
{
    // Publisher
    class SomeWorker
    {
        public event EventHandler<char> OnKeyPressed;
        public void Run()
        {
            Console.Write("Введите символ: ");
            char symbol = Console.ReadKey().KeyChar;

            while (char.ToLower(symbol) != 'c' && char.ToLower(symbol) != 'с')
            {
                OnKeyPressed?.Invoke(this, symbol);
                Console.Write("Введите символ: ");
                symbol = Console.ReadKey().KeyChar;
            }
            Console.WriteLine("\nВыход из цикла.");
        }

    }

    //Subscriber
    class Program
    {
        static void Main(string[] args)
        {
            SomeWorker worker = new SomeWorker();
            worker.OnKeyPressed += (sender, symbol) => Console.WriteLine($"\nВы ввели: {symbol}");
            worker.Run();
        }
    }
}