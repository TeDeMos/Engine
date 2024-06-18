using System.Windows;
using System.Windows.Input;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Engine;

public class MouseTracker
{
    private readonly IInputElement _element;
    private readonly double _systemScale;
    private readonly int _xScale;
    private readonly int _yScale;
    private Int2 _next;

    public MouseTracker(IInputElement element, int xScale, int yScale, double systemScale)
    {
        Left = State.Released;
        Right = State.Released;
        Middle = State.Released;
        Previous = new(0, 0);
        Position = new(0, 0);
        _next = new(0, 0);
        _element = element;
        _xScale = xScale;
        _yScale = yScale;
        _systemScale = systemScale;
    }

    public State Left { get; private set; }
    public State Right { get; private set; }
    public State Middle { get; private set; }
    public Int2 Previous { get; private set; }
    public Int2 Position { get; private set; }

    public void Update()
    {
        Previous = Position;
        Position = _next;
        Left = GetState(Mouse.LeftButton, Left);
        Right = GetState(Mouse.RightButton, Right);
        Middle = GetState(Mouse.MiddleButton, Middle);
    }

    private static State GetState(MouseButtonState sysState, State state)
    {
        if (sysState == MouseButtonState.Pressed)
            return state is State.Pressed or State.JustPressed ? State.Pressed : State.JustPressed;
        return state is State.Released or State.JustReleased ? State.Released : State.JustReleased;
    }

    public void OnMouseMove(object sender, MouseEventArgs e)
    {
        Point p = e.GetPosition(_element);
        _next = new((int)(_systemScale * p.X / _xScale), (int)(_systemScale * p.Y / _yScale));
    }
}