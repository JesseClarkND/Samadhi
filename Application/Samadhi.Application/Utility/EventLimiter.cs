using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Samadhi.Application.Utility
{
    public class EventLimiter
    {
        //https://stackoverflow.com/questions/7728569/how-to-limit-method-usage-per-amount-of-time
        Queue<DateTime> requestTimes;
        int maxRequests;
        TimeSpan timeSpan;

        public EventLimiter(int maxRequests, TimeSpan timeSpan)
        {
            this.maxRequests = maxRequests;
            this.timeSpan = timeSpan;
            requestTimes = new Queue<DateTime>(maxRequests);
        }

        private void SynchronizeQueue()
        {
            while ((requestTimes.Count > 0) && (requestTimes.Peek().Add(timeSpan) < DateTime.UtcNow))
                requestTimes.Dequeue();
        }

        public bool CanRequestNow()
        {
            SynchronizeQueue();
            return requestTimes.Count < maxRequests;
        }

        public void EnqueueRequest()
        {
            while (!CanRequestNow())
                Thread.Sleep(requestTimes.Peek().Add(timeSpan).Subtract(DateTime.UtcNow));

            requestTimes.Enqueue(DateTime.UtcNow);
        }
    }
}
