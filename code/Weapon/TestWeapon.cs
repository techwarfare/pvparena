using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvparenas.Weapon
{
	//TODO: Turn this into the base weapon for us to use
	class TestWeapon : BaseWeapon
	{
		private bool used = false;
		public TestWeapon()
		{
			SetModel( Model.Load( "Weapons/rust_crossbow/rust_crossbow.vmdl" ) );
		}
		public override void BuildInput( InputBuilder inputBuilder )
		{
			if ( used ) return;
			if ( inputBuilder.Down( InputButton.Use ) )
			{
				used = true;
				Log.Info( "Using" );
				UseItem(inputBuilder.ActiveChild);
				
			}
			base.BuildInput( inputBuilder );
		}
		public void UseItem(Entity user)
		{
			if ( user == null ) return;

			if (user.Inventory.Add( this, true ))
			{
				EnableDrawing = false;
				used = false;
			}
		}
		public override void Touch( Entity other )
		{
			base.Touch( other );
			
			if ( other.Inventory == null ) return;
			//other.Inventory.Add( this, true );
			Log.Info( "Touched" );
		}
		public override void OnCarryStart( Entity carrier )
		{
			base.OnCarryStart( carrier );
			Log.Info( "Carry" );
		}

		public override void AttackPrimary()
		{
			//Maybe we could look for a bone in the model and we can actually shoot it from there
			Vector3 eyePos = Owner.EyePos;
			Vector3 eyeRot = Owner.EyeRot.Forward;
			Log.Info( eyePos );
			foreach ( TraceResult tr in base.TraceBullet( eyePos, eyePos + (eyeRot * 500f)).Cast<TraceResult>())
			{
				var explosion = new TestWeapon();

				explosion.Spawn();
				explosion.Position = tr.EndPos;
			}
		}
		
	}
}
