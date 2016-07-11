using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace demo.Model
{
    public class Elipse : INotifyPropertyChanged
    {
        private int _height;//diameter
        private int _width;//diameter
        private double _top;//canvas' position
        private double _left;//canvas' position
        private int status;//1: active 0:inactive(when mouse clicked)
        public event PropertyChangedEventHandler PropertyChanged;        

        public Elipse(int height, int width, int top, int left,int status){
            Height = height;
            Left = left;
            Width = width;
            Top = top;
            Status = status;
        }

        public void Move(double x, double y) {
            //MessageBox.Show(Top.ToString());
            Top = (Top + y <= 0) ? 0 : Top + y;
            Left = (Left + x <= 0) ? 0 : Left + x;
            //Width += 10;
            //MessageBox.Show(Top.ToString());
        }

        public double Top{
            get
            {
                return _top;
            }

            set
            {
                _top = value;
                NotifyPropertyChanged("Top");

            }
        }

        public double Left
        {
            get
            {
                return _left;
            }

            set
            {
                _left = value;
                NotifyPropertyChanged("Left");
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                //MessageBox.Show("Antes Notify");
                NotifyPropertyChanged("Height");
                //MessageBox.Show("Notify");
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
                //MessageBox.Show("Antes Notify");
                NotifyPropertyChanged("Width");
                //MessageBox.Show("Notify");
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public void NotifyPropertyChanged(string propName) {
            //MessageBox.Show("antes de if");
            
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null){
                //MessageBox.Show("Notify");
                //if (propName == "Width") MessageBox.Show(propName);
                handler(this, new PropertyChangedEventArgs(propName));
            }
            /*else {
                //MessageBox.Show(propName);
                MessageBox.Show("handler nulo");
            }*/
            
        }
    }
}
