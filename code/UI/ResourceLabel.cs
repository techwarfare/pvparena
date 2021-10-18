using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace pvparenas.UI
{
	class ResourceLabel : Panel
	{
		public Label label;
		public ResourceLabel()
		{
			label = Add.Label( "", "" );
		}
		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;
			PvpPlayer playerClass = (PvpPlayer)player;

			label.Text = $"R: {playerClass.Resource}";
		}
	}
}
