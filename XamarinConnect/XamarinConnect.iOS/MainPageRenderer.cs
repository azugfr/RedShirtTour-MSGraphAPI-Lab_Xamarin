using XamarinConnect.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinConnect.Views;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
namespace XamarinConnect.iOS
{
    class MainPageRenderer : PageRenderer
    {
        MainPage page;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as MainPage;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}
