using Godot;
using Animations;

using System;
using ClassDirectionState;
namespace ClassPlayerEntity
{
	public partial class PlayerEntity : CharacterBody2D
	{
		public const float Speed = 300.0f;
		public bool is_walk = false;
		public DirectionState RotateDirection = DirectionState.DOWN;
		public AnimationController animController;
		public override void _Ready()
		{
			animController = GetNode<AnimationController>("AnimationController");
		}

		public override void _PhysicsProcess(double delta)
		{
			Vector2 velocity = Velocity;

			Vector2 direction = Input.GetVector("player_left", "player_right", "player_up", "player_down");
			if (direction != Vector2.Zero)
			{
				velocity.X = direction.X * Speed;
				velocity.Y = direction.Y * Speed;

				setDirection(direction);
				is_walk = true;
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
				velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);

				is_walk = false;
			}

			Velocity = velocity;
			MoveAndSlide();
		}

		public override void _Process(double delta)
		{
			animController.tick(is_walk, RotateDirection);
		}

		public void setDirection(Vector2 direction)
		{
			if (direction == Vector2.Zero) { return; }
			DirectionState _newDirection = 0;

			if (direction.Y == 0)
			{
				_newDirection = direction.X < 0 ? DirectionState.LEFT : DirectionState.RIGHT;
			}
			else if (direction.X == 0)
			{
				_newDirection = direction.Y < 0 ? DirectionState.UP : DirectionState.DOWN;
			}
			else
			{
				_newDirection = direction.X < 0 ? DirectionState.LEFT : DirectionState.RIGHT;
			}
			RotateDirection = _newDirection;
		}


	}
}
