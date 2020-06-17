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

        public static void LogRandomOdd(string fileName)
        {
    
        }
        public static void LogMatrix(string fileName)
        {
   
        }

        static void ReadMatrix(string fileName)
        {

        }

        static void GetSum(string fileName)
        {
           
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
