using System;
using Telegram.Bot.Extensions.DatePickers.Abstractions;

namespace Telegram.Bot.Extensions.DatePickers.Tests.TestTypes
{
    /// <summary>
    /// Test class for the <see cref="DayOfMonthPicker{T}"/> tests.
    /// </summary>
    internal class TestDayOfMonthPicker : DayOfMonthPicker<int>
    {
        /// <inheritdoc/>
        public TestDayOfMonthPicker(DateTime date)
            : base(date)
        {
        }

        /// <inheritdoc/>
        public TestDayOfMonthPicker(DateTime date, DayOfWeek weekBeginsWith)
            : base(date, weekBeginsWith)
        {
        }

        /// <inheritdoc/>
        protected override int CreateButton(DateTime date)
        {
            return date.Day;
        }

        /// <inheritdoc/>
        protected override int CreateEmptyButton()
        {
            return -1;
        }
    }
}
