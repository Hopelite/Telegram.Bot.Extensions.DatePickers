using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Bot.Extensions.DatePickers.Tests.TestTypes
{
    public static class DayOfMonthPickerTestData
    {
        /// <summary>
        /// Gets test data with first day of week set to Monday.
        /// </summary>
        public static IEnumerable<object[]> ExpectedFirstDayMonday
        {
            get
            {
                return new[]
                {
                    new object []
                    {
                        new DateTime(2022, 8, 1),
                        DayOfWeek.Monday,
                        new[]
                        {
                            new [] {  1,  2,  3,  4,  5,  6,  7 },
                            new [] {  8,  9, 10, 11, 12, 13, 14 },
                            new [] { 15, 16, 17, 18, 19, 20, 21 },
                            new [] { 22, 23, 24, 25, 26, 27, 28 },
                            new [] { 29, 30, 31, -1, -1, -1, -1 },
                        },
                    },
                };
            }
        }

        /// <summary>
        /// Gets test data with first day of week set to Sunday.
        /// </summary>
        public static IEnumerable<object[]> ExpectedFirstDaySunday
        {
            get
            {
                return new []
                {
                    new object [] 
                    {
                        new DateTime(2022, 8, 1),
                        DayOfWeek.Sunday,
                        new []
                        {
                            new [] { -1,  1,  2,  3,  4,  5,  6 },
                            new [] {  7,  8,  9, 10, 11, 12, 13 },
                            new [] { 14, 15, 16, 17, 18, 19, 20 },
                            new [] { 21, 22, 23, 24, 25, 26, 27 },
                            new [] { 28, 29, 30, 31, -1, -1, -1 },
                        },
                    },

                    new object []
                    {
                        new DateTime(2022, 10, 1),
                        DayOfWeek.Sunday,
                        new []
                        {
                            new [] { -1, -1, -1, -1, -1, -1,  1 },
                            new [] {  2,  3,  4,  5,  6,  7,  8 },
                            new [] {  9, 10, 11, 12, 13, 14, 15 },
                            new [] { 16, 17, 18, 19, 20, 21, 22 },
                            new [] { 23, 24, 25, 26, 27, 28, 29 },
                            new [] { 30, 31, -1, -1, -1, -1, -1 },
                        },
                    },

                    new object []
                    {
                        new DateTime(2021, 8, 1),
                        DayOfWeek.Sunday,
                        new []
                        {
                            new [] {  1,  2,  3,  4,  5,  6,  7 },
                            new [] {  8,  9, 10, 11, 12, 13, 14 },
                            new [] { 15, 16, 17, 18, 19, 20, 21 },
                            new [] { 22, 23, 24, 25, 26, 27, 28 },
                            new [] { 29, 30, 31, -1, -1, -1, -1 },
                        },
                    },

                    new object []
                    {
                        new DateTime(2021, 6, 1),
                        DayOfWeek.Sunday,
                        new []
                        {
                            new [] { -1, -1,  1,  2,  3,  4,  5 },
                            new [] {  6,  7,  8,  9, 10, 11, 12 },
                            new [] { 13, 14, 15, 16, 17, 18, 19 },
                            new [] { 20, 21, 22, 23, 24, 25, 26 },
                            new [] { 27, 28, 29, 30, -1, -1, -1 },
                        },
                    },

                    new object []
                    {
                        new DateTime(2023, 2, 1),
                        DayOfWeek.Sunday,
                        new []
                        {
                            new [] { -1, -1, -1,  1,  2,  3,  4 },
                            new [] {  5,  6,  7,  8,  9, 10, 11 },
                            new [] { 12, 13, 14, 15, 16, 17, 18 },
                            new [] { 19, 20, 21, 22, 23, 24, 25 },
                            new [] { 26, 27, 28, -1, -1, -1, -1 },
                        }
                    },
                };
            }
        }
    }
}
