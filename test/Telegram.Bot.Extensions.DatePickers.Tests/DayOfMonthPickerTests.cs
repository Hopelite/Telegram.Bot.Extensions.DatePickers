using System;
using Xunit;
using Telegram.Bot.Extensions.DatePickers.Tests.TestTypes;

namespace Telegram.Bot.Extensions.DatePickers.Tests
{
    public class DayOfMonthPickerTests
    {
        [Theory]
        [MemberData(nameof(DayOfMonthPickerTestData.ExpectedFirstDayMonday), MemberType = typeof(DayOfMonthPickerTestData))]
        [MemberData(nameof(DayOfMonthPickerTestData.ExpectedFirstDaySunday), MemberType = typeof(DayOfMonthPickerTestData))]
        public void DayOfMonthPickerTests_CreateDayOfMonthPicker_ReturnsExpectedDatePicker(DateTime date, DayOfWeek weeksStarts, int[][] expected)
        {
            // Arrange
            var dayOfMonthPicker = new TestDayOfMonthPicker(date, weeksStarts);

            // Act
            var actual = dayOfMonthPicker.CreateDayOfMonthPicker();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
