using Godot;
using System;

public partial class goal : Area2D
{
	[Export] public paddle GoalOwner;

	public void OnBodyEntered(Node2D body)
	{
		if (body.IsInGroup("ball"))
		{
			//Distribute points
			GameManager.Instance.AddPoints(this);
		}
	}
}
