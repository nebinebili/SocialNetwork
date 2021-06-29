using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNamespace;
using PostNamespace;
using UserNamespace;
using ControlNamespace;

namespace MiniProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Control c = new Control();

            try
            {
              c.Start();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
