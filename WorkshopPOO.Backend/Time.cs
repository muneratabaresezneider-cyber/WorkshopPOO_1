namespace WorkshopPOO.Backend;

public class Time
{
    private int _hour;  
    private int _minute;
    private int _second;
    private int _millisecond;

    public Time()
    {
        _hour = 0;
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }

    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecond = 0;

    }

    public Time(int hour, int minute) 
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecond = 0;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = 0;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour(value);
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }

    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }

    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(nameof(hour), "Hour must be between 0 and 23.");
        }
        return hour;
    }

    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(minute), "Minute must be between 0 and 59.");
        }
        return minute;
    }

    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(second), "Second must be between 0 and 59.");
        }
        return second;
    }

    private int ValidateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new ArgumentOutOfRangeException(nameof(millisecond), "Millisecond must be between 0 and 999.");
        }
        return millisecond;
    }

    public override string ToString()
    {
        {
            int displayHour = _hour;
            string amPm = _hour < 12 ? "AM" : "PM";

            if (_hour > 12) displayHour = _hour - 12;
            else if (_hour == 12) displayHour = 12;
            else if (_hour == 0) displayHour = 0;

            return $"{displayHour:00}:{_minute:00}:{_second:00}.{_millisecond:000} {amPm}";
        }
    }

    public long ToMilliseconds()
    {
        return (_hour * 3600000L) + (_minute * 60000L) + (_second * 1000L) + _millisecond;
    }

    public long ToSeconds()
    {
        return (_hour * 3600L) + (_minute * 60L) + _second;
    }

    public long ToMinutes()
    {
        return (_hour * 60L) + _minute;
    }

    public bool IsOtherDay(Time other)
    {
        int ms = _millisecond + other.Millisecond;
        int carrySec = ms / 1000;

        int sec = _second + other.Second + carrySec;
        int carryMin = sec / 60;

        int min = _minute + other.Minute + carryMin;
        int carryHour = min / 60;

        int h = _hour + other.Hour + carryHour;

        return h >= 24;
    }

    public Time Add(Time other)
    {
        int ms = _millisecond + other.Millisecond;
        int carrySec = ms / 1000;
        ms %= 1000;

        int sec = _second + other.Second + carrySec;
        int carryMin = sec / 60;
        sec %= 60;

        int min = _minute + other.Minute + carryMin;
        int carryHour = min / 60;
        min %= 60;

        int h = _hour + other.Hour + carryHour;
        h %= 24;

        return new Time(h, min, sec, ms);
    }
}
