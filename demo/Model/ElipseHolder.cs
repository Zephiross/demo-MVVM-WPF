using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Model
{
    class ElipseHolder : INotifyPropertyChanged
    {
        private List<Elipse> _lstEl = new List<Elipse>();
        private System.Windows.Threading.DispatcherTimer timer;
        public event PropertyChangedEventHandler PropertyChanged;

        public ElipseHolder() {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_tick;
        }

        public List<Elipse> LstEl{
            get{return _lstEl;}
            set{_lstEl = value;}
        }

        public void timer_tick(object sender, EventArgs e) {
            //method that detects collisions

        }

        public void deleteElipse() {

            Notify("");//poner el nombre del binding para la lista
        }

        public event EventHandler EllipseCollectionChanged;

        public void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
