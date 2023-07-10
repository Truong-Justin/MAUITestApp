
using System.ComponentModel;

namespace MAUITestApp.ViewModel
{
	public class HoroscopeViewModel : INotifyPropertyChanged
	{
		public string data { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;


	}
}

