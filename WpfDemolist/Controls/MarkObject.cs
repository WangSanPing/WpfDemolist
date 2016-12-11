using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemolist.Controls
{
    public class MarkObject : INotifyPropertyChanged
    {
        //
        /// <summary>
        /// 
        /// </summary>
        private bool _IsSelected;

        //
        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected
        {
            get { return this._IsSelected; }
            set
            {
                if (this._IsSelected == value)
                {
                    return;
                }

                this._IsSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        //
        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //
        /// <summary>
        /// 
        /// </summary>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

