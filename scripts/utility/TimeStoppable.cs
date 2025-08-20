
using ClassMainGame;
using Godot;

namespace ClassTimeStoppable {
	public abstract partial class TimeStoppableEntity : Node2D{
		
		public override void _Process(double delta) {
			if(!MainGame.getTimeStop()) {
				this.Proccess(delta);
			}
		}

		public override void _PhysicsProcess(double delta) {
			if(!MainGame.getTimeStop()) {
				this.PhysicsProcess(delta);
			}
		}

		public abstract void Proccess(double delta);
		public abstract void PhysicsProcess(double delta);
	}
}
