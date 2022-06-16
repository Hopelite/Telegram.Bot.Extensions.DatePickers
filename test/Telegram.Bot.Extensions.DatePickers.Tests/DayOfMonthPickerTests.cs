using System;
using Telegram.Bot.Extensions.DatePickers.Tests.TestTypes;
using Xunit;

namespace Telegram.Bot.Extensions.DatePickers.Tests
{
    public class DayOfMonthPickerTests
    {
        [Theory]
        [MemberData(nameof(DayOfMonthPickerTestData.ExpectedFirstDayMonday), MemberType = typeof(DayOfMonthPickerTestData))]
        [MemberData(nameof(DayOfMonthPickerTestData.ExpectedFirstDaySunday), MemberType = typeof(DayOfMonthPickerTestData))]
        [MemberData(nameof(DayOfMonthPickerTestData.ExpectedFirstDaySaturday), MemberType = typeof(DayOfMonthPickerTestData))]
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
