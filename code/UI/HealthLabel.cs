using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace pvparenas.UI
{
	class HealthLabel : Panel
	{
		Label label;
		public HealthLabel()
		{
			label = Add.Label( "", "" );
		}
		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player == null ) return;
			label.Text = $"H: {player.Health}";
		}
	}
}
