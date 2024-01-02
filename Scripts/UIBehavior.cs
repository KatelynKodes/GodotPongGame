using Godot;
using System;

public partial class UIBehavior : CanvasLayer
{
	[Export] private Label _player1Score;
	[Export] private Label _player2Score;
	[Export] private Label _currentRoundNum;

	[Export] private PanelContainer _winningMessagePanel;
	[Export] private Label _winningMessageLabel;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_player1Score.Text = GameManager.Instance.Player1Score.ToString();
		_player2Score.Text = GameManager.Instance.Player2Score.ToString();
		_currentRoundNum.Text = GameManager.Instance.CurrentRound.ToString();

		//If The Game has ended
		if (GameManager.Instance.GameEnd)
		{
			if (GameManager.Instance.Player1Score > GameManager.Instance.Player2Score)
			{
				_winningMessageLabel.Text = "Player 1 wins the game! Congrats!";
			}
			else
			{
				_winningMessageLabel.Text = "Player 2 wins the game! Congrats!";
            }

            _winningMessagePanel.Visible = true;
		}
	}
}
