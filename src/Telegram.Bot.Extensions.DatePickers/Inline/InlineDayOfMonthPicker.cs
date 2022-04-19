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
        /// <param name="inlineButtonFactory"><see cref="IButtonFactory{T}"/> to create buttons with.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="inlineButtonFactory"/> is null.</exception>
        public InlineDayOfMonthPicker(DateTime date, IButtonFactory<InlineKeyboardButton> inlineButtonFactory)
            : this(date, DayOfWeek.Monday, inlineButtonFactory)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineDayOfMonthPicker"/>.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> with date which days to use.</param>
        /// <param name="weekBeginsWith"><see cref="DayOfWeek"/> from which week begins.</param>
        /// <param name="inlineButtonFactory"><see cref="IButtonFactory{T}"/> to create buttons with.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="inlineButtonFactory"/> is null.</exception>
        public InlineDayOfMonthPicker(DateTime date, DayOfWeek weekBeginsWith, IButtonFactory<InlineKeyboardButton> inlineButtonFactory)
            : base(date, weekBeginsWith)
        {
            this._inlineButtonFactory = inlineButtonFactory ?? throw new ArgumentNullException(nameof(inlineButtonFactory));
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
