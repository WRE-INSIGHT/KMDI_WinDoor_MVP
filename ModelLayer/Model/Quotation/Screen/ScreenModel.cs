using ModelLayer.Variables;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ModelLayer.Model.Quotation.Screen
{
    public class ScreenModel : IScreenModel, INotifyPropertyChanged
    {
         
        public event PropertyChangedEventHandler PropertyChanged; 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ConstantVariables constants = new ConstantVariables();

    }
}
