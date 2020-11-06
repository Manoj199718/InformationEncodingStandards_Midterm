using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Color { get; set; }
        public DateTime Dateof { get; set; }
        public string temp { get; set; }
        private string _DateReceived;
        public string DateReceived
        {
            get
            {
                return _DateReceived;

            }
            set
            {
                _DateReceived = value;
                DateTime datetime;
                if (DateTime.TryParse(_DateReceived, out datetime) == true)
                {
                    Dateof = datetime;
                }
            }
        }

        public void Data()
        {
            Console.WriteLine("En");
            temp = Console.ReadLine();
            ProductId = Convert.ToInt32(temp);
            Name = Console.ReadLine();
            temp = Console.ReadLine();
            Quantity = Convert.ToInt32(temp);
            temp = Console.ReadLine();
            Color = Convert.ToInt32(temp);
            DateReceived = Console.ReadLine();
            Console.WriteLine(DateReceived);

        }
    }
}