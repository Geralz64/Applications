using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    //public delegate int WorkPerformedHander(object sender, WorkPerformedEventArgs e);
    public class Worker        
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;


        public void DoSomething(DateTime date)
        {
            //With this we can still output information even though the method returns void

            OnWorkPerformed(date);

            OnWorkCompleted();

        }

        protected virtual void OnWorkPerformed(DateTime date)
        {
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;

            if (del != null) 
            {
                del(this, new WorkPerformedEventArgs(date));
            };
        }

        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;

            if (del != null)
            {
                del(this,EventArgs.Empty);
            };
        }

    }
}
