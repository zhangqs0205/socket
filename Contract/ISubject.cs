﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public interface ISubject
    {
        void  registerInterest(IObserver obs);
    }
}
