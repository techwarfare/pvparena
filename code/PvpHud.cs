using Sandbox.UI;
//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace pvparenas
{
	using UI;
	/// <summary>
	/// This is the HUD entity. It creates a RootPanel clientside, which can be accessed
	/// via RootPanel on this entity, or Local.Hud.
	/// </summary>
	public partial class PvpHudEntity : Sandbox.HudEntity<RootPanel>
	{
		public PvpHudEntity()
		{
			if ( !IsClient ) return;
			RootPanel.SetTemplate( "/pvphud.html" );

			RootPanel.AddChild<ClassSelectionForm>();
			RootPanel.AddChild<HealthLabel>();
			RootPanel.AddChild<ResourceLabel>();
		}
	}

}
