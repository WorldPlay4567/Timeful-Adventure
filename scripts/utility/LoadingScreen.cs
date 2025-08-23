using System.Threading.Tasks;
using ClassMainGame;
using Godot;
using Godot.Collections;
public partial class LoadingScreen : Control
{
	[Export]
	public ProgressBar progressBar;
	public Array progress = new();
	public string newScene;
	public ResourceLoader.ThreadLoadStatus sceneLoadStatus;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		newScene = MainGame.newScene;
		progressBar = GetNode<ProgressBar>("ProgressBar");
		
		ResourceLoader.LoadThreadedRequest(newScene);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double _delta)
	{
		sceneLoadStatus = ResourceLoader.LoadThreadedGetStatus(newScene, progress);
		progressBar.Value = (float)progress[0] * 100;
		if (sceneLoadStatus == ResourceLoader.ThreadLoadStatus.Loaded)
		{
			_ChangeScene();
		}
	}
	private async Task _ChangeScene()
	{
		await ToSignal(GetTree().CreateTimer(2), "timeout");
		GetTree().ChangeSceneToFile(newScene);
	}
}
