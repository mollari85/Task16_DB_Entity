﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Task15_DB_Entity.Model;
using Task15_DB_Entity.VM;

namespace Task15_DB_Entity.View
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
          //  VM_Login VMLogin = new VM_Login(IModel);
          //  this.DataContext = VMLogin;
           
        }
    }
}
