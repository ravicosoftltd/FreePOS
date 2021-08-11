using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreePOS.bll
{
    public class TimeUtils
    {
        public static DateTime getStartDate(DateTime? d)
        {
            DateTime tempStartDate = Convert.ToDateTime(d);
            DateTime startDate = Convert.ToDateTime(tempStartDate.ToShortDateString() + " 12:00:00 AM");
            return startDate;
        }
        public static DateTime getEndDate(DateTime? d)
        {
            DateTime tempEndDate = Convert.ToDateTime(d);
            DateTime endDate = Convert.ToDateTime(tempEndDate.ToShortDateString() + " 11:59:59 PM");
            return endDate;
        }
        public static void setTimeout(Func<int> function, int timeout)
        {
            Task.Delay(timeout).ContinueWith((Task task) =>
            {
                function();
            });
        }
        public static void setIntervalInUIThread(Func<int> function, int timeout)
        {
            Task.Delay(timeout).ContinueWith((Task task) =>
            {
                //ivoking in UI Thread
                System.Windows.Application.Current.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                {
                    function();
                    setIntervalInUIThread(() =>
                    {
                        function();
                        return 0;
                    }, timeout);
                });
            });
            
        }
    }
}
