using System;
using System.Runtime.InteropServices;
namespace Timeshift.Core
{
    public class Mover
    {
        public DateTime MoveToPacificStandardTime(DateTime date)
        {

            bool isWin  = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if(isWin) 
            {
                return TimeZoneInfo.ConvertTime(date, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
            }
            return new DateTime();
        }
        public DateTime MoveToEasternStandardTime(DateTime date)
        {
            bool isWin  = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var outDate = new DateTime();
            if(isWin) 
            {
                outDate = TimeZoneInfo.ConvertTime(date, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            }
            return new DateTime();            
        }
        public DateTime MoveToUniversalTime(DateTime date)
        {
            return date.ToUniversalTime();
        }
    }
}