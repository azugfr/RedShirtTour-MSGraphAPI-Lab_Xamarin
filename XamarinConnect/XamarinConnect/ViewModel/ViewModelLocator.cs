using GalaSoft.MvvmLight.Ioc;

namespace XamarinConnect.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator() => SimpleIoc.Default.Register<MainViewModel>();

        public MainViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}