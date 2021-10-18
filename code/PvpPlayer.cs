using pvparenas.Classes;
using pvparenas.Items;
using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pvparenas
{
	partial class PvpPlayer : Player
	{
		public float Resource = 100f;
		public BasePlayerClass playersClass;
		public List<PvpItemBase> playersItems = new List<PvpItemBase>();
		public bool playerFirstSpawn;
		public PvpPlayer()
		{
			playersClass = new FirstPlayerClass(this);
		}
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			//
			// Use WalkController for movement (you can make your own PlayerController for 100% control)
			//
			Controller = new PvpWalkController();
			
			//Inventory
			Inventory = new PvpPlayerInventory(this);
			
			//
			// Use StandardPlayerAnimator  (you can make your own PlayerAnimator for 100% control)
			//
			Animator = new StandardPlayerAnimator();

			//
			// Use ThirdPersonCamera (you can make your own Camera for 100% control)
			//
			Camera = new ThirdPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		/// <summary>
		/// Called every tick, clientside and serverside.
		/// </summary>
		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			//
			// If you have active children (like a weapon etc) you should call this to 
			// simulate those too.
			//
			SimulateActiveChild( cl, ActiveChild );

			//
			// If we're running serverside and Attack1 was just pressed, spawn a ragdoll
			//
			if ( !IsServer ) return;

			//Loop through all the players items and execute the items function
			/*foreach (PvpItemBase item in playersItems)
			{
				item.ItemModifier();
			}*/
			if ( Input.Pressed(InputButton.Alt1) )
			{
				Log.Info( "Pressed Alt1" );
				playersClass.FirstAbility();
			}

			if ( Input.Pressed( InputButton.Alt2 ) )
			{
				playersClass.SecondAbility();
			}

			if (Input.MouseWheel != 0 )
			{
				if (Input.MouseWheel > 0 )
				{
					//Mouse wheel input was greater than zero, a postive value

					//If we have more than one item, empty hands count as one
					if ( Inventory.Count() > 0 )
					{
						//Check the that the slotid is not greater than the count of the inventory
						if ( Inventory.GetActiveSlot() + 1 >= Inventory.Count() ) return;

						//Swap the active child to the new weapon
						ActiveChild = Inventory.GetSlot( Inventory.GetActiveSlot() + 1 );
					}
				}
				else
				{
					//Mouse wheel input was less than zero, a negative value
					
					//If we have more than one item, empty hands count as one
					if (Inventory.Count() > 0)
					{
						//Check the that the slotid is not less than zero
						if (Inventory.GetActiveSlot() - 1 < -1) return;
						
						//Swap the active child to the new weapon
						ActiveChild = Inventory.GetSlot( Inventory.GetActiveSlot() - 1 );
					}
				}
			}
		}

		public override void OnKilled()
		{
			base.OnKilled();

			EnableDrawing = false;
		}
	}
}
