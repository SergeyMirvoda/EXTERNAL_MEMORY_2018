using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 1_000_000 * 100;

            //Генерилка тестовых данных
            //using (var file1 = new StreamWriter("100m.txt"))
            //{
            //    for (var i = 0; i < count; i++)
            //    {
            //        file1.WriteLine(i);
            //    }
            //}
            int searchValue = count / 2;
            var fileName = "100m.txt";
            var sw = Stopwatch.StartNew();

            using (var reader = new StreamReader(fileName))
            {
                int lineIndex = -1;
                while (reader.Peek() >= 0)
                {
                    lineIndex++;
                    var line = reader.ReadLine();
                    if (line != null && int.Parse(line) == searchValue)
                    {
                        Console.WriteLine("linear search done in: " + sw.Elapsed);
                        break;
                    }
                }
            }
            sw = Stopwatch.StartNew();
            using (var reader = new StreamReader(fileName))
            {
                int lineIndex = -1;

                long lastPos = reader.BaseStream.Seek(0, SeekOrigin.End);
                Console.WriteLine(lastPos);
                var line = reader.ReadLine(); // consume curr partial line
                Console.WriteLine(line);
                var offset = lastPos / 2;
                reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                line = reader.ReadLine(); // consume curr partial line
                Console.WriteLine(line);
                var end = false;
                var half = count / 2;
                while (!end)
                {
                    var value = int.Parse(File.ReadLines(fileName).Skip(half).Take(1).First());
                    if (value > 10)
                    {
                        half = half / 2;
                    }
                    else
                    {
                        var values = File.ReadLines(fileName).Skip(half).Take(half * 2).ToList();
                        foreach (var v in values)
                        {
                            if (int.Parse(v) == 10)
                            {
                                Console.WriteLine("binary search done in " + sw.Elapsed);
                                break;
                            }
                        }
                        end = true;
                    }
                }
                Console.WriteLine(line);
                //while (reader.Peek()>=0)
                //{
                //    lineIndex++;
                //    var line = reader.ReadLine();

                //    if (line != null && int.Parse(line) == 10)
                //    {
                //        indexes.Add(lineIndex);
                //    }
                //}
            }
            Console.Read();
        }
        
    }
}
