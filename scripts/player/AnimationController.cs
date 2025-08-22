using ClassDirectionState;
using ClassPlayerEntity;
using Godot;
using System;
namespace Animations
{
	public partial class AnimationController : Node
	{

		public AnimationPlayer animPlayer;
		public PlayerEntity playerEntity;

		public override void _Ready()
		{
			animPlayer = GetNode<AnimationPlayer>("../AnimationPlayer");
		}

		public void tick(bool is_walk, DirectionState rotateDirection)
		{
			if (is_walk)
			{
				switch (rotateDirection)
				{
					case DirectionState.UP:
						animPlayer.Play("up");
						break;
					case DirectionState.LEFT:
						animPlayer.Play("left");
						break;
					case DirectionState.RIGHT:
						animPlayer.Play("right");
						break;
					case DirectionState.DOWN:
						animPlayer.Play("down");
						break;
				}
			}
			else
			{
				animPlayer.Stop();
			}
		}
	}
}
