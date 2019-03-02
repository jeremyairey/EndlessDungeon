using UnityEngine.Events;
using UnityEngine.UI;

namespace SimpleUI
{
	using UnityEngine;
	/// <summary>
	/// Layouted elements report incorrect positions during start and awake phase, this script forces
	/// layout groups to do the necessary calculations on awake
	/// </summary>
	public class ForceLayoutInitialization : MonoBehaviour
	{
		public HorizontalOrVerticalLayoutGroup layoutGroup;
		public ContentSizeFitter contentSizeFitter;


		private void Awake()
		{
			Force();
		}

		private void Start()
		{
			Force();
		}

		public void Force()
		{		
			if (layoutGroup != null && layoutGroup.enabled)
			{
				layoutGroup.CalculateLayoutInputHorizontal();
				layoutGroup.SetLayoutHorizontal();
				layoutGroup.CalculateLayoutInputVertical();
				layoutGroup.SetLayoutVertical();
			}
			if (contentSizeFitter != null && contentSizeFitter.enabled)
			{
				contentSizeFitter.SetLayoutHorizontal();
				contentSizeFitter.SetLayoutVertical();
			}
		}
	}
}