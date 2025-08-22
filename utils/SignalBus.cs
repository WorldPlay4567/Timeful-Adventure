using Godot;
using System;

public partial class SignalBus : Node
{
	[Signal]
	public delegate void EnemyDiedEventHandler();
	public static SignalBus Instance;
    public override void _Ready()
    {
		Instance = this;
    }
}
