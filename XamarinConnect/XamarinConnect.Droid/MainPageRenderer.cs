using Android.App;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using XamarinConnect.Droid;
using XamarinConnect.Views;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
namespace XamarinConnect.Droid
{
    class MainPageRenderer : PageRenderer
    {
        MainPage page;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as MainPage;
            var activity = this.Context as Activity;
        }

    }
}