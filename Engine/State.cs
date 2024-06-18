// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace Engine;

public enum State
{
    JustReleased,
    Released,
    JustPressed,
    Pressed
}

public static class StateMethods
{
    public static bool Down(this State state) => state is State.JustPressed or State.Pressed;
    public static bool Up(this State state) => state is State.JustReleased or State.Released;
}