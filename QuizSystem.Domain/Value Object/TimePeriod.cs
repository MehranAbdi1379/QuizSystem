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
        public TimePeriod()
        {

        }
        
        public TimePeriod(DateTime startDate, DateTime endDate , bool update=false)
        {
            if(update==false)
            {
                ValidateTimePeriod(startDate, endDate);
            }
            else
            {
                ValidateTimePeriodLenght(startDate, endDate);
                ValidateStartDateIsBeforeEndDate(startDate, endDate);
            }
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public void ValidateTimePeriodLenght(DateTime startDate, DateTime endDate)
        {
            if (endDate.Subtract(startDate).TotalDays < 7)
                throw new CourseShortPeriodException();
        }

        public void ValidateStartTimeIsInTheFuture(DateTime startDate)
        {
            if (startDate.Subtract(DateTime.Now).TotalDays < 0)
                throw new CourseStartTimeInThePastException();
        }

        public void ValidateStartDateIsBeforeEndDate(DateTime startDate, DateTime endDate)
        {
            if (endDate.Subtract(startDate).TotalDays < 0)
                throw new CourseEndTimeIsBeforeStartTimeException();
        }

        public void ValidateTimePeriod(DateTime startDate , DateTime endDate)
        {
            ValidateStartDateIsBeforeEndDate(startDate, endDate);
            ValidateTimePeriodLenght(startDate, endDate);
            ValidateStartTimeIsInTheFuture(startDate);
        }
    }
}