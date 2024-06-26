﻿using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void LogInButtonClick(object sender, EventArgs e)
        {
            LogInForm logInForm = new LogInForm();
            this.Hide();
            logInForm.Show();
            logInForm.FormClosed += (s, args) => this.Close();
        }

        private void SignInButtonClick(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.Show();
            registerForm.FormClosed += (s, args) => this.Close();
        }
    }
}
