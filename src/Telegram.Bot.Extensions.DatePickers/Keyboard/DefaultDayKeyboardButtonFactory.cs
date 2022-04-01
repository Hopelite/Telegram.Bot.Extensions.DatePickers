using System;
using Telegram.Bot.Extensions.DatePickers.Abstractions;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Extensions.DatePickers.Keyboard
{
    /// <summary>
    /// Contains default implementation of <see cref="IButtonFactory{T}"/> for <see cref="KeyboardDayOfMonthPicker"/>.
    /// </summary>
    internal class DefaultDayKeyboardButtonFactory : IButtonFactory<KeyboardButton>
    {
        private const string WhiteSpace = " ";

        /// <inheritdoc/>
        public KeyboardButton CreateButton(DateTime date)
        {
            return new KeyboardButton(date.Day.ToString());
        }

        /// <inheritdoc/>
        public KeyboardButton CreateEmptyButton()
        {
            return new KeyboardButton(WhiteSpace);
        }
    }
}
