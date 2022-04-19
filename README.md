# Datepickers for .NET Telegram Bots

Contains implementations of datepickers for Telegram bots.

## Day of Month Pickers

You can use `InlineDayOfMonthPicker` to create datepicker as Inline Keyboard:

[InlineDayOfMonthPicker with FirstDayOfWeek set to Monday](https://user-images.githubusercontent.com/74190492/161345169-8e0bfc7f-0289-475c-a888-eb9450d3d220.png)

Example of usage:
```
var datePicker =  new InlineDayOfMonthPicker(DateTime.Now, new InlineButtonFactory());

await botClient.SendTextMessageAsync(
    chatId: chatId,
    text: "This is a datepicker with first day of week set to Monday 📅",
    replyMarkup: new ReplyKeyboardMarkup(datePicker.CreateDayOfMonthPicker()));

...

class InlineButtonFactory : IButtonFactory<InlineKeyboardButton>
{
    public InlineKeyboardButton CreateButton(DateTime date)
    {
        return InlineKeyboardButton.WithCallbackData(date.Day.ToString());
    }

    public InlineKeyboardButton CreateEmptyButton()
    {
        return InlineKeyboardButton.WithCallbackData("*");
    }
}
```

You can set the first day of week to adapt datepicker for end user:

```
var datePicker =  new InlineDayOfMonthPicker(DateTime.Now, DayOfWeek.Sunday, new InlineButtonFactory());
```

Result:

[InlineDayOfMonthPicker with FirstDayOfWeek set to Sunday](https://user-images.githubusercontent.com/74190492/161345194-296e2702-22aa-4619-8d3f-5ae9276e7866.png)