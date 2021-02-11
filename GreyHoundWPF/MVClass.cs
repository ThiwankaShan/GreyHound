using System.Threading;
using System.ComponentModel;

namespace GreyHoundWPF
{
    class MVClass : INotifyPropertyChanged
        
    {
        public string name { get; set; }

        public int locationX { get; set; }

        public int locationY { get; set; }

        public MVClass() 
        {
            name = "Anne Freedom\n(Enemy Ship)";
            locationX = 0;
            locationY = 0;
            Thread t = new Thread(update);
            t.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void update()
        {
            while (locationX<10)
            {
                locationX++;
                locationY++;
                Thread.Sleep(3000);
                this.onPropertyChanged("locationX");
                this.onPropertyChanged("locationY");
            }
            
        }

        protected virtual void onPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        } 
    }
}
