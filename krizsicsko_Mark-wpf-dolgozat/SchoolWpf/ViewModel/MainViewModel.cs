using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SchoolWpf.Command;
using SchoolWpf.View;

namespace SchoolWpf.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
		private object currentView;

		public object CurrentView
		{
			get { return currentView; }
			set { 
				currentView = value;
				OnPropertyChanged();
			}
		}

		Task1View task1View;
		Task2View task2View;
		Task3View task3View;

        public event PropertyChangedEventHandler? PropertyChanged;		

        public RelayCommand openTask1 { get; }
		public RelayCommand openTask2 { get; }
		public RelayCommand openTask3 { get; }

        public MainViewModel()
        {
			task1View = new Task1View();
			task2View = new Task2View();
			task3View = new Task3View();

			openTask1 = new RelayCommand(X => CurrentView = task1View);
			openTask2 = new RelayCommand(X => CurrentView = task2View);
			openTask3 = new RelayCommand(X => CurrentView = task3View);



        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
