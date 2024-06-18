using System.Windows;
using System.Windows.Input;
// ReSharper disable UnusedMember.Global

namespace Engine;

public class KeyboardTracker : DependencyObject
{
    private readonly Dictionary<Key, State> _states;
    public Stack<Key> Typed { get; }

    public KeyboardTracker()
    {
        _states = new();
        Typed = new();
    }

    public State this[Key k] => _states[k];

    public void TrackKeys(params Key[] k)
    {
        foreach (Key key in k)
            _states.Add(key, State.Released);
    }

    public void StopTrackingKeys(params Key[] k)
    {
        foreach (Key key in k)
            _states.Remove(key);
    }

    public void StartTyping() => Keyboard.AddKeyDownHandler(this, KeyPressed);
    public void EndTyping() => Keyboard.RemoveKeyDownHandler(this, KeyPressed);

    private void KeyPressed(object sender, KeyEventArgs args) => Typed.Push(args.Key);

    public void Update()
    {
        foreach (KeyValuePair<Key, State> pair in _states)
            if (Keyboard.IsKeyDown(pair.Key))
                _states[pair.Key] = _states[pair.Key] is State.Released or State.JustReleased
                    ? State.JustPressed
                    : State.Pressed;
            else
                _states[pair.Key] = _states[pair.Key] is State.Pressed or State.JustPressed
                    ? State.JustReleased
                    : State.Released;
    }
}