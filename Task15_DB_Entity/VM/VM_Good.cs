﻿using Task15_DB_Entity.Tools;
using Task15_DB_Entity.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task15_DB_Entity.Model.SQLite;

namespace Task15_DB_Entity.VM
{
    internal class VM_Good
    {
        public Good Good { get; set; }
        public bool Result { get; set; }
        public VM_Good (Good good)
        {
            this.Good = good;
            Result = false;
            CommandCancel = new RelayCommand(Cancel);
            CommandOk = new RelayCommand(Ok);
        }
        public void Ok(object obj)
        {
            Result = true;
            foreach (Window win in Application.Current.Windows)
            {
                if (win is GoodView)
                {
                    win.Close();
                    break;

                }
            }
        }
        public void Cancel(object obj)
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (win is GoodView)
                { 
                    win.Close();
                    break;

                }
            }
        }
        #region command
        RelayCommand _commandOk;
        public RelayCommand CommandOk
        {
            get
            {
                return _commandOk ?? new RelayCommand(obj => MessageBox.Show("Button OK is not working"));
            }
            set { _commandOk = value; }
        }
        RelayCommand _commandCancel;
        public RelayCommand CommandCancel
        {
            get
            {
                return _commandCancel ?? new RelayCommand(obj => MessageBox.Show("Button Cancel is not working"));
            }
            set { _commandCancel = value; }
        }
#endregion
    }
}
