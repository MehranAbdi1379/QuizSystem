using Microsoft.VisualBasic;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Value_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Test.Models;
[TestClass]
public class TimePeriodTest
{
    [TestMethod]
    public void SetStartDate_Retrieve()
    {
        var startDate = DateTime.Now.AddDays(1);
        var timePeriod = new TimePeriod(startDate, DateTime.Now.AddDays(15));
        Assert.AreEqual(startDate, timePeriod.StartDate);
    }

    [TestMethod]
    public void SetEndDate_Retrieve()
    {
        var endDate = DateTime.Now.AddDays(15);
        var timePeriod = new TimePeriod(DateTime.Now.AddDays(1), endDate);
        Assert.AreEqual(endDate, timePeriod.EndDate);
    }

    [TestMethod]
    public void SetStartAndEndDate_StartDateIsBeforeEndDate_ThrowException()
    {
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddDays(-1);
        Assert.ThrowsException<CourseEndTimeIsBeforeStartTimeException>(() => new TimePeriod(startDate, endDate));
    }

    [TestMethod]
    public void SetStartAndEndDate_PeriodBetweenStartAndEndDateIsTooShort_ThrowException()
    {
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddDays(2);
        Assert.ThrowsException<CourseShortPeriodException>(() => new TimePeriod(startDate, endDate));
    }

    [TestMethod]
    public void SetStartDate_StartDateIsInTheFuture()
    {
        var startDate = DateTime.Now.AddDays(-3);
        Assert.ThrowsException<CourseStartTimeInThePastException>(() => new TimePeriod(startDate, DateTime.Now.AddDays(10)));
    }
}
