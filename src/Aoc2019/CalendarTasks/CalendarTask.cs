using System.Collections.Generic;

namespace Aoc2019.CalendarTasks
{
    public abstract class CalendarTask
    {
        public object Data { get; set; }
        public Dictionary<string, object> Result { get; }

        protected CalendarTask()
        {
            Result = new Dictionary<string, object>();
        }

        public abstract void Run();
    }
}