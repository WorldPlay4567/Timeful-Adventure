using ClassMainGame;
using ClassPlayerEntity;
using Godot;
using System;

public partial class SceneChanger : Area2D
{
	[Export]
	public string sceneToChangeOn;
	[Export]
	public Marker2D spawnPos;
	[Export]
	public PlayerEntity player;
	public ResourcePreloader preloader = new();
	public PackedScene loadingScreen = ResourceLoader.Load<PackedScene>("res://util_scenes/loading_screen.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		BodyEntered += OnBodyEntered;
		player.GlobalPosition = spawnPos.GlobalPosition;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnBodyEntered(Node2D body)
	{

		CallDeferred(nameof(ChangeScene));
	}
	public void ChangeScene()
	{
		MainGame.newScene = "res://location" + "/" + sceneToChangeOn + "/" + sceneToChangeOn + ".tscn";
		GetTree().ChangeSceneToPacked(loadingScreen);
		
	}
    
}
