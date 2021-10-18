using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvparenas.Classes
{
	//Player Class Base that all classes will inherit
	class BasePlayerClass
	{
		/// <summary>
		/// The name of the class
		/// </summary>
		public string ClassName = "class_base";
		/// <summary>
		/// The prerequestie rank needed before you can become the class
		/// </summary>
		public float PreqRank = 0f;
		/// <summary>
		/// The sort order of where the class will be placed in the list
		/// </summary>
		public int SortOrder = 1;

		/// <summary>
		/// Classes maximum Health
		/// </summary>
		public int MaxHealth = 100;
		/// <summary>
		/// Classes maximum
		/// </summary>
		public int MaxResources = 100;

		public BasePlayerClass()
		{

		}
		public virtual void FirstAbility()
		{

		}
		public virtual void SecondAbility()
		{

		}
		public virtual void ThirdAbility()
		{

		}
		public virtual void UltimateAbility()
		{

		}
		public virtual void JumpAbility(PvpWalkController _controller)
		{
			
		}
	}
}
