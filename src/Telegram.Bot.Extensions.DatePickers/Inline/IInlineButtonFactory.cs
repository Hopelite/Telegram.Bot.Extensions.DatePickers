using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Extensions.DatePickers.Inline
{
    /// <summary>
    /// Defines methods for <see cref="InlineKeyboardButton"/> factories.
    /// </summary>
    public interface IInlineButtonFactory
    {
        /// <summary>
        /// Creates <see cref="InlineKeyboardButton"/> of day of month picker.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> to create button with.</param>
        /// <returns>Date picker button.</returns>
        public InlineKeyboardButton CreateButton(DateTime date);

        /// <summary>
        /// Creates empty  <see cref="InlineKeyboardButton"/> of day of month picker.
        /// </summary>
        /// <returns>Empty date picker button.</returns>
        public InlineKeyboardButton CreateEmptyButton();
    }
}
