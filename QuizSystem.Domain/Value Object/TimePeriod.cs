using QuizSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Value_Object
{
    public class TimePeriod
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimePeriod(DateTime startTime , DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public void ValidateTimePeriodLenght()
        {
            if (EndTime.Subtract(StartTime).TotalDays < 7)
                throw new CourseShortPeriodException();
        }

        public void ValidateStartTimeIsInTheFuture()
        {
            if (StartTime.Subtract(DateTime.Now).TotalDays < 0)
                throw new CourseStartTimeInThePastException();
        }

        public void ValidateStartAndEndTimeSort()
        {
            if (EndTime.Subtract(StartTime).TotalDays < 0)
                throw new CourseEndTimeIsBeforeStartTimeException();
        }

        public void ValidateTimePeriod()
        {
            ValidateStartAndEndTimeSort();
            ValidateStartTimeIsInTheFuture();
            ValidateTimePeriodLenght();
        }
    }
}
