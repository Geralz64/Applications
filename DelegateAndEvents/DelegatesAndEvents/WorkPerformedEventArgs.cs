
using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; set; }

    }
}
