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

        public void ValidateTimePeriodLenght()
        {
            if (StartTime)
        }

        public void ValidateStartTimeIsInTheFuture()
        {

        }

        public void ValidateStartAndEndTimeSort()
        {

        }

        public void ValidateTimePeriod()
        {
            ValidateStartAndEndTimeSort();
            ValidateStartTimeIsInTheFuture();
            ValidateTimePeriodLenght();
        }
    }
}
