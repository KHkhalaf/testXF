using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using testXF.Data;

namespace testXF.Droid
{
    public class SnackBar : ISnackBar
    {
        public void ShowSnackBar(string Message)
        {
            var toast = Toast.MakeText(Android.App.Application.Context, Message, ToastLength.Long);
            toast.SetMargin(0, -1);
            toast.Show();
        }
    }
}