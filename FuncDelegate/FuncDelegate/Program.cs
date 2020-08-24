using System;
using System.Collections.Generic;

namespace FuncDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            // should be a list as the method signature expects
            var list = new List<int> { 1, 2, 3 };

            var printer = new PrintListToConsole<int>();
            printer.SetRenderFunc(o => "Number: " + o + "\n");
            printer.Print(list);
            Console.Read();
        }
    }

    class PrintListToConsole<T>
    {
        private Func<T, string> _renderFunc;

        public void SetRenderFunc(Func<T, String> r)
        {
            // this is the point where we can set the render mechanism
            _renderFunc = r;
        }

        public void Print(List<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(_renderFunc(item));
            }
        }
    }
}
