using Godot;

public partial class TickTimer : Node
{
    [Export]
    public Label TimerLabel;

    [Export]
    public Timer CountdownTimer;

    private int timeLeft = 60;

    public override void _Ready()
    {
        GD.Print("TickTimer Ready called!");
        GD.Print($"CountdownTimer is null? {CountdownTimer == null}");
        GD.Print($"TimerLabel is null? {TimerLabel == null}");

        if (CountdownTimer != null)
        {
            CountdownTimer.Timeout += OnTickTimerTimeout;
            CountdownTimer.Start();
            GD.Print("Timer started!");
        }
        else
        {
            GD.Print("ERROR: CountdownTimer is NULL!");
        }

        UpdateLabel();
    }

    private void OnTickTimerTimeout()
    {
        GD.Print("TICK! Time left: " + timeLeft);
        timeLeft--;
        UpdateLabel();

        if (timeLeft <= 0)
        {
            CountdownTimer.Stop();
            GD.Print("Game Over! Final Score: " + GetParent().Get("Score"));

            // End the game - choose one of these options:

            // Option 1: Restart the scene
            GetTree().ReloadCurrentScene();
        }
    }

    private void UpdateLabel()
    {
        if (TimerLabel != null)
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            TimerLabel.Text = $"Time: {minutes}:{seconds:D2}";
        }
    }
}