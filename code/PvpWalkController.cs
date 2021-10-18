using Sandbox;

namespace pvparenas
{
	class PvpWalkController : WalkController
	{
		public float doubleJumpCooldown = 5f;
		public float doubleJumpTimeStamp;
		public bool doubleJumped = false;
		public PvpWalkController()
		{

		}
		public override void Simulate()
		{
			base.Simulate();

			if ( doubleJumped == false || GroundEntity == null ) return;

			if (Time.Now > doubleJumpTimeStamp + doubleJumpCooldown )
			{
				doubleJumped = false;
			}
		}
		public override void CheckJumpButton()
		{
			var player = Local.Pawn;
			PvpPlayer pvpPlayer = (PvpPlayer)player;
			if ( pvpPlayer != null )
			{
				if ( pvpPlayer.playersClass != null )
				{
					pvpPlayer.playersClass.JumpAbility( this );
				}
			}

			/*if ( GroundEntity == null )
			{
				if ( Input.Pressed( InputButton.Jump ) )
				{
					if ( doubleJumped ) return;
					doubleJumpTimeStamp = Time.Now;
					doubleJumped = true;
					Velocity = Velocity * 10f;

					*//*var velX = Velocity.x;
					var velY = Velocity.y;
					Velocity = new Vector3( velX * 20, velY * 5, 0f );*//*
				}
			}*/
			base.CheckJumpButton();
		}
	}
}
