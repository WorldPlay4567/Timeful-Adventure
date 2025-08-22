
using System.Linq;

using Godot;
using Godot.Collections;

public partial class LevelManager : Node2D
	{
		[Export]
		public int cooldownWaveTimeSec;
		[Export]
		public Timer cooldownWaveTimer;
		[Export]
		public Node2D rootNode;
		[Export]
		public PackedScene boss;
		[Export]
		public Array<PackedScene> enemies;
		[Export]
		public Dictionary<int, int> waves;
		public RandomNumberGenerator rng = new();
		[Export]
		public int currentWave;
		public int deadEnemiesCounter = 0;
		public Array<EnemySpawnPoint> enemySpawnPoints = new();
		public override void _Ready()
		{
			ConnectSignals();
			cooldownWaveTimer.WaitTime = cooldownWaveTimeSec;
			foreach (Node point in GetChildren())
			{
				if (point is EnemySpawnPoint)
				{
					GD.Print(point.Name);
					enemySpawnPoints.Add(point as EnemySpawnPoint);
				}
			}

		}
		public void SpawnEnemies()
		{
			if (currentWave <= waves.Keys.Last())
			{
				for (int i = 1; i <= waves[currentWave]; i++)
				{
					EnemySpawnPoint chosenEnemySpawnPoint = enemySpawnPoints[rng.RandiRange(0, enemySpawnPoints.Count - 1)];
					Enemy chosenInstantiatedEnemy = enemies[rng.RandiRange(0, enemies.Count - 1)].Instantiate<Enemy>();
					chosenInstantiatedEnemy.Position = chosenEnemySpawnPoint.GlobalPosition;
					rootNode.AddChild(chosenInstantiatedEnemy);
					ToSignal(GetTree().CreateTimer(1), "timeout");
				}
			}
			else
			{
				Boss bossNode = boss.Instantiate() as Boss;
				rootNode.AddChild(bossNode);
			}
		}
	public void CountDeadEnemies()
	{
		deadEnemiesCounter += 1;
		if (deadEnemiesCounter == waves[currentWave])
		{
			
			deadEnemiesCounter = 0;
			currentWave += 1;
			cooldownWaveTimer.Start();
		}
	}
	private void ConnectSignals()
	{
		SignalBus.Instance.EnemyDied+=CountDeadEnemies;
		cooldownWaveTimer.Timeout += SpawnEnemies;
	}
	private void DisconnectSignals()
	{	
		SignalBus.Instance.EnemyDied -= CountDeadEnemies;
		cooldownWaveTimer.Timeout -= SpawnEnemies;
	}
	public override void _ExitTree()
		{
			DisconnectSignals();
		}
	}
