using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Lab8
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        TextView tvPrimero, tvSegundo, tvTercero;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            tvPrimero = FindViewById<TextView>(Resource.Id.tvPrimero);
            tvSegundo = FindViewById<TextView>(Resource.Id.tvSegundo);
            tvTercero = FindViewById<TextView>(Resource.Id.tvTercero);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //var viewGroup = (Android.Views.ViewGroup)
            //Window.DecorView.FindViewById(Android.Resource.Id.Content);

            //var MainLayout = viewGroup.GetChildAt(0) as LinearLayout;

            //var HeaderImage = new ImageView(this);
            //HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);
            //MainLayout.AddView(HeaderImage);

            //var UserNameTextView = new TextView(this);
            //UserNameTextView.Text = GetString(Resource.String.username);
            //MainLayout.AddView(UserNameTextView);
            Validar();
        }

        async void Validar()
        {
            var serviceClient = new SALLab08.ServiceClient();
            var phoneInfo = Android.Provider.Settings.Secure.GetString(
                                ContentResolver, Android.Provider.Settings.Secure.AndroidId); ;
            var serviceResult = await serviceClient.ValidateAsync("mail", "pass", phoneInfo);
            tvPrimero.Text = serviceResult.Status.ToString();
            tvSegundo.Text = serviceResult.Fullname;
            tvTercero.Text = serviceResult.Token;
        }
    }
}

