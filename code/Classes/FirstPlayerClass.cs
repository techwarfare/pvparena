using pvparenas.Weapon;
using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvparenas.Classes
{
	class FirstPlayerClass : BasePlayerClass
	{
		public PvpPlayer player;
		public FirstPlayerClass(PvpPlayer _player)
		{
			player = _player;
		}
		public override void FirstAbility()
		{
			Log.Info("First Ability"+player.Name);

			var ragdoll = new ModelEntity();
			ragdoll.SetModel( "models/citizen/citizen.vmdl" );
			ragdoll.Position = player.EyePos + player.EyeRot.Forward * 40;
			ragdoll.Rotation = Rotation.LookAt( Vector3.Random.Normal );
			ragdoll.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
			ragdoll.PhysicsGroup.Velocity = player.EyeRot.Forward * 1000;
		}
		public override void SecondAbility()
		{
			Log.Info( "Second Ability" );
			var explosion = new TestWeapon();

			explosion.Spawn();
			explosion.Position = player.Position;
		}
		public override void UltimateAbility()
		{
			Log.Info( "Ultimate Abiltiy" );
		}
		public override void JumpAbility(PvpWalkController _controller)
		{

			Log.Info( "Jump Ability" );
		}
	}
}
