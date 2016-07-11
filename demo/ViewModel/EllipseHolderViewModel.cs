using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using demo.View;

namespace demo.ViewModel
{
    public class EllipseHolderViewModel 
    {
        
        //private ElipseHolder eh = new ElipseHolder();
        //private ICommand MouseDownCommand;
        private System.Windows.Threading.DispatcherTimer game_timer,list_timer;
        static Random rnd = new Random();
        int numLoops = 0;
        private int _cantEllipses;
        private int _cantElim;
        private ObservableCollection<ElipseViewModel> _lstVM = new ObservableCollection<ElipseViewModel>();

        public ObservableCollection<ElipseViewModel> LstVM
        {
            get {return _lstVM;}            
        }

        public EllipseHolderViewModel(int cantEllipses) {
            _cantElim = 0;
            _cantEllipses = cantEllipses;
            for (int i = 0; i < cantEllipses; i++) {
                ElipseViewModel evm = new ElipseViewModel();
                //Elipse el = evm.El;
                //eh.LstEl.Add(el);
                LstVM.Add(evm);
            }
            //eh.EllipseCollectionChanged += OnEllipseCollectionChanged;

            list_timer = new System.Windows.Threading.DispatcherTimer();
            list_timer.Interval = TimeSpan.FromMilliseconds(10);
            list_timer.Tick += timer2_checkList;

            game_timer = new System.Windows.Threading.DispatcherTimer();
            game_timer.Interval = TimeSpan.FromSeconds(1);
            game_timer.Tick += timer1_tick;

            game_timer.Start();
            list_timer.Start();
        }

        public void Check_Collision() {
            for (int i = 0; i < _lstVM.Count; i++)
            {
                Elipse el1 = _lstVM[i].El;
                var x1 = el1.Left;
                var y1 = el1.Top;
                Rect r1 = new Rect(x1 + 3, y1 + 3, el1.Width - 3, el1.Height - 3);
                for (int j = i + 1; j < _lstVM.Count; j++)
                {
                    Elipse el2 = _lstVM[j].El;
                    var x2 = el2.Left;
                    var y2 = el2.Top;
                    Rect r2 = new Rect(x2 + 3, y2 + 3, el2.Width - 3, el2.Height - 3);
                    if (r1.IntersectsWith(r2))
                    {
                        MessageBox.Show("Game Over:\nCant Elim: "+ _cantElim.ToString());
                        game_timer.Stop();
                        list_timer.Stop();
                        var mainWindow = (Application.Current.MainWindow as Window1);
                        mainWindow.Close();
                        return;
                        //int a = 1;
                    }
                }
            }
        }

        public void timer1_tick(object sender, EventArgs e) {
            //if (numLoops-- == 0) timer.Stop();
            //MessageBox.Show("iteracion");
            if(numLoops!=0)
                Check_Collision();
            numLoops++;

            //MessageBox.Show("termino revision colision");
            //MessageBox.Show(_lstVM[0].El.Left.ToString());
            for (int i = 0; i < _lstVM.Count; i++) {
                _lstVM[i].Move(rnd.Next(-15, 15), rnd.Next(-15, 15));
            }
            //MessageBox.Show(_lstVM[0].El.Left.ToString());
            //NotifyPropertyChanged("LstVM");
        }
        public void timer2_checkList(object sender, EventArgs e) {
            for (int i = 0; i < LstVM.Count; i++) {
                if (LstVM[i].El.Status == 0)
                {
                    LstVM.Remove(LstVM[i]);
                    _cantElim += 1;
                    break;
                }
            }
            if (LstVM.Count == 0) {
                Create_newList();
                numLoops = 0;
            }
        }

        public void Create_newList() {
            for (int i = 0; i < _cantEllipses; i++)
            {
                ElipseViewModel evm = new ElipseViewModel();
                LstVM.Add(evm);
            }
        }

        //public void OnEllipseCollectionChanged(object sender, EventArgs args){
        //    //change observable collection


        //}


    }
}
