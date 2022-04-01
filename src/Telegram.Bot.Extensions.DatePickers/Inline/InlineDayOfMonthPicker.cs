using System;
using Telegram.Bot.Extensions.DatePickers.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Extensions.DatePickers.Inline
{
    /// <summary>
    /// Implements <see cref="DayOfMonthPicker{T}"/> with <see cref="InlineKeyboardButton"/>s.
    /// </summary>
    public class InlineDayOfMonthPicker : DayOfMonthPicker<InlineKeyboardButton>
    {
        private readonly IButtonFactory<InlineKeyboardButton> _inlineButtonFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineDayOfMonthPicker"/> with the first day of week set to Monday.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> with date which days to use.</param>
        /// <param name="buttonFactory"><see cref="IButtonFactory{T}"/> to create buttons with.</param>
        public InlineDayOfMonthPicker(DateTime date, IButtonFactory<InlineKeyboardButton> buttonFactory)
            : this(date, DayOfWeek.Monday, buttonFactory)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineDayOfMonthPicker"/>.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> with date which days to use.</param>
        /// <param name="weekBeginsWith"><see cref="DayOfWeek"/> from which week begins.</param>
        /// <param name="buttonFactory"><see cref="IButtonFactory{T}"/> to create buttons with.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="buttonFactory"/> is null.</exception>
        public InlineDayOfMonthPicker(DateTime date, DayOfWeek weekBeginsWith, IButtonFactory<InlineKeyboardButton> buttonFactory)
            : base(date, weekBeginsWith)
        {
            this._inlineButtonFactory = buttonFactory ?? throw new ArgumentNullException(nameof(buttonFactory));
        }

        /// <inheritdoc/>
        protected override InlineKeyboardButton CreateButton(DateTime date)
        {
            return this._inlineButtonFactory.CreateButton(date);
        }

        /// <inheritdoc/>
        protected override InlineKeyboardButton CreateEmptyButton()
        {
            return this._inlineButtonFactory.CreateEmptyButton();
        }
    }
}
