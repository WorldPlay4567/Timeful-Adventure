using Godot;

[GlobalClass]
public partial class Enemy : CharacterBody2D
{
	[Export]
	public int health;
  
	public void TakeDamage(int damage)
	{
		health += damage;
		if (health <= 0)
		{
			SignalBus.Instance.EmitSignal(SignalBus.SignalName.EnemyDied);
			QueueFree();
		}
	}
}
