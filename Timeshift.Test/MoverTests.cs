using Xunit;
using System;
using Timeshift.Core;
namespace Timeshift.Test
{
    public class MoverTests
    {
        [Fact]
        public void DoesMoveFromEasternToPacificStandardTime()
        {
            var mover = new Mover();
            var dt = new DateTime(2019, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var eastern = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var testDate = mover.MoveToPacificStandardTime(eastern);
            Assert.Equal(4, testDate.Hour);

        }
        [Fact]
        public void DoesMoveFromEasternToUtc()
        {
            var mover = new Mover();
            var dt = new DateTime(2019, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var eastern = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var testDate = mover.MoveToUniversalTime(eastern);
            Assert.Equal(12, testDate.Hour);

        }
        [Fact]
        public void DoesMoveFromEasternDaylightToUtc()
        {
            var mover = new Mover();
            var dt = new DateTime(2019, 6, 1, 12,0,0, DateTimeKind.Utc);
            var eastern = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var testDate = mover.MoveToUniversalTime(eastern);
            Assert.Equal(12, testDate.Hour);
            
        }

        [Fact]
        public void DoesMoveFromPacificToEasternDaylightTime()
        {
            /* Get the Time zone info */
            var pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            var dt = new DateTime(2019,6,1,16, 0,0, DateTimeKind.Utc);
            /* shift the times */
            var pacificTime = TimeZoneInfo.ConvertTime(dt, pst);
            var eastTime = TimeZoneInfo.ConvertTime(dt, est);
            /* convert pac time to the standard/benchmark time */
            var pstToUtc = TimeZoneInfo.ConvertTimeToUtc(pacificTime, pst);
            
            /* now convert to target */
            var nowEast = TimeZoneInfo.ConvertTime(pstToUtc, est);
            Assert.Equal(nowEast.Hour, eastTime.Hour);

        }
    }
}