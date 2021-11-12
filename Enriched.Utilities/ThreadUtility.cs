using System;
using System.Threading;

namespace Enriched.Utilities
{
    public static class ThreadUtility
    {
        public static Thread Repeat(TimeSpan interval, Action action, bool isBackground = false, string name = null)
        {
            return new Thread(() =>
            {
                // ReSharper disable once UnusedVariable
                var timer = new Timer(obj => action(), null, TimeSpan.Zero, interval);
            })
            {
                IsBackground = isBackground,
                Name = name
            };
        }

        public static Thread Repeat(TimeSpan interval, Action action, Func<bool> stopWhen, bool isBackground = false, string name = null)
        {
            return new Thread(() =>
            {
                var timer = new Timer(obj => { action(); }, null, TimeSpan.Zero, interval);
                if (stopWhen())
                {
                    timer.Dispose();
                }
            })
            {
                IsBackground = isBackground,
                Name = name
            };
        }
    }
}