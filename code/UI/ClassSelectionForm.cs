using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections.Generic;

namespace pvparenas.UI
{
	class ClassSelectionForm : Form
	{
		Label MainTextLabel;

		List<FormRow> Rows = new List<FormRow>();
		public ClassSelectionForm()
		{
			FormRow TestRow = new FormRow( "Row Name", "image.png", "rowImage" );
			MainTextLabel = Add.Label( "Welcome to PvP Arenas!\nPlease choose a class from below.", "MainText" );
			Rows.Add( TestRow );
			AddChild( TestRow );
		}
	}
}
