using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTORE_VILLAGGIO
{
    public partial class Form1 : Form
    {
        //Bungalow1's booking dynamic list 
        private List<Booking> bungalowsBookings1 = new List<Booking>();
        public List<Booking> BungalowsBookings1  //bungalowsBookings1's get and set properties
        {
            get { return bungalowsBookings1; }
            set { bungalowsBookings1 = value; }
        }

        //Bungalow2's booking dynamic list 
        private List<Booking> bungalowsBookings2 = new List<Booking>();
        public List<Booking> BungalowsBookings2  //bungalowsBookings2's get and set properties
        {
            get { return bungalowsBookings2; }
            set { bungalowsBookings2 = value; }
        }

        //Bungalow3's booking dynamic list 
        private List<Booking> bungalowsBookings3 = new List<Booking>();
        public List<Booking> BungalowsBookings3    //bungalowsBookings3's get and set properties
        {
            get { return bungalowsBookings3; }
            set { bungalowsBookings3 = value; }
        }

        //Swimming pool's booking dynamic list 
        private List<Booking> poolsBookings = new List<Booking>();
        public List<Booking> PoolsBookings      //poolsBooking's get and set properties
        {
            get { return poolsBookings; }
            set { poolsBookings = value; }
        }
        
        //Fields's booking dynamic list 
        private List<Booking> fieldsBookings = new List<Booking>();
        public List<Booking> FieldsBookings   //fieldsBooking's get and set properties
        {
            get { return fieldsBookings; }
            set { fieldsBookings = value; }
        }
        //variable to manage the dropdown panel
        private bool isCollapsed = false;

        private ReaderWriter rw = ReaderWriter.GetInstance();

        //constructor of Form1 class
        public Form1()
        {
            InitializeComponent();
            //passing the reference of this form to the User Control's field
            this.rw.Form = this;
            this.ucDeleteBookings1.Form = this;
            this.ucAddBookings1.Form = this;
            this.ucSeeCalendar1.Form = this;
            //call the method to read data from xml file and put 
            //the lists in the specific data structure
            List<List<Booking>> list = rw.GetData();
            if (list[0].Any())
                bungalowsBookings1 = list[0];
            if (list[1].Any())
                bungalowsBookings2 = list[1];
            if (list[2].Any())
                bungalowsBookings3 = list[2];
            if (list[3].Any())
                poolsBookings = list[3];
            if (list[4].Any())
                fieldsBookings = list[4];
            //set the all the User Control
            ucAddBookings1.SetUc();
            ucDeleteBookings1.SetUc();
            ucSeeCalendar1.SetUc();
            //add a new EventHandler to the application 
            //to save data before closing the program
            Application.ApplicationExit += new EventHandler(ClosingOperations);
        }

        //method to change the size of the panel
        private void btnManageBookings_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlDropDown.Size = pnlDropDown.MinimumSize;
                isCollapsed = false;
            }
            else
            {
                pnlDropDown.Size = pnlDropDown.MaximumSize;
                isCollapsed = true;
            }
        }

        //method to visualize and set the UserControl for the selected function
        private void btnSeeCalendar_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                isCollapsed = false;
                pnlDropDown.Size = pnlDropDown.MinimumSize;
            }
            ucSeeCalendar1.Show();
            ucAddBookings1.Hide();                          
            ucDeleteBookings1.Hide();
            ucSeeCalendar1.SetUc();
        }

        //method to visualize and set the UserControl for the selected function
        private void btnAddBookings_Click(object sender, EventArgs e)
        {
            ucAddBookings1.Show();
            ucDeleteBookings1.Hide();       
            ucSeeCalendar1.Hide();
            ucAddBookings1.SetUc();
        }

        //method to visualize and set the UserControl for the selected function
        private void btnDeleteBookings_Click(object sender, EventArgs e)
        {
            ucAddBookings1.Hide();
            ucSeeCalendar1.Hide();
            ucDeleteBookings1.Show();         
            ucDeleteBookings1.SetUc();          
        }

        //method to perform when the application is about to closa
        private void ClosingOperations(object sender, EventArgs e)
        {
            rw.SaveData(/*bungalowsBookings1, bungalowsBookings2, bungalowsBookings3,
                        poolsBookings, fieldsBookings*/);
        }

        //method to bold the occupied dates 
        //shared between add and delete User Cntrols
        public void ColorCalendar(List<Booking> list, MonthCalendar monthCalendar)
        {
            // new two collections to put inside the occupied days
            List<DateTime> dates = new List<DateTime>();
            DateTime[] dati;

            foreach (Booking book in list)
            {
                //for every book in the list the dates are copied in the specific list dates
                DateTime rememebrStart = book.BookStart;
                while (book.BookStart <= book.BookEnd)
                {
                    dates.Add(book.BookStart);
                    book.BookStart = book.BookStart.AddDays(1);
                }
                book.BookStart = rememebrStart;
            }
            dati = ConvertListToArray(dates);
            monthCalendar.BoldedDates = dati;
            //if there are some occupied days the calendar visualize these days
            if (dates.Count >= 1)
                monthCalendar.SetDate(dates[0]);
        }

        //method to convert List<DateTime> in DateTime[]
        //used in the above function and used by UCSeeCalendar
        public DateTime[] ConvertListToArray(List<DateTime> list)
        {
            DateTime[] retDates = new DateTime[list.Count];
            for (int i = 0; i < (list.Count); i++)
            {
                retDates[i] = list[i];
            }
            return retDates;
        }

    }
}
