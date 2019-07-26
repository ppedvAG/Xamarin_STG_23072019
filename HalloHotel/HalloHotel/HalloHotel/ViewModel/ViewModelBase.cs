using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HalloHotel.ViewModel
{
   public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected void MeChanged([CallerMemberName]string propName = "")
        {
            if (!string.IsNullOrWhiteSpace(propName))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
