using AP204_FileStream.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AP204_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {

            #region FileStream

            //string filePath  = Path.Combine(@"C:\Users\Lenovo\Desktop\ap204Directory","text.txt");
            ////Console.WriteLine(filePath);
            //string path = @"C:\Users\Lenovo\Desktop\ap204Directory";
            //string anotherPath = Path.Combine(@"C:\Users\Lenovo\Desktop\ap204Directory","Tural");

            //string anotherFilepath = Path.Combine(@"C:\Users\Lenovo\Desktop\ap204Directory", "Tural","datas.txt");
            //string dbPath = Path.Combine(@"C:\Users\Lenovo\Desktop\ap204Directory", "Tural","Db.txt");
            //string privateTural = Path.Combine(@"C:\Users\Lenovo\Desktop\ap204Directory", "Tural","shexsi.txt");
            //string galeryPath = Path.Combine(@"C:\Users\Lenovo\Desktop\ap204Directory", "Fatima","galery.txt");


            //StreamWriter streamWriter = new StreamWriter(anotherFilepath,true);
            //for (int i = 0; i < 3; i++)
            //{
            //    streamWriter.WriteLine("Product " + i);
            //}
            //streamWriter.Close();

            //StreamReader streamReader = new StreamReader(anotherFilepath);

            //string data = streamReader.ReadToEnd();
            //Console.WriteLine(data);

            //streamReader.Close();

            //Desctruction
            //using (StreamWriter streamWriter = new StreamWriter(anotherFilepath, true))
            //{
            //    for (int i = 5; i < 10; i++)
            //    {
            //        streamWriter.WriteLine("Product " + i);
            //    }
            //}
            //using (StreamReader streamReader = new StreamReader(anotherFilepath))
            //{
            //    string data = streamReader.ReadToEnd();
            //    Console.WriteLine(data);
            //}


            //streamWriter.Flush();


            //Directory.CreateDirectory(anotherPath);
            //File.Create(filePath);
            //File.Create(dbPath);
            //File.Create(anotherFilepath);
            //File.Create(privateTural);
            //File.Create(galeryPath);

            //foreach (var item in Directory.GetFiles(@"C:\Users\Lenovo\Desktop\ap204Directory"))
            //{
            //    Console.WriteLine(item);
            //}
            //Directory.Delete(path, true);
            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //}
            //else
            //{
            //    Console.WriteLine("Bele bir fayl yoxdu");
            //}

            //FileStream fileStream = new FileStream("path example", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            //string text = "This is example text";
            //byte[] byteArr = Encoding.UTF8.GetBytes(text);
            //foreach (var item in byteArr)
            //{
            //    Console.WriteLine(item);
            //}
            //fileStream.Write(byteArr, 0, byteArr.Length);
            //fileStream.Close();
            #endregion

            #region Serialize and Deserialize
            Computer computer = new Computer { Id = 1,Brand = "ASUS",Ram = "8GB", GraphicCard="RTX2090",Price = 3000.20 };
            Computer computer1 = new Computer { Id = 2,Brand = "ACER",Ram = "8GB", GraphicCard="UHDGraphics",Price = 1500.20 };
            Computer computer2 = new Computer { Id = 3,Brand = "MSI",Ram = "32GB", GraphicCard="RTX3090",Price = 3000.20 };
            Computer computer3 = new Computer { Id = 4,Brand = "Lenova",Ram = "16GB", GraphicCard="AMD RYZEN 7",Price = 5000.20 };

            OrderItem orderItem = new OrderItem { Id = 1, Computer = computer, Price = computer.Price };
            OrderItem orderItem1 = new OrderItem { Id = 2, Computer = computer1, Price = computer1.Price };
            OrderItem orderItem2 = new OrderItem { Id = 3, Computer = computer2, Price = computer2.Price };
            OrderItem orderItem3 = new OrderItem { Id = 4, Computer = computer3, Price = computer3.Price };

            Order order = new Order
            {
                Id = 1,
                OrderItems = new List<OrderItem>()
            {
                orderItem,
                orderItem1,
                orderItem2,
                orderItem3
            },
                TotalPrice = 12500.50
            };


            var orderStr = JsonConvert.SerializeObject(order);

            //using (StreamWriter sw = new StreamWriter(@"C:\Users\Lenovo\source\repos\AP204_FileStream\AP204_FileStream\Datas\data.json",true))
            //{
            //    sw.Write(orderStr);
            //}

            string result;
            using (StreamReader sr = new StreamReader(@"C:\Users\Lenovo\source\repos\AP204_FileStream\AP204_FileStream\Datas\data.json"))
            {
                result = sr.ReadLine();
            }

            Order orderDes = JsonConvert.DeserializeObject<Order>(result);

            //Console.WriteLine(orderDes.TotalPrice);


            foreach (var item in orderDes.OrderItems)
            {
                Console.WriteLine(item.Computer.Brand);
            }

            #endregion
        }
    }
}
