using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.Model;
using System.Windows.Shapes;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using demo.View;

namespace demo.ViewModel
{
    
    public class ElipseViewModel : INotifyPropertyChanged
    {
        static Random rnd = new Random();
        private Elipse _el;
        
        //private Ellipse _elipse = new Ellipse { Height = 20, Width=20, Fill=Brushes.PaleVioletRed};
        private ICommand OnClick;
        public event PropertyChangedEventHandler PropertyChanged;

        public ElipseViewModel() {
            var size = rnd.Next(10, 25);
            _el = new Elipse(size, size, rnd.Next(1, 300), rnd.Next(1, 300),1);
            OnClick = new MouseDownCommand(DeleteElipse,CanExecute);
            var mainWindow = (Application.Current.MainWindow as Window1);
            

        }
        public void DeleteElipse()
        {
            _el.Status = 0;
        }


        public bool CanExecute() { return true; }


        public int Height {
            get { return El.Height; }                       
        }
        public int Width {
            get { return El.Width; }
        }
        public double Left {
            get { return El.Left; }
            set {
                El.Left = value;
                //MessageBox.Show("Antes Notify");
                NotifyPropertyChanged("Left");
                //MessageBox.Show("Notify");
            }
        }

        public void Move(double x, double y)
        {
            //MessageBox.Show(Top.ToString());
            if (Top + y <= 0)
                Top = 0;
            else Top = Top + y;
            if (Top + y >= 300)
                Top = 300;
            else Top = Top + y;
            if (Left + x <= 0)
                Left = 0;
            else Left =Left + x;
            if (Left + x >= 300)
                Left = 300;
            else Left = Left + x;
            //Top = (Top + y <= 0) ? 0 : Top + y;
            //Left = (Left + x <= 0) ? 0 : Left + x;
            //Width += 10;
            //MessageBox.Show(Top.ToString());
        }

        public double Top{
            get { return El.Top; }
            set {
                El.Top = value;
                //MessageBox.Show("Antes Notify");
                NotifyPropertyChanged("Top");
                
                //MessageBox.Show("Notify");
            }
        }

        public Elipse El{
            get{return _el;}
            
        }

        public ICommand OnClick1
        {
            get
            {
                return OnClick;
            }            
        }        

        //public Ellipse Elipse{
        //    get{return _elipse;}

        //}
        public void NotifyPropertyChanged(string propName){
        //    MessageBox.Show("antes de if");
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null){
                //MessageBox.Show("Notify");
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }

        
        //public void LeftClick(object sender, EventArgs e) {
        //    MessageBox.Show("Ellipse click");
        //}
        


    }
}
