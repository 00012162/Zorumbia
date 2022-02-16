using System;
using System.Collections.Generic;
using System.Text;

namespace Zorumbia.DAL
{
    public class RegionPayment
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public int Region { get; set; }
        
        public int Headcount { get; set; }

        public int Limit { get; set; }

        public double Paid { get; set; }
        
        public RegionPayment()
        {
        }
        public RegionPayment(DateTime date, int region, int headcount, int limit, double paid)
        {
            Date = date;
            Region = region;
            Headcount = headcount;
            Limit = limit;
            Paid = paid;
        }
    }
}
