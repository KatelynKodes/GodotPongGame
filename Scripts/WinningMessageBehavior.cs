using Godot;
using System;

public partial class WinningMessageBehavior : PanelContainer
{
	public override void _Ready()
	{
		base._Ready();

		if (this.Visible)
			this.Visible = false;
	}

	public void OnRestartBttnPressed()
	{
		//Restart the scene
		GetTree().ReloadCurrentScene();
	}

	public void OnQuitBttnPressed()
	{
		//Quit Game
		GetTree().Quit();
	}
}
