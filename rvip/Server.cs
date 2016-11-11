using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rvip
{
    public class Server: CollectionBase
    {
        
        ConcurrentBag<string> cb_speed = new ConcurrentBag<string>();
        ConcurrentBag<string> cb_count = new ConcurrentBag<string>();

        public void Get_info(float av_speed, int count)
        {
            Console.WriteLine("Сервер принимает: Скорость " + av_speed.ToString() +" Количество " + count.ToString());
            cb_speed.Add(av_speed.ToString());
            cb_count.Add(count.ToString());
        }
        public void Save_info()
        {

        }
        public void Display_info()
        {
            Console.WriteLine("Список средних скоростей:");
            foreach (string sp in cb_speed)
                Console.Write(sp.ToString() + " ");
            Console.WriteLine();
            Console.WriteLine("Список Количесва машин:");
            foreach (string coun in cb_count)
                Console.Write(coun.ToString()+ " ");
        }
    }
}
