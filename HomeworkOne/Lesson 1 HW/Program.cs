using System;

namespace HomeworkOne
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var e in FakeEventRepository.Events)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
