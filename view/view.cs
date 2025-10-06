using System;

// 1. Publisher
class AlarmClock
{
    // Define an event based on EventHandler delegate
    public event EventHandler Ring;

    public void TriggerAlarm()
    {
        Console.WriteLine("Alarm is ringing...");
        Ring?.Invoke(this, EventArgs.Empty); // Raise the event
    }
}

// 2. Subscriber
class User
{
    private string name;
    public User(string name) => this.name = name;

    // Method to handle the event
    public void OnAlarmRings(object sender, EventArgs e)
    {
        Console.WriteLine($"{name} wakes up!");
    }
}

// 3. Client
class Program
{
    static void Main()
    {
        AlarmClock alarm = new AlarmClock();

        User user1 = new User("Jai");
        User user2 = new User("Priya");

        // Subscribe to the event
        alarm.Ring += user1.OnAlarmRings;
        alarm.Ring += user2.OnAlarmRings;

        // Trigger the alarm
        alarm.TriggerAlarm();
    }
}
