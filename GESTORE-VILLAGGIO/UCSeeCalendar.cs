using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTORE_VILLAGGIO
{
    public partial class UCSeeCalendar : UserControl
    {
        //list of bolded dates
        List<DateTime> dates = new List<DateTime>();
        //reference to the form containing this User Control
        //passed with Constructor of UCDeleteBookings in file Form1.Designer.cs
        private Form1 form;
        //form's properties
        public Form1 Form
        {
            get => form;
            set => form = value;
        }

        //array containing the labels for see the list 
        public List<Label> arrayLblBook;

        //constructor of the class
        public UCSeeCalendar()
        {
            InitializeComponent();
            arrayLblBook = new List<Label>();
        }

        //method to put booking's label in flowLayoutPanel
        private void ShowBookings( DateTime date)  //data della quale mostrare le prenotazioni
        {
            //clear the flow layout panel containing labels and label's array
            ClearFlowPanAndLblArray();
            
            //showing the Bungalow1's bookings
            arrayLblBook.Add(new Label());
            SetProperty(LastItem(arrayLblBook));
            LastItem(arrayLblBook).Text = "BUNGALOW 1 :";
            flwPanelBookingsList.Controls.Add(LastItem(arrayLblBook));
            SearchAndPrint(form.BungalowsBookings1, date);        //label to separate the services
           
            //showing the Bungalow2's bookings
            arrayLblBook.Add(new Label());
            SetProperty(LastItem(arrayLblBook));
            LastItem(arrayLblBook).Text = "BUNGALOW 2 :";
            flwPanelBookingsList.Controls.Add(LastItem(arrayLblBook));
            SearchAndPrint(form.BungalowsBookings2, date);
            flwPanelBookingsList.Controls.Add(new Label());        //label to separate the services
            
            //showing the Bungalow3's bookings
            arrayLblBook.Add(new Label());
            SetProperty(LastItem(arrayLblBook));
            LastItem(arrayLblBook).Text = "BUNGALOW 3 :";
            flwPanelBookingsList.Controls.Add(LastItem(arrayLblBook));
            SearchAndPrint(form.BungalowsBookings3, date);
            flwPanelBookingsList.Controls.Add(new Label());        //label to separate the services
            
            //showing the Pool's bookings
            arrayLblBook.Add(new Label());
            SetProperty(LastItem(arrayLblBook));
            LastItem(arrayLblBook).Text = "PISCINA :";
            flwPanelBookingsList.Controls.Add(LastItem(arrayLblBook));
            SearchAndPrint(form.PoolsBookings, date);
            flwPanelBookingsList.Controls.Add(new Label());        //label to separate the services
            
            //showing the Field's bookings
            arrayLblBook.Add(new Label());
            SetProperty(LastItem(arrayLblBook));
            LastItem(arrayLblBook).Text = "CAMPI DA GIOCO :";
            flwPanelBookingsList.Controls.Add(LastItem(arrayLblBook));
            SearchAndPrint(form.FieldsBookings, date);
        }

        //search if there is some booking in the selected date, if there is print the name of the booker
        private void SearchAndPrint(List<Booking> list, DateTime date)
        {
            if (!list.Any())
            {
                //if there aren't books the SetProperty print on label
                //  "Non ci sono prenotazioni per questo servizio"
                arrayLblBook.Add(new Label());
                SetProperty(LastItem(arrayLblBook));
                flwPanelBookingsList.Controls.Add(LastItem(arrayLblBook));
            }
            else
            {
                //bool variable to know if qualche prenotazione di quelle 
                //esistemti è stata fatta per il giorno selezionato
                bool thereIsSomeBook = false;
                //cicle to print list's 
                foreach (Booking book in list)
                {
                    //check in the book's list if the selected date is occupied
                    if ((book.BookStart <= date) && (date <= book.BookEnd))
                    {
                        //printing name 
                        arrayLblBook.Add(new Label());
                        SetProperty(LastItem(arrayLblBook), book);
                        flwPanelBookingsList.Controls.Add(LastItem(arrayLblBook));
                        thereIsSomeBook = true;
                    }
                }
                //if there is a book but not in the selected date will be printed
                //only the label :  "Non ci sono prenotazioni per la data selezionata"
                if (!thereIsSomeBook)
                {
                    arrayLblBook.Add(new Label());
                    SetProperty(LastItem(arrayLblBook));
                    LastItem(arrayLblBook).Text = "Non ci sono prenotazioni per la data selezionata";
                    flwPanelBookingsList.Controls.Add(LastItem(arrayLblBook));
                    flwPanelBookingsList.Controls.Add(new Label()); 
                }
                else
                    flwPanelBookingsList.Controls.Add(new Label()); 
            }
        }

        //method to delete all the label in the flowPanelBooking
        private void ClearFlowPanAndLblArray()
        {
            flwPanelBookingsList.Controls.Clear();
            arrayLblBook.Clear();
        }

        //method to set the label's property
        private void SetProperty(Label lbl, Booking book)
        {
            lbl.Size = new Size(320, 20);
            lbl.Visible = true;
            lbl.Text = "Nome :  "+book.BookerName;
            lbl.ForeColor = Color.Black;
            lbl.Font = label1.Font;
        }
        //this variant is called only if the list is empty
        private void SetProperty(Label lbl)
        {
            lbl.Size = new Size(500, 20);
            lbl.Visible = true;
            lbl.Text = "Non ci sono prenotazioni per questo servizio";
            lbl.ForeColor = Color.Black;
            lbl.Font = label1.Font;
        }

        //method to get the last element of a list of LinkLabel
        private Label LastItem(List<Label> list)
        {
            if (list != null)
                return list[(list.Count - 1)];
            else
                return null;
        }

        //method to show if there is some book in the selected date
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            ShowBookings(monthCalendar1.SelectionRange.Start);
        }

        //method to set the User Control
        public void SetUc()
        {
            monthCalendar1.SelectionStart = new DateTime(2020, 1, 1);
            ColorCalendar();
            ShowBookings(monthCalendar1.SelectionStart);
        }

        //method to bold the occupied dates
        private void ColorCalendar()
        {
            //list to put 
            dates = new List<DateTime>();
            //bold all the dates withh a prenotazion of any service
            AddBoldDates(form.BungalowsBookings1);
            AddBoldDates(form.BungalowsBookings2);
            AddBoldDates(form.BungalowsBookings3);
            AddBoldDates(form.PoolsBookings);
            AddBoldDates(form.FieldsBookings);
            if (dates != null)
            {
                DateTime[] dati = form.ConvertListToArray(dates);
                monthCalendar1.BoldedDates = dati;        //bisognerebbe spostare il calendario quando si cambia lista di prenotazioni
                if (dates.Count >= 1)
                    monthCalendar1.SetDate(dates[0]);
            }
        }

        //method to put in dates list the occupied day
        private void AddBoldDates(List<Booking> list)
        {
            foreach (Booking book in list)
            {
                DateTime rememebrStart = book.BookStart;
                while (book.BookStart <= book.BookEnd)
                {
                    dates.Add(book.BookStart);
                    book.BookStart = book.BookStart.AddDays(1);
                }
                book.BookStart = rememebrStart;
            }
        }
    }
}
