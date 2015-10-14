using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new CircularBufferT<double>(3);

            ProcessInput(buffer);

            DisplayResult(buffer);
            
        }

        private static void doubleBuffer()
        {
            var buffer = new CircularBuffer(3);

            while (true)
            {
                var parsed = false;
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }

            Console.WriteLine("Buffer: ");

            while (!buffer.isEmpty())
            {
                Console.WriteLine("\t" + buffer.Read());
            }
        }

        

        private static void DisplayResult<T>(CircularBufferT<T> buffer)
        {
            Console.WriteLine("Buffer: ");

            while (!buffer.isEmpty())
            {
                Console.WriteLine("\t" + buffer.Read());
            }
        }

        private static void ProcessInput<T>(CircularBufferT<T> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var parsed = false;
                var input = Console.ReadLine();
                
                if (input != "Q")
                {
                    if (double.TryParse(input, out value))
                    {
                        var converter = TypeDescriptor.GetConverter(typeof(string));
                       var  newValue = converter.ConvertTo(input, typeof(T));

                        AddToBuffer(buffer, (T) newValue);
                    }

                }
                             
                break;
            }
        }

        private static void AddToBuffer<T>(CircularBufferT<T> buffer, T value)
        {
            buffer.Write(value);
        }
    }
}
