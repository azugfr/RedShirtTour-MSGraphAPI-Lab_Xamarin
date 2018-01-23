using System;
using System.Threading.Tasks;

namespace XamarinConnect.ViewModel
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        protected object ParameterBase { get; private set; }

        public virtual void Start(object parameterBase)
        {
            ParameterBase = parameterBase;
        }
    }
}
