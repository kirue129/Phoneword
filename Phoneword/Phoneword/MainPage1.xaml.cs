﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage1 : ContentPage
    {

        string translatedNumber;

        public MainPage1()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Dial a Number", "Would you like to call " + translatedNumber + "?", "Yes", "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(translatedNumber);
                }  
            }
        }
    }
}
