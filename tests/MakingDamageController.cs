using Godot;
using System;

public partial class MakingDamageController : Node
{
	public Enemy enemyBody;
	[Export]
	public Area2D area2D;
	public override void _Ready()
	{
		area2D.BodyEntered += OnArea2DEntered;
		area2D.BodyExited += OnArea2DExited;
	}
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("temp_attack") && enemyBody != null)
		{

			enemyBody.TakeDamage(-1);
			
		}
	}
	public void OnArea2DEntered(Node2D body)
	{
		if (body is Enemy)
		{
			enemyBody = body as Enemy;
		}
	}
	public void OnArea2DExited(Node2D _body)
	{
		enemyBody = null;
	}
}
