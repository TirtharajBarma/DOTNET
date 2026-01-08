using System;

class Button
{
    public delegate void ClickHandler();        //* Declare a delegate

    public event ClickHandler? Clicked;         //* Declared an event using delegate

    public void Click()                          //* method to raise the event
    {
        Clicked?.Invoke();                      //* Invoke is method
    }
}