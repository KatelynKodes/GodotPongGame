using Godot;
using System;

public partial class paddle : CharacterBody2D
{
	[Export] public int playerNum;
	private const float _speed = 300.0f;

	public float Speed { get { return _speed; }}
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = new Vector2(0.0f, Input.GetAxis("MoveDown", "MoveUp"));
		
		if (direction.Y != 0)
		{
			velocity.Y = direction.Y * _speed;
		}
		else
		{
			velocity = Vector2.Zero;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
