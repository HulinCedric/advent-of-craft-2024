namespace ControlSystem.Core;

public class Sleigh
{
    public Sleigh()
    {
        Status = SleighEngineStatus.Off;
        Action = SleighAction.Parked;
    }

    public SleighEngineStatus Status { get; private set; }
    public SleighAction Action { get; private set; }

    public void Ascend()
    {
        Action = SleighAction.Flying;
    }

    public void Descend()
    {
        Action = SleighAction.Hovering;
    }

    public void Park()
    {
        Action = SleighAction.Parked;
    }

    public void TurnOn()
    {
        Status = SleighEngineStatus.On;
    }

    public void TurnOff()
    {
        Status = SleighEngineStatus.Off;
    }
}