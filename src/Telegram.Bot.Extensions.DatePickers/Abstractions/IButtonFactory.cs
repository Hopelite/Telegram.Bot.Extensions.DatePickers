using System;

namespace Telegram.Bot.Extensions.DatePickers.Abstractions
{
    /// <summary>
    /// Defines methods for date picking buttons factories.
    /// </summary>
    /// <typeparam name="T">Type of buttons.</typeparam>
    public interface IButtonFactory<out T>
    {
        /// <summary>
        /// Creates <typeparamref name="T"/> button of day of month picker.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/> to create button with.</param>
        /// <returns>Date picker button.</returns>
        public T CreateButton(DateTime date);

        /// <summary>
        /// Creates empty <typeparamref name="T"/> button of day of month picker.
        /// </summary>
        /// <returns>Empty date picker button.</returns>
        public T CreateEmptyButton();
    }
}
