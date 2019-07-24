using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net;
using System;
using Android.Graphics;
using System.Threading.Tasks;

namespace ImageLoader
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        EditText hText;
        EditText bText;
        Button loadButton;
        ImageView imgView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            hText = FindViewById<EditText>(Resource.Id.hoeheEditText);
            bText = FindViewById<EditText>(Resource.Id.bTextEdit);
            loadButton = FindViewById<Button>(Resource.Id.button1);
            imgView = FindViewById<ImageView>(Resource.Id.imageView1);

            loadButton.Click += LoadButton_Click;
        }

        private async void LoadButton_Click(object sender, System.EventArgs e)
        {
            loadButton.Enabled = false;
            var dlg = ProgressDialog.Show(this,"Lade","Bild wird geladen");
            byte[] img = null;
            using (var wc = new WebClient())
            {
                //await Task.Delay(2000);
                img = await wc.DownloadDataTaskAsync(new Uri($"http://placekitten.com/{bText.Text}/{hText.Text}"));
                imgView.SetImageBitmap(BitmapFactory.DecodeByteArray(img, 0, img.Length));
            }
            loadButton.Enabled = !false;
            dlg.Dismiss();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}