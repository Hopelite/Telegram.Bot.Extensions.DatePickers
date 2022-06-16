using System;

namespace Telegram.Bot.Extensions.DatePickers.Abstractions
{
    /// <summary>
    /// Defines methods for date picking buttons factories.
    /// </summary>
    /// <typeparam name="T">The type of buttons.</typeparam>
    public interface IButtonFactory<out T>
    {
        /// <summary>
        /// Creates a <typeparamref name="T"/> button of the day of month picker.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to create button with.</param>
        /// <returns>A date picker button.</returns>
        public T CreateButton(DateTime date);

        /// <summary>
        /// Creates an empty <typeparamref name="T"/> button of the day of month picker.
        /// </summary>
        /// <returns>An empty date picker button.</returns>
        public T CreateEmptyButton();
    }
}
