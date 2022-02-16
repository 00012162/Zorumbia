using System;
using System.Collections.Generic;
using System.Text;

namespace Zorumbia.DAL
{
    public class SocialWorker
    {

        private string _name;
        private double _hours;

        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name cannot be empty");
                _name = value;
            }
        }
        public double Hours
        {
            get => _hours;
            set
            {
                if (value < 0)
                    throw new Exception("Please, write hours correct");
                _hours = value;
            }
        }

        public RegionPayment Region { get; set; }

        
        public SocialWorker()
        { }

        public SocialWorker(string name, RegionPayment region, double hours )
        {
            Name = name;
            Region = region;
            Hours = hours;
        }

    }
}
