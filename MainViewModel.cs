using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InputFieldLabelChange
{
    public class MainViewModel : INotifyPropertyChanged
    {
        int _index;
        string[] _labels = { "Short", "Middle label", "Very long label text" };

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
         => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string _label = "Default label";
        public string Label
        {
            get { return _label; }
            set { _label = value; OnPropertyChanged(); }
        }

        private string _value = "Default value";
        public string Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(); }
        }

        private ICommand? _buttonClick;
        public ICommand ButtonClick => _buttonClick ??= new Command(OnButtonClick);

        void OnButtonClick(object obj)
        {
            _index = (_index + 1) % _labels.Length;
            Label = _labels[_index];
        }

    }
}
