using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIII_Andreja_Kolesar
{
    class Program
    {
        public static void Function()
        {
            var current = Thread.CurrentThread.Name;
            var threadNum = Convert.ToInt32(current.Split('_')[1]);
            string fileName;
            if (threadNum % 2 == 1)
            {
                fileName = "FileByThread_1";
            }
            else
            {
                fileName = "FileByThread_22";
            }
            switch (threadNum)
            {
                case 1:
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    LogMatrix(fileName);
                    break;
                case 22:
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    LogRandomOdd(fileName);
                    break;
                case 3:
                    ReadMatrix(fileName);
                    break;
                case 44:
                    GetSum(fileName);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method is getting 1000 odd numbers in range 0 to 10000 and prints them into new file with given fileName
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public static void LogRandomOdd(string fileName)
        {
            using (StreamWriter sw = File.CreateText(fileName))
            {
                Random random = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int n;
                    do
                    {
                        n = random.Next(0, 10001);

                    } while (n % 2 == 0);

                    sw.WriteLine(n);
                }
            }

        }

        /// <summary>
        /// This method prints identity matrix 100x100 into new file with given fileName
        /// </summary>
        /// <param name="fileName">name of the file</param>
        public static void LogMatrix(string fileName)
        {
            using (StreamWriter sw = File.CreateText(fileName))
            {
                for (int i = 0; i < 100; i++)
                {
                    StringBuilder line = new StringBuilder();
                    for (int j = 0; j < 100; j++)
                    {
                        if (i == j)
                        {
                            line.Append(1);
                        }
                        else
                        {
                            line.Append(0);
                        }
                    }
                    sw.WriteLine(line);
                }
            }

        }

        /// <summary>
        /// Method for reading data from the file and displaying them in console
        /// </summary>
        /// <param name="fileName"></param>
        static void ReadMatrix(string fileName)
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }


        /// <summary>
        /// Method reads numbers from file with given fileName and calculate sum of all this numbers. 
        /// </summary>
        /// <param name="fileName">Name of our file</param>
        static void GetSum(string fileName)
        {
            //Thread.Sleep(1500);
            int sum = 0;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    int.TryParse(s, out int n);
                    sum += n;
                }
            }
            Console.WriteLine("Sum of all numbers from file {0} is {1}", fileName, sum);
        }

        static void Main(string[] args)
        {

            List<Thread> listOfThreads = new List<Thread>();
            for (int i = 1; i < 5; i++)
            {
                string name;
                if (i % 2 == 1)
                {
                    name = string.Format("Thread_{0}", i);
                }
                else
                {
                    name = string.Format("Thread_{0}{1}", i, i);
                }
                Thread t = new Thread(Function)
                {
                    Name = name
                };
                Console.WriteLine("{0} has been created", name);
                listOfThreads.Add(t);
            }
     

            //start threads from the list with index 0 and 1
            listOfThreads[0].Start();
            listOfThreads[1].Start();


            //finish with threads from the list with index 0 and 1
            listOfThreads[0].Join();
            listOfThreads[1].Join();

            //starting with third and forth threads.
            listOfThreads[2].Start();
            listOfThreads[3].Start();

            //finish threads with index 2 and 3
            listOfThreads[2].Join();
            listOfThreads[3].Join();
            Console.ReadKey();


        }
    }
}
