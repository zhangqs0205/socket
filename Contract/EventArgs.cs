using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public class EventArgs<T>:EventArgs
    {
        public T data
        {
            get;
            private set;
        }
        public EventArgs(T data)
        {
            this.data = data;
        }
    }
}
