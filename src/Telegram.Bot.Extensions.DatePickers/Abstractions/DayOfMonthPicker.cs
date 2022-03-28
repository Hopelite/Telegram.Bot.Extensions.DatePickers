﻿using System.Collections.Generic;

namespace Telegram.Bot.Extensions.DatePickers.Abstractions
{
    public abstract class DayOfMonthPicker<T>
    {
        public const int DaysInWeek = 7;

        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfMonthPicker{T}"/> with the first day of week set to Monday.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> with date which days to use.</param>
        protected DayOfMonthPicker(DateTime date)
            : this(date, DayOfWeek.Monday)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfMonthPicker{T}"/>.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> with date which days to use.</param>
        /// <param name="firstDayOfWeek"><see cref="DayOfWeek"/> from which week begins.</param>
        protected DayOfMonthPicker(DateTime date, DayOfWeek firstDayOfWeek)
        {
            this.Date = date;
            this.FirstDayOfWeek = firstDayOfWeek;
        }

        /// <summary>
        /// Gets date which is represented by this <see cref="DayOfMonthPicker{T}"/>.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets day on which week begins. Mainly used for Sunday or Monday.
        /// </summary>
        public DayOfWeek FirstDayOfWeek { get; set; }

        /// <summary>
        /// Creates <see cref="DayOfMonthPicker{T}"/> widget.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="IEnumerable{T}"/> with <see cref="DayOfMonthPicker{T}"/> widget.</returns>
        public IEnumerable<IEnumerable<T>> CreateDayOfMonthPicker()
        {
            var numberOfDays = DateTime.DaysInMonth(this.Date.Year, this.Date.Month);
            var firstWeekDaysLeft = DaysInWeek - (int)this.FirstDayOfWeek;
            var firstWeekEmptyDays = DaysInWeek - firstWeekDaysLeft;

            // Calculating number of weeks
            var daysInTotal = numberOfDays + firstWeekEmptyDays;
            var numberOfWeeks = daysInTotal / DaysInWeek + (daysInTotal % DaysInWeek == 0 ? 0 : 1);
            var datePicker = new T[numberOfWeeks][];

            // Fill empty days
            datePicker[0] = new T[DaysInWeek];
            for (int i = 0; i < firstWeekEmptyDays; i++)
            {
                datePicker[0][i] = this.CreateEmptyButton();
            }

            // Fill first week days
            var day = 1;
            for (int i = (int)this.FirstDayOfWeek; i < DaysInWeek; i++, day++)
            {
                datePicker[0][i] = this.CreateButton(new DateTime(this.Date.Year, this.Date.Month, day));
            }

            // Fill other days of date
            for (int row = 1; row < numberOfWeeks; row++)
            {
                datePicker[row] = new T[DaysInWeek];
                for (int column = 0; column < DaysInWeek && day <= numberOfDays; column++)
                {
                    datePicker[row][column] = this.CreateButton(new DateTime(this.Date.Year, this.Date.Month, day));
                }
            }

            // Fill empty days in the end
            var emptyDaysLeft = numberOfDays - numberOfWeeks * DaysInWeek;
            for (int i = 0; i < emptyDaysLeft; i++)
            {
                datePicker[^1][i] = CreateEmptyButton();
            }

            return datePicker;
        }

        protected abstract T CreateButton(DateTime date);

        protected abstract T CreateEmptyButton();
    }
}