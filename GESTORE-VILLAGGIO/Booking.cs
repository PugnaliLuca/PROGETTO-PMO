using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTORE_VILLAGGIO
{
    [Serializable()]
    public class Booking
    {
        //DateTime variable for the date of booking start
        private DateTime bookStart;
        public DateTime BookStart       //bookStart's get and set porperties 
        {
            get { return bookStart; }
            set { bookStart = value; }
        }

        //DateTime variable for the date of booking end
        private DateTime bookEnd;
        public DateTime BookEnd       //bookEnd's get and set porperties  
        {
            get { return bookEnd; }
            set { bookEnd = value; }
        }

        //string for represent the name of the booker
        private string bookerName;
        public string BookerName       //bookerName's get and set properties
        {
            get { return bookerName; }
            set { bookerName = value; }
        }

        //Constructor of Booking class
        public Booking(DateTime newBookStart, DateTime newBookEnd, string name)
        {
            bookStart = newBookStart;
            bookEnd = newBookEnd;
            bookerName = name;
        }

        //constructor without parameter to don't generate 
        //error during XmlSerializer creation
        public Booking()
        {

        }
    }
}
