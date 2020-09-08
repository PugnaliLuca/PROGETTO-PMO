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
    public partial class UCAddBookings : UserControl
    {

        //reference to the form containing this User Control
        //passed with Constructor of UCDeleteBookings in file Form1.Designer.cs
        private Form1 form;
        public Form1 Form      //form's get and set properties
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

        //constructor of this User Control
        public UCAddBookings()
        {
            InitializeComponent();
        }

        //methods to change the booking list and the calendar when the user click on Bungalow1's button
        private void btnBungalow1_Click(object sender, EventArgs e)       //ochhio che è public
        {
            lblNewBook.Text = "Nuova prenotazione Bungalow 1 :";
            ShowComboBoxLabel();
            actualService = form.BungalowsBookings1;
            form.ColorCalendar(form.BungalowsBookings1, monthCalendar1);
        }

        //method to set the uc when the user open the UC, so the visibility change)
        private void btnBungalow1_VisibleChanged(object sender, EventArgs e)
        {
            btnBungalow1.PerformClick();
        }

        //methods to change the booking list and the calendar when the user click on Bungalow2's button
        private void btnBungalow2_Click(object sender, EventArgs e)
        {
            lblNewBook.Text = "Nuova prenotazione Bungalow 2 :";
            ShowComboBoxLabel();
            actualService = form.BungalowsBookings2;
            form.ColorCalendar(form.BungalowsBookings2, monthCalendar1);
        }

        //methods to change the booking list and the calendar when the user click on Bungalow3's button
        private void btnBungalow3_Click(object sender, EventArgs e)
        {
            lblNewBook.Text = "Nuova prenotazione Bungalow 3 :";
            ShowComboBoxLabel();
            actualService = form.BungalowsBookings3;
            form.ColorCalendar(form.BungalowsBookings3, monthCalendar1);
        }

        //methods to change the booking list and the calendar when the user click on Pool's button
        private void btnPool_Click(object sender, EventArgs e)
        {
            lblNewBook.Text = "Nuova prenotazione Piscina :";
            HideComboBoxLabel();
            actualService = form.PoolsBookings;
            form.ColorCalendar(form.PoolsBookings, monthCalendar1);

        }

        //methods to change the booking list and the calendar when the user click on Fields's button
        private void btnFields_Click(object sender, EventArgs e)
        {
            lblNewBook.Text = "Nuova prenotazione Campi da gioco :";
            HideComboBoxLabel();
            actualService = form.FieldsBookings;
            form.ColorCalendar(form.FieldsBookings, monthCalendar1);
        }

        //method to hide the labels and the combobox for the second book's date
        //is used only when the user select swimming pool or gaming fields
        private void HideComboBoxLabel()
        {
            cmbBoxEndDay.Hide();
            cmbBoxEndMonth.Hide();
            cmbBoxEndYear.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label1.Text = "Il:";
            panel1.Visible = false;
        }

        //method to show the labels and the combobox for the second book's date
        //is used only when the user select a bungalow
        private void ShowComboBoxLabel()
        {
            cmbBoxEndDay.Show();
            cmbBoxEndMonth.Show();
            cmbBoxEndYear.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            label1.Text = "Dal :";
            panel1.Visible = true;
        }

        //method to check if the datas are valid and to add the new book
        private void btnAddBook_Click(object sender, EventArgs e)                  //da aggiungere le prenotazioni dei servizi aggiuntivi 
        {
            if ((actualService == form.BungalowsBookings1) || (actualService == form.BungalowsBookings2)
                 || (actualService == form.BungalowsBookings3))
                ValidateBungalows();
            else
                ValidatePoolOrFields();
        }

        //method to know if the selected date it's free
        //return value = true if the date is valid, false otherwise
        private bool ItsFree(DateTime data)
        {
            bool ret = true;
            
            //the choosed day is compared with all calendar bolded days to check if it's free
            foreach (DateTime dt in monthCalendar1.BoldedDates)
            {
                if (data == dt)       //if it's true the day isn't free
                    ret = false;
            }
            return ret;
        }

        //methot to check if the user have compiled combobox and textbox
        private bool AreCompiled()
        {
            bool ret = true;
            if ((cmbBoxStartDay.SelectedIndex == -1) || (cmbBoxStartMonth.SelectedIndex == -1) ||
                (cmbBoxStartYear.SelectedIndex == -1) || (textBoxName.Text == String.Empty))
                ret = false;

            if ((actualService == form.BungalowsBookings1) || (actualService == form.BungalowsBookings2)
                 || (actualService == form.BungalowsBookings3))
            {
                //only if the user is booking for a bungalow the program 
                //check the combobox for second date
                if ((cmbBoxEndDay.SelectedIndex == -1) || (cmbBoxEndMonth.SelectedIndex == -1)
                     || (cmbBoxEndYear.SelectedIndex == -1))
                    ret = false;
            }
            return ret;
        }

        //method to check that all the field are compiled and 
        //valid when the user is going to book a bungalow
        private void ValidateBungalows() 
        {
            if (AreCompiled()) //check that all the comboboxes and textboxes are compiled   
            {
                DateTime newBookStart = new DateTime();
                DateTime newBookEnd = new DateTime();
                bool isValid = true;
                
                try
                {
                    newBookStart = new DateTime(int.Parse(cmbBoxStartYear.SelectedItem.ToString()),
                        int.Parse(cmbBoxStartMonth.SelectedItem.ToString()), int.Parse(cmbBoxStartDay.SelectedItem.ToString()));
                    newBookEnd = new DateTime(int.Parse(cmbBoxEndYear.SelectedItem.ToString()),
                        int.Parse(cmbBoxEndMonth.SelectedItem.ToString()), int.Parse(cmbBoxEndDay.SelectedItem.ToString()));
                    if(newBookStart > newBookEnd)
                        isValid = false;
                }
                catch (System.ArgumentOutOfRangeException)
                {   
                    //if the program catch an exception the date doesn't exist so isValid is setted to false
                    isValid = false;
                }

                if (isValid)
                {
                    //chek if all the Booking days are free
                    DateTime d = newBookStart;
                    while (d <= newBookEnd)
                    {
                        if (!ItsFree(d))
                            isValid = false;
                        d = d.AddDays(1);
                    }
                }

                if (isValid)
                {
                    //adding the optional service only if the user have choosed the option
                    if (checkBoxPool.Checked == true)
                        form.PoolsBookings.Add(new Booking(newBookStart, newBookEnd, textBoxName.Text));
                    if (checkBoxFields.Checked == true)
                        form.FieldsBookings.Add(new Booking(newBookStart, newBookEnd, textBoxName.Text));

                    //adding the Booking in the selected service
                    actualService.Add(new Booking(newBookStart, newBookEnd, textBoxName.Text));
                    form.ColorCalendar(actualService, monthCalendar1);
                    MessageBox.Show("La prenotazione è andata a buon fine.", "Esito prenotazione", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Impossibile prenotare, ricontrollare che:\r\n" +
                                    "La data di inizio preceda quellla di fine prenotazione\r\n" +
                                    "La data inserita non sia inesistente o occupata (consultare il calendario)",
                                    "Esito prenotazione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Impossibile inoltrare la prenotazione, compilare tutti i campi.",
                    "Esito prenotazione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method to check that all the field are compiled and 
        //valid when the user is going to book for pool or fields
        private void ValidatePoolOrFields()
        {
            if (AreCompiled()) //check that all the comboboxes and textboxes are compiled   
            {
                //DateTimes to represent the booking's start date
                DateTime newBookStart = new DateTime();
                bool isValid = true;
                try
                {
                    newBookStart = new DateTime(int.Parse(cmbBoxStartYear.SelectedItem.ToString()),
                                                int.Parse(cmbBoxStartMonth.SelectedItem.ToString()), 
                                                int.Parse(cmbBoxStartDay.SelectedItem.ToString()));
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    //if the program catch an exception the date doesn't exist so isValid is setted to false
                    isValid = false;
                }
                //chek if all the Booking's days exist and are free
                if (ItsFree(newBookStart) || isValid)
                {
                    //adding the Booking in the selected service
                    actualService.Add(new Booking(newBookStart, newBookStart, textBoxName.Text));
                    form.ColorCalendar(actualService, monthCalendar1);
                    MessageBox.Show("La prenotazione è andata a buon fine.", "Esito prenotazione", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("La data inserita è inesistente o già occupata, consultare il calendario.",
                    "Esito prenotazione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Impossibile inoltrare la prenotazione, compilare tutti i campi.",
                    "Esito prenotazione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method to make the UserContorl ready when the user open it
        //(called in Form 1 when the user click the button to open this UC)
        public void SetUc()
        {
            actualService = form.BungalowsBookings1;
            form.ColorCalendar(actualService, monthCalendar1);
        }

    }
}
