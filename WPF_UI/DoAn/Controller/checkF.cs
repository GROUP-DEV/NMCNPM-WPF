﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoAn.Controller
{
    public class checkF : IDataErrorInfo, INotifyPropertyChanged
    {
        private String _Name;
        public String Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private String _CMND;
        public String CMND
        {
            get { return _CMND; }
            set
            {
                _CMND = value;
                OnPropertyChanged("CMND");
            }
        }

        private String _Email;
        public String Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        #region IDataErrorInfo Members

        public string Error
        {
            get { return String.Empty; }
        }
      //  public 
        public string this[string columnName]
        {
            get
            {
                String errorMessage = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (String.IsNullOrEmpty(Name))
                        {
                            errorMessage = "First Name is required";
                        }
                        if (Name.Length < 3)
                        {
                            errorMessage = " name phai hon 3 ki tu!!";
                        }
                        break;
                    case "Email":
                        Regex regexEmail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                        if (String.IsNullOrEmpty(Email) || !regexEmail.IsMatch(Email))
                        {
                            errorMessage = "Email ko hop le!!";
                        }
                        break;
                    case "Phone":
                        Regex regex = new Regex(@"^[0-9]{10,11}$");

                        if (Phone.Length < 10 || Phone.Length > 11  || !regex.IsMatch(Phone))
                        {
                            errorMessage = "SĐT phải 10 hoắc 11 số ";
                        }
                        break;
                    case "CMND":
                        Regex regexCMND = new Regex(@"^[0-9]{9,9}$");

                        if (CMND.Length < 9 || CMND.Length > 9 || !regexCMND.IsMatch(CMND))
                        {
                            errorMessage = "CMND phải đủ 9 số";
                        }
                        break;
                }
                return errorMessage;
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
