using System;
using Telegram.Bot.Extensions.DatePickers.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Extensions.DatePickers.Keyboard
{
    /// <summary>
    /// Implements <see cref="DayOfMonthPicker{T}"/> with <see cref="KeyboardButton"/>s.
    /// </summary>
    public class KeyboardDayOfMonthPicker : DayOfMonthPicker<KeyboardButton>
    {
        private readonly IButtonFactory<KeyboardButton> _keyboardButtonFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardDayOfMonthPicker"/> with the first day of week set to Monday.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> with date which days to use.</param>
        /// <param name="keyboardButtonFactory">Optional. <see cref="IButtonFactory{T}"/> to create buttons with. If null, will use <see cref="DefaultDayKeyboardButtonFactory"/> instead.</param>
        public KeyboardDayOfMonthPicker(DateTime date, IButtonFactory<KeyboardButton>? keyboardButtonFactory = null)
            : this(date, DayOfWeek.Monday, keyboardButtonFactory)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardDayOfMonthPicker"/> with the first day of week set to Monday.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> with date which days to use.</param>
        /// <param name="weekBeginsWith"><see cref="DayOfWeek"/> from which week begins.</param>
        /// <param name="keyboardButtonFactory">Optional. <see cref="IButtonFactory{T}"/> to create buttons with. If null, will use <see cref="DefaultDayKeyboardButtonFactory"/> instead.</param>
        public KeyboardDayOfMonthPicker(DateTime date, DayOfWeek weekBeginsWith, IButtonFactory<KeyboardButton>? keyboardButtonFactory = null)
            : base(date, weekBeginsWith)
        {
            _keyboardButtonFactory = keyboardButtonFactory ?? new DefaultDayKeyboardButtonFactory();
        }

        /// <inheritdoc/>
        protected override KeyboardButton CreateButton(DateTime date)
        {
            return _keyboardButtonFactory.CreateButton(date);
        }

        /// <inheritdoc/>
        protected override KeyboardButton CreateEmptyButton()
        {
            return _keyboardButtonFactory.CreateEmptyButton();
        }
    }
}
