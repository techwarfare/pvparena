using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvparenas
{
	class PvpPlayerInventory : BaseInventory
	{

		public PvpPlayerInventory(Player owner) : base ( owner )
		{
			
		}
		public override bool CanAdd( Entity entity )
		{
			if ( !entity.IsValid() )
				return false;

			if ( !base.CanAdd( entity ) )
				return false;

			return !IsCarryingType( entity.GetType() );
		}

		public override bool Add( Entity entity, bool makeActive = false )
		{
			if ( !entity.IsValid() )
				return false;

			if ( IsCarryingType( entity.GetType() ) )
				return false;
			if (Owner.Inventory.Active != null )
			{
				List.Add( entity );
				return true;
			}
			return base.Add( entity, makeActive );
		}

		public bool IsCarryingType( Type t )
		{
			return List.Any( x => x?.GetType() == t );
		}

		public override bool Drop( Entity ent )
		{
			if ( !Host.IsServer )
				return false;

			if ( !Contains( ent ) )
				return false;

			ent.OnCarryDrop( Owner );

			return ent.Parent == null;
		}
	}
}
