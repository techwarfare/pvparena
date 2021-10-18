using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace pvparenas.UI
{
	/// <summary>
	/// A row for each item within the ClassSelectionForm
	/// </summary>
	class FormRow : Form
	{
		Label RowMainLabel;
		Image RowMainImage;
		public FormRow(string _rowName, string _rowImage, string _rowImageName )
		{
			RowMainLabel = Add.Label( _rowName, _rowName );
			RowMainImage = Add.Image( _rowImage, _rowImageName );
		}
	}
}
