using System;

namespace Timeshift.Test
{
    public abstract class BaseOperatorClass
    {
        protected DateTime _today;
        protected DateTime dt { get; private set; }
        protected TimeZoneInfo zone { get; private set; }

        public BaseOperatorClass()
        {
            /* windows handles time zones differently than the ISO standard. */
            bool isWindows = true;
            if(isWindows)
            {
                zone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            } else 
            {
                zone = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
            }
        }

        protected void SetupMondayInStandardTimeAt6PMEastern()
        {

            _today = new DateTime(2018, 12, 1, 23, 0, 0, DateTimeKind.Utc);
            var daysUntil = ((int)DayOfWeek.Monday - (int)_today.DayOfWeek + 7) % 7;
            _today =  _today.AddDays(daysUntil);
           
        }
        protected void SetupMonday10PMUtc()
        {
            _today = new DateTime(2018, 7, 1, 22, 0, 0, DateTimeKind.Utc);
            var daysUntil = ((int)DayOfWeek.Monday - (int)_today.DayOfWeek + 7) % 7;
            _today = _today.AddDays(daysUntil);     
        }
        protected void SetupMondayAtNoonDaylightSavingsTime()
        {
            _today = new DateTime(2018, 7, 1, 12, 0, 0, DateTimeKind.Utc);
            var daysUntil = ((int)DayOfWeek.Monday - (int)_today.DayOfWeek + 7) % 7;
            dt = _today.AddDays(daysUntil);

        }
        protected void SetupMondayAtNoonStandardTime()
        {
            _today = new DateTime(2018, 12, 1, 12, 0, 0, DateTimeKind.Utc);
            var daysUntil = ((int)DayOfWeek.Monday - (int)_today.DayOfWeek + 7) % 7;
            dt = _today.AddDays(daysUntil);
        }
        protected void SetupSaturday()
        {
            _today = DateTime.Today;
            var daysUntil = ((int)DayOfWeek.Saturday - (int)_today.DayOfWeek + 7) % 7;
            dt = _today.AddDays(daysUntil);
        }
        protected void SetupSunday()
        {
            _today = DateTime.Today;
            var daysUntil = ((int)DayOfWeek.Sunday - (int)_today.DayOfWeek + 7) % 7;
            dt = _today.AddDays(daysUntil);
        }        
    }
}