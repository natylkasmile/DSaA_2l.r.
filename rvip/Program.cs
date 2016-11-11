using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rvip
{
    class Program
    {
        const int MaxCountCam = 2;
        const int MaxCountTrans = 10;
        Server serv = new Server();
        static int cb = 0;

        static void Main(string[] args)
        {
            int count; float sp;
            Program p = new Program();
 
            //потоки
            for (int i = 0; i < MaxCountCam; i++)
            {
                Thread myThread = new Thread(p.cam1);
                myThread.Start();
       
            }
                        
            Thread.Sleep(100);
            Console.ReadLine();

            p.serv.Display_info();
            Console.Read();
           
        }
        void cam1()
        {
            cb++;
            Console.WriteLine(cb);
            Camera cam = new Camera(cb);  

            for (int i = 0; i < MaxCountTrans; i++)
            {
                int count; float sp;
                sp =cam.Speed_Fixing();
                count =cam.Count_Fixing();               
                Console.WriteLine("Камера" + cam.name.ToString() + " отправляет данные: Средняя скорость " + sp.ToString() + " , количество машин " + count.ToString());
                cam.Send(serv, count, sp);
            }
        }
      
    }
}
