using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTORE_VILLAGGIO
{
    class ReaderWriter
    {
        //reference to the form containing this User Control
        //passed with Constructor of UCDeleteBookings in file Form1.Designer.cs
        private Form1 form;
        //form's properties
        public Form1 Form
        {
            get => form;
            set => form = value;
        }

        //xml serializer to write and read the oject's list
        System.Xml.Serialization.XmlSerializer readerWriter = new System.Xml.Serialization.XmlSerializer(typeof(List<Booking>));

        //string with the path of the folder with the saved data 
        private readonly string path;

        //instance of this class used to implement the singleton desing pattern
        private static ReaderWriter instance;

        //implementation of the singleton design pattern 
        public static ReaderWriter GetInstance()
        {
            //create a new istance only if there aren't other instance
            if(instance == null)
                instance = new ReaderWriter();
            return instance;
        }

        //constructor of the class
        private ReaderWriter()
        {
            //part of the path
            path = Path.Combine(Environment.CurrentDirectory, @"Data\");
        }

        //method to save data before the closign of the program
        public void SaveData()
        {
            //saving the Bungalow1's bookings
            var file = System.IO.File.Create(Path.Combine(path, "Bungalow1Data.xml"));
            readerWriter.Serialize(file, form.BungalowsBookings1);
            file.Close();

            //saving the Bungalow2's bookings
            file = System.IO.File.Create(Path.Combine(path, "Bungalow2Data.xml"));
            readerWriter.Serialize(file, form.BungalowsBookings2);
            file.Close();

            //saving the Bungalow3's bookings
            file = System.IO.File.Create(Path.Combine(path, "Bungalow3Data.xml"));
            readerWriter.Serialize(file, form.BungalowsBookings3);
            file.Close();

            //saving the Pool's bookings
            file = System.IO.File.Create(Path.Combine(path, "PoolData.xml"));
            readerWriter.Serialize(file, form.PoolsBookings);
            file.Close();

            //saving the booking of fields
            file = System.IO.File.Create(Path.Combine(path, "FieldsData.xml"));
            readerWriter.Serialize(file, form.FieldsBookings);
            file.Close();
        }

        //method to load all the booking's data when the program start the execution
        public List<List<Booking>> GetData()
        {
            //list of list to put all the bookings
            List<List<Booking>> listOfBookingsList = new List<List<Booking>>();
            
            //reading the Bungalow1's bookings
            listOfBookingsList.Add(GetListFromFile("Bungalow1Data.xml"));
            //reading the Bungalow2's bookings
            listOfBookingsList.Add(GetListFromFile("Bungalow2Data.xml"));
            //reading the Bungalow3's bookings
            listOfBookingsList.Add(GetListFromFile("Bungalow3Data.xml"));
            //reading the Pool's bookings
            listOfBookingsList.Add(GetListFromFile("PoolData.xml"));
            //reading the bookings of fields
            listOfBookingsList.Add(GetListFromFile("FieldsData.xml"));

            return listOfBookingsList;
        }

        //method to get a list from a xml file
        private List<Booking> GetListFromFile(string filename)  //name of the file with list's informations 
        {
            //list to put and return the readden list 
            List<Booking> list;
            try
            {
                //creating a new StreamReader with the file with name specified in the parameter to read the bookings
                System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(path, filename));
                //deserializing the object from file and put it in a list  
                list = (List<Booking>)readerWriter.Deserialize(file);
                file.Close();
            }
            catch (Exception)
            {
                list = new List<Booking>();
            }

            return list;
        }
    }
}
