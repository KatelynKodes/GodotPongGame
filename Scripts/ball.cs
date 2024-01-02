using Godot;
using System;

public partial class ball : RigidBody2D
{
	private Vector2 _startingPosition;

	[Export] public float BallSpeed = 4.0f;
	private Vector2 _velocity = new Vector2(150.0f, 150.0f);

    public float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public Vector2 StartingPosition { get { return _startingPosition; } private set { _startingPosition = value; } }

	// Called when the node enters the scene tree for the first time.
	public override void _EnterTree()
	{
		base._EnterTree();
		_startingPosition = Position;
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		KinematicCollision2D _collisionData = MoveAndCollide(_velocity * BallSpeed * (float)delta);

		if (_collisionData != null)
		{
			_velocity = _velocity.Bounce(_collisionData.GetNormal());
		}
	}

	public void OnGoalEntered(Node2D body)
	{
		if (body.GetScript().GetType() == typeof(goal))
		{
			GD.Print("Please-");
			Position = _startingPosition;
		}
	}
}
