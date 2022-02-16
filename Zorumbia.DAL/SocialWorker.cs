using System;
using System.Collections.Generic;
using System.Text;

namespace Zorumbia.DAL
{
    public class SocialWorker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RegionPayment Region { get; set; }

        public double Hours { get; set; }
        
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
