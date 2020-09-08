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
    public partial class UCDeleteBookings : UserControl
    {
        //array containing the labels to see the list 
        public List<Label> listLblBook;
      
        //reference to the form containing this User Control
        //passed with Constructor of UCDeleteBookings in file Form1.Designer.cs
        private Form1 form;
        //form's properties
        public Form1 Form
        {
            get => form;
            set => form = value;
        }

        //list used as reference to memorize the actual selected service 
        public List<Booking> actualService = new List<Booking>();
        public List<Booking> ActualService   //actualService's get and set properties
        {
            get { return actualService; }
            set { actualService = value; }
        }

        //constructor of UCDeleteBookings class
        public UCDeleteBookings()
        {
            InitializeComponent();
            listLblBook = new List<Label>();
        }


        //methods to change the booking list and the calendar when the user click on Bungalow1's button
        private void btnBungalow1_Click(object sender, EventArgs e)
        {
            lblBookingList.Text = "Lista prenotazioni Bungalow 1 \r\n(fare click sulla prenotazione da eliminare) :";
            actualService = form.BungalowsBookings1;
            ShowBookings(actualService);
            form.ColorCalendar(actualService, monthCalendar1);
        }

        //method to set the uc when the user open the UC, so the visibility change)
        private void btnBungalow1_VisibleChanged(object sender, EventArgs e)
        {
            btnBungalow1.PerformClick();
        }

        //methods to change the booking list and the calendar when the user click on Bungalow2's button
        private void btnBungalow2_Click(object sender, EventArgs e)
        {
            lblBookingList.Text = "Lista prenotazioni Bungalow 2 \r\n(fare click sulla prenotazione da eliminare) :";
            actualService = form.BungalowsBookings2;
            ShowBookings(actualService);
            form.ColorCalendar(actualService, monthCalendar1);
        }

        //methods to change the booking list and the calendar when the user click on Bungalow3's button
        private void btnBungalow3_Click(object sender, EventArgs e)
        {
            lblBookingList.Text = "Lista prenotazioni Bungalow 3 \r\n(fare click sulla prenotazione da eliminare) :";
            actualService = form.BungalowsBookings3;
            ShowBookings(actualService);
            form.ColorCalendar(actualService, monthCalendar1);
        }

        //methods to change the booking list and the calendar when the user click on swimming pool's button
        private void btnPool_Click(object sender, EventArgs e)
        {
            lblBookingList.Text = "Lista prenotazioni Piscina \r\n(fare click sulla prenotazione da eliminare) :";
            actualService = form.PoolsBookings;
            ShowBookings(actualService);
            form.ColorCalendar(actualService, monthCalendar1);
        }

        //methods to change the booking list and the calendar when the user click on fields's button
        private void btnFields_Click(object sender, EventArgs e)
        {
            lblBookingList.Text = "Lista prenotazioni Campi da gioco \r\n(fare click sulla prenotazione da eliminare) :";
            actualService = form.FieldsBookings;  
            ShowBookings(actualService);
            form.ColorCalendar(actualService, monthCalendar1);
        }

        

        //method to get the last element of a list of Label
        private Label LastItem(List<Label> list)
        {
            if (list != null)
                return list[(list.Count - 1)];
            else
                return null;
        }


        //method to put booking's label in flowLayoutPanel
        private void ShowBookings(List<Booking> list)
        {
            ClearFlowPanAndLblArray();
            if (!list.Any())
            {
                listLblBook.Add(new Label());
                SetProperties(LastItem(listLblBook));
                flwPanelBookingsList.Controls.Add(LastItem(listLblBook));
            }
            else
            {
                //cicle to print list's label
                foreach (Booking book in list)
                {
                    listLblBook.Add(new Label());
                    SetProperties(LastItem(listLblBook), book);
                    flwPanelBookingsList.Controls.Add(LastItem(listLblBook));
                }
            }
        }

        //method to create the content string of the booking list
        private string BuildBookString(Booking book)       
        {
            string ret = null;           
            if(book.BookStart != book.BookEnd)
            {
                ret += "Dal " + book.BookStart.Year+"-" + book.BookStart.Month+"-" + book.BookStart.Day;    
                ret += " Al " + book.BookEnd.Year + "-" + book.BookEnd.Month + "-" + book.BookEnd.Day;
                ret += "   Nome: " + book.BookerName;
            }
            else
            {
                ret += "Il " + book.BookStart.Year + "-" + book.BookStart.Month + "-" + book.BookStart.Day;
                ret += "  Nome: " + book.BookerName;
            }

            return ret;
        }

        //method to set the label's properties
        private void SetProperties(Label lbl, Booking book)
        {
            lbl.Size = new Size(500, 20);
            lbl.Visible = true;
            lbl.Text = BuildBookString(book);           
            lbl.ForeColor = Color.Black;
            lbl.Font = lblBookingList.Font;
            lbl.Click += Label_Click;
        }
        //this variant is called only if the list is empty
        private void SetProperties(Label lbl) 
        {
            lbl.Size = new Size(320, 20);
            lbl.Visible = true;
            lbl.Text = "Non ci sono prenotazioni per questo servizio";
            lbl.ForeColor = Color.Black;
            lbl.Font = lblBookingList.Font;
        }

        //method to clear the flowLayoutPanel and the linkLabel's array
        private void ClearFlowPanAndLblArray()
        {
            flwPanelBookingsList.Controls.Clear();
            listLblBook.Clear();
        }

        //this part will be runned when the user click on a prenotation to delete it
        void Label_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("La prenotazione verrà cencellata. Confermare?", "Conferma eliminazione",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //if the user confirm the cancellation of the booking this function
                //search in all the the label the cliccked one and remove the label 
                //and the booking in sekected service
                int index = listLblBook.IndexOf(sender as Label);              
                Label lbl = listLblBook[index];                                                 
                listLblBook.RemoveAt(index); 
                actualService.RemoveAt(index);                       
                flwPanelBookingsList.Controls.Remove(lbl);
                ShowBookings(actualService);
                form.ColorCalendar(actualService, monthCalendar1);
            }
            
        }

        //method to make the UserContorl ready when the user open it
        //(called in Form 1 when the user click the button to open this UC)
        public void SetUc()
        {
            actualService = form.BungalowsBookings1;
            ShowBookings(actualService);
            form.ColorCalendar(actualService, monthCalendar1);
        }
    }
}
