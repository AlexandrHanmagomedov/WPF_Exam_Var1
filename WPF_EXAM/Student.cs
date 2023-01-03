using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Controls;

namespace WPF_EXAM
{
    public class Student : NotifyClass
    {

        private string _image;
        private string _name;
        private string _surName;
        private string _patronymic;
        private int _groupNumber;
        private int _phoneNumber;
        private DateTime _entryDate;
        private DateTime _releaseDate;

        public string Name
        {
            set { _name = value; OnPropertyChanged("Name"); }
            get { return _name; }
        }

        public string SurName
        {
            set { _surName = value; OnPropertyChanged("SurName"); }
            get { return _surName; }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; OnPropertyChanged("Patronomic"); }
        }

        public string ImagePublic { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }
        public int GroupNumber { get { return _groupNumber; } set { _groupNumber = value; OnPropertyChanged("GroupNumber"); } }

        public int PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; OnPropertyChanged("PhoneNumber"); } }

        public DateTime EntryDate { get { return _entryDate; } set { _entryDate = value; OnPropertyChanged("EntryDate"); } }

        public DateTime ReleaseDate { get { return _releaseDate; } set { _releaseDate = value; OnPropertyChanged("ReleaseDate"); } }

       
    }
}
   

