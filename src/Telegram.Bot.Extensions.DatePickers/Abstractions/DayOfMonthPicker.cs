using System;
using System.Collections.Generic;

namespace Telegram.Bot.Extensions.DatePickers.Abstractions
{
    /// <summary>
    /// Abstract factory for creating day of month date pickers.
    /// </summary>
    /// <typeparam name="T">The type of elements in the date picker widget.</typeparam>
    public abstract class DayOfMonthPicker<T>
    {
        public const int DaysInWeek = 7;

        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfMonthPicker{T}"/> with the first day of week set to Monday.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> with date which days to use.</param>
        protected DayOfMonthPicker(DateTime date)
            : this(date, DayOfWeek.Monday)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DayOfMonthPicker{T}"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> with date which days to use.</param>
        /// <param name="weekBeginsWith">The <see cref="DayOfWeek"/> from which week begins.</param>
        protected DayOfMonthPicker(DateTime date, DayOfWeek weekBeginsWith)
        {
            Date = date;
            WeekBeginsWith = weekBeginsWith;
        }

        /// <summary>
        /// Gets or sets the date which is represented by this <see cref="DayOfMonthPicker{T}"/>.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the day on which the week starts. Mainly used for Sunday or Monday.
        /// </summary>
        public DayOfWeek WeekBeginsWith { get; set; }

        /// <summary>
        /// Creates the <see cref="DayOfMonthPicker{T}"/> widget.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/> of <see cref="IEnumerable{T}"/> with <see cref="DayOfMonthPicker{T}"/> widget.</returns>
        public IEnumerable<IEnumerable<T>> CreateDayOfMonthPicker()
        {
            var numberOfDays = DateTime.DaysInMonth(Date.Year, Date.Month);
            var firstDayOfWeek = new DateTime(Date.Year, Date.Month, 1).DayOfWeek;
            
            var firstWeekEmptyDays = firstDayOfWeek - WeekBeginsWith;
            if (firstWeekEmptyDays < 0)
            {
                firstWeekEmptyDays = DaysInWeek + firstWeekEmptyDays;
            }

            // Calculating the number of weeks
            var daysInTotal = numberOfDays + firstWeekEmptyDays;
            var numberOfWeeks = daysInTotal / DaysInWeek + (daysInTotal % DaysInWeek == 0 ? 0 : 1);
            var datePicker = new T[numberOfWeeks][];

            // Filling the empty days
            datePicker[0] = new T[DaysInWeek];
            for (int i = 0; i < firstWeekEmptyDays; i++)
            {
                datePicker[0][i] = CreateEmptyButton();
            }

            // Filling the first week days
            var day = 1;
            for (int i = firstWeekEmptyDays; i < DaysInWeek; i++, day++)
            {
                datePicker[0][i] = CreateButton(new DateTime(Date.Year, Date.Month, day));
            }

            // Filling the other days of date
            for (int row = 1; row < numberOfWeeks; row++)
            {
                datePicker[row] = new T[DaysInWeek];
                for (int column = 0; column < DaysInWeek && day <= numberOfDays; column++, day++)
                {
                    datePicker[row][column] = CreateButton(new DateTime(Date.Year, Date.Month, day));
                }
            }

            // Filling the empty days in the end
            var emptyDaysLeft = numberOfWeeks * DaysInWeek - daysInTotal;
            for (int i = DaysInWeek - 1; i >= DaysInWeek - emptyDaysLeft; i--)
            {
                datePicker[^1][i] = CreateEmptyButton();
            }

            return datePicker;
        }

        /// <summary>
        /// Factory method used to create buttons of the day of month picker.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to create button with.</param>
        /// <returns><typeparamref name="T"/> button.</returns>
        protected abstract T CreateButton(DateTime date);

        /// <summary>
        /// Factory method used to create empty buttons of the day of month picker.
        /// </summary>
        /// <returns>Empty <typeparamref name="T"/> button.</returns>
        protected abstract T CreateEmptyButton();
    }
}
