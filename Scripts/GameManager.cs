using Godot;
using System;

public partial class GameManager : Node2D
{
	[Export] public ball BallObject;
	private static GameManager _instance;

	//Round stuff
	private bool _roundEnded;
	private int _currentRound = 0;
	[Export] private int TotalRounds;
	private bool _gameEnd;

	public bool RoundEnded { get { return _roundEnded; } }

	//Player Scores
	private int _player1Score = 0;
	private int _player2Score = 0;

	public int CurrentRound { get { return _currentRound; } }
	public int Player1Score { get { return _player1Score; } }
	public int Player2Score { get { return _player2Score; } }
	public bool GameEnd { get { return _gameEnd; } }


	public static GameManager Instance 
	{ 
		get 
		{
			if(_instance == null)
				_instance = new GameManager();
			return _instance;
		} 
	}

	private GameManager()
	{
		_instance = this;
	}

	public override void _Ready()
	{
		base._Ready();

	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		if (RoundEnded)
		{
			ResetStage();
		}

		if (_currentRound == TotalRounds)
		{
			//Game End
			EndGame();
		}
	}

	public void AddPoints(goal goalhit)
	{
        switch (goalhit.GoalOwner.playerNum)
		{
			case 1:
				_player2Score++;
				break;
			case 2:
				_player1Score++;
				break;
            default:
				break;
		}

        _roundEnded = true;
    }

	public void ResetStage()
	{
		BallObject.Position = BallObject.StartingPosition;
        _currentRound++;
        _roundEnded = false;
    }

	public void EndGame()
	{
		BallObject.Position = BallObject.StartingPosition;
		BallObject.Freeze = true;
		_gameEnd = true;
	}
}
