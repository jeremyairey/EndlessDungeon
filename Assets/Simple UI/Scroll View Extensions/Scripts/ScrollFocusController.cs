using System.Collections;
using System.Linq;
using SimpleEasing;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimpleUI.ScrollExtensions
{
	using System.Collections.Generic;
	using UnityEngine;
	[AddComponentMenu("Simple UI/ Scroll View Extensions/ Scroll Focus Controller", 1001)]
	public class ScrollFocusController : UIBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler, IScrollHandler
	{
		public ScrollRect scrollRect;
		public EasedScrollRectMover scrollMover;
		public List<ScrollPoint> focusPoints = new List<ScrollPoint>();
		public ScrollPoint first;
		public float scrollTimeOut = 0.5f;
		public bool snap = true;
		[Header("In case inertia is enabled, elements will snap at this threshold")]
		public float minVelocityForSnap = 150f;
		public PointFocusEvent CurrentFocusPoint = new PointFocusEvent();
		private bool scrolling = false;
		private float scrollPauseTime = 0f;
		private UniqueCoroutine inertiaWatchRoutine = new UniqueCoroutine();
		
		[System.Serializable]
		public class PointFocusEvent : BoundProperty<ScrollPoint>{}


		protected override void Start()
		{
			if (first != null)
			{
				StartCoroutine(InitializeAfterIdioticLayoutEnumerator());
			}
		}

		private IEnumerator InitializeAfterIdioticLayoutEnumerator()
		{
			yield return null;
			CurrentFocusPoint.SetValueWithoutCallbacks(first);
			CurrentFocusPoint.Value.Focus();
			scrollMover.scrollController.CenterOn(CurrentFocusPoint.Value.Rect);	
		}

		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			MovementStarted();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			MovementStarted();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			MovementFinished();
		}

		public void OnScroll(PointerEventData eventData)
		{
			OnScrollMove();
		}
		public void OnScrollMove()
		{
			scrolling = true;
			scrollPauseTime = 0f;
			MovementStarted();
		}

		private void Update()
		{
			if (scrolling)
			{
				if (scrollPauseTime > scrollTimeOut)
				{
					scrolling = false;
					MovementFinished();
				}
				else
					scrollPauseTime += Time.deltaTime;
			}
		}
		public void MovementStarted()
		{
			inertiaWatchRoutine.StopCoroutine();
		}

		public void MovementFinished()
		{
			inertiaWatchRoutine.StopCoroutine();
			
			if (snap)
			{
				if (scrollRect.inertia && !VelocityBelowMinimum())
				{
					inertiaWatchRoutine.ReplaceOrStartCoroutine(Scheduler.DoWhen(VelocityBelowMinimum, MovementFinished));
					return;
				}
				MoveTo(FindNearest());
			}
			else
				ChangeFocus(FindNearest());
		}

		bool VelocityBelowMinimum()
		{
			return scrollRect.velocity.magnitude < minVelocityForSnap;
		}

		public ScrollPoint FindNearest()
		{
			if (focusPoints.Count < 1)
				return null;
			Vector2 currentPosition = scrollRect.normalizedPosition;
			
			var nearestFocusPoint = focusPoints.OrderBy(x =>
			{
				return x.AbsoluteDistanceToPosition(currentPosition);
			}).First();
			return nearestFocusPoint;
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			SetPointsDirty();
		}

		public void SetPointsDirty()
		{
			focusPoints.ForEach(point => point.Dirty = true);
		}

		private void ChangeFocus(ScrollPoint point)
		{
			if (CurrentFocusPoint.Value == point)
				return;
			CurrentFocusPoint.Value.Defocus();
			point.Focus();
			CurrentFocusPoint.Value = point;
		}
		public void MoveTo(ScrollPoint point)
		{
			if (CurrentFocusPoint.Value != point)
			{
				if (CurrentFocusPoint.Value != null)
				{
					CurrentFocusPoint.Value.Defocus();
				}
				scrollMover.MoveTo(point.ScrollPosition, point.Focus);
				CurrentFocusPoint.Value = point;
			}
			//otherwise just move back
			else if(point != null)
			{
				scrollMover.MoveTo(point.ScrollPosition);
			}
				
		}
		public void CenterAndFocus(ScrollPoint point)
		{
			if (CurrentFocusPoint.Value != point)
			{
				if (CurrentFocusPoint.Value != null)
				{
					CurrentFocusPoint.Value.Defocus();
				}
				scrollMover.scrollController.CenterOn(point.Rect);
				point.Focus();
				CurrentFocusPoint.Value = point;
			}
			//otherwise just move back
			else if (point != null)
			{
				scrollMover.scrollController.CenterOn(point.Rect);
			}
		}
	}
}
