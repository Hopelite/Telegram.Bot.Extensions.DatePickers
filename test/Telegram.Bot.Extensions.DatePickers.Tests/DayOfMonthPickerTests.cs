using System;
using Xunit;
using Telegram.Bot.Extensions.DatePickers.Tests.TestTypes;

namespace Telegram.Bot.Extensions.DatePickers.Tests
{
    public class DayOfMonthPickerTests
    {
        [Fact]
        public void DayOfMonthPickerTests_CreateDayOfMonthPicker_31Days_FirstDayMonday_NoEmptyDaysAtTheBeginning_FourAtTheEnd()
        {
            // Arrange
            var date = new DateTime(2022, 8, 1);
            var dayOfMonthPicker = new TestDayOfMonthPicker(date);
            var expected = new int[][]
            {
                new [] { 1,  2,  3,  4,  5,  6,  7  },
                new [] { 8,  9,  10, 11, 12, 13, 14 },
                new [] { 15, 16, 17, 18, 19, 20, 21 },
                new [] { 22, 23, 24, 25, 26, 27, 28 },
                new [] { 29, 30, 31, -1, -1, -1, -1 },
            };

            // Act
            var actual = dayOfMonthPicker.CreateDayOfMonthPicker();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DayOfMonthPickerTests_CreateDayOfMonthPicker_31Days_FirstDaySunday_OneEmptyDayAtTheBeginning_ThreeAtTheEnd()
        {
            // Arrange
            var date = new DateTime(2022, 8, 1);
            var dayOfMonthPicker = new TestDayOfMonthPicker(date, DayOfWeek.Sunday);
            var expected = new int[][]
            {
                new [] { -1, 1,  2,  3,  4,  5,  6  },
                new [] { 7,  8,  9,  10, 11, 12, 13 },
                new [] { 14, 15, 16, 17, 18, 19, 20 },
                new [] { 21, 22, 23, 24, 25, 26, 27 },
                new [] { 28, 29, 30, 31, -1, -1, -1 },
            };

            // Act
            var actual = dayOfMonthPicker.CreateDayOfMonthPicker();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DayOfMonthPickerTests_CreateDayOfMonthPicker_31Days_FirstDaySunday_SixEmptyDaysAtTheBeginning_FiveAtTheEnd()
        {
            // Arrange
            var date = new DateTime(2022, 10, 1);
            var dayOfMonthPicker = new TestDayOfMonthPicker(date, DayOfWeek.Sunday);
            var expected = new int[][]
            {
                new [] { -1, -1, -1, -1, -1, -1, 1  },
                new [] { 2,  3,  4,  5,  6,  7,  8  },
                new [] { 9,  10, 11, 12, 13, 14, 15 },
                new [] { 16, 17, 18, 19, 20, 21, 22 },
                new [] { 23, 24, 25, 26, 27, 28, 29 },
                new [] { 30, 31, -1, -1, -1, -1, -1 },
            };

            // Act
            var actual = dayOfMonthPicker.CreateDayOfMonthPicker();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DayOfMonthPickerTests_CreateDayOfMonthPicker_31Days_FirstDaySunday_ZeroEmptyDaysAtTheBeginning_FourAtTheEnd()
        {
            // Arrange
            var date = new DateTime(2021, 8, 1);
            var dayOfMonthPicker = new TestDayOfMonthPicker(date, DayOfWeek.Sunday);
            var expected = new int[][]
            {
                new [] { 1,  2,  3,  4,  5,  6,  7  },
                new [] { 8,  9,  10, 11, 12, 13, 14 },
                new [] { 15, 16, 17, 18, 19, 20, 21 },
                new [] { 22, 23, 24, 25, 26, 27, 28 },
                new [] { 29, 30, 31, -1, -1, -1, -1 },
            };

            // Act
            var actual = dayOfMonthPicker.CreateDayOfMonthPicker();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DayOfMonthPickerTests_CreateDayOfMonthPicker_30Days_FirstDaySunday_TwoEmptyDaysAtTheBeginning_ThreeAtTheEnd()
        {
            // Arrange
            var date = new DateTime(2021, 6, 1);
            var dayOfMonthPicker = new TestDayOfMonthPicker(date, DayOfWeek.Sunday);
            var expected = new int[][]
            {
                new [] { -1, -1, 1,  2,  3,  4,  5  },
                new [] { 6,  7,  8,  9,  10, 11, 12 },
                new [] { 13, 14, 15, 16, 17, 18, 19 },
                new [] { 20, 21, 22, 23, 24, 25, 26 },
                new [] { 27, 28, 29, 30, -1, -1, -1 },
            };

            // Act
            var actual = dayOfMonthPicker.CreateDayOfMonthPicker();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DayOfMonthPickerTests_CreateDayOfMonthPicker_28Days_FirstDaySunday_ThreeEmptyDaysAtTheBeginning_FourAtTheEnd()
        {
            // Arrange
            var date = new DateTime(2023, 2, 1);
            var dayOfMonthPicker = new TestDayOfMonthPicker(date, DayOfWeek.Sunday);
            var expected = new int[][]
            {
                new [] { -1, -1, -1,  1,  2,  3,  4 },
                new [] {  5,  6,  7,  8,  9, 10, 11 },
                new [] { 12, 13, 14, 15, 16, 17, 18 },
                new [] { 19, 20, 21, 22, 23, 24, 25 },
                new [] { 26, 27, 28, -1, -1, -1, -1 },
            };

            // Act
            var actual = dayOfMonthPicker.CreateDayOfMonthPicker();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
