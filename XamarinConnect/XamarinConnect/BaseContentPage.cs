using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using XamarinConnect.ViewModel;

namespace XamarinConnect
{
    public class BaseContentPage<T> : ContentPage
        where T : ViewModelBase
    {
        protected T ViewModel;
        protected object _parameter;

        public BaseContentPage()
        {
            ViewModel = SimpleIoc.Default.GetInstance<T>();
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null)
                return;

            ViewModel.Start(_parameter);

            ViewModel.PropertyChanged += ViewModelPropertyChanged;
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnViewModelPropertyChanged(e.PropertyName);
        }

        protected virtual void OnViewModelPropertyChanged(string propertyName)
        {
        }

        protected override void OnDisappearing()
        {
            ViewModel.PropertyChanged -= ViewModelPropertyChanged;
        }
    }
}
