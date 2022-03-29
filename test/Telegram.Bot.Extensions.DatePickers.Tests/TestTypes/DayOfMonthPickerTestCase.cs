using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Bot.Extensions.DatePickers.Tests.TestTypes
{
    public class DayOfMonthPickerTestCase
    {
        internal DateTime Date { get; set; }

        internal DayOfWeek WeekStarts { get; set; }

        internal int[][] Expected { get; set; }
    }
}
