﻿#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tactel.UI
{
	public class UIManager : MonoBehaviour
	{
		[System.Flags]
		public enum UIViews
		{
			Menu = (1 << 0),
			Game = (1 << 1),
			GameOver = (1 << 2),
		}

		[SerializeField]
		private UIViews currentView;
#if UNITY_EDITOR
		public bool changeView;
#endif
		[SerializeField]
		private bool mode;
		public List<UIMovableElement> movableElements = new List<UIMovableElement>();
		public List<UIFadingElement> fadingElements = new List<UIFadingElement>();
		public List<UIToggleableElement> toggleableElements = new List<UIToggleableElement>();
		public List<UIScalableElement> scalableElements = new List<UIScalableElement>();
		private Movement movement;
		private Fading fading;
		private Scaling scaling;

		private bool changing = false;

		void Awake()
		{
			if (!GameObject.Find("TACTEL"))
			{
				GameObject g = new GameObject();
				g.name = "TACTEL";

				movement = g.AddComponent<Movement>();
				fading = g.AddComponent<Fading>();
				scaling = g.AddComponent<Scaling>();
			}

			GameObject UIManagerPositions = GameObject.Find("UIManagerPositions");

			foreach (UIMovableElement element in movableElements)
			{
				element.button = element.transform.GetComponent<Button>();

				if (!element.outTransform || !element.inTransform)
				{
					if (UIManagerPositions)
					{
						foreach (Transform pos in UIManagerPositions.transform)
						{
							if (pos.name.Contains(element.transform.name + "In"))
							{
								element.inTransform = pos;
							}
							else if (pos.name.Contains(element.transform.name + "Out"))
							{
								element.outTransform = pos;
							}
						}
					}
					else
					{
						Debug.LogError(element + " has no position/s for its movement.");
					}
				}

				if (element.duration == 0)
				{
					element.duration = 1;
				}

				element.outPosition = element.outTransform.position;
				element.inPosition = element.inTransform.position;


				element.transform.position = element.outPosition;
				element.onView = false;
			}

			for (int i = 0; i < fadingElements.Count; i++)
			{
				foreach (Transform child in fadingElements[i].transform)
				{
					UIFadingElement ele = new UIFadingElement();
					ele.transform = child;
					ele.views = fadingElements[i].views;
					ele.easeType = fadingElements[i].easeType;
					ele.duration = fadingElements[i].duration;

					fadingElements.Add(ele);
				}

				fadingElements[i].button = fadingElements[i].transform.GetComponent<Button>();

				Image image = fadingElements[i].transform.GetComponent<Image>();
				if (image)
				{
					fadingElements[i].transform.GetComponent<Image>().color = new Color(image.color.r, image.color.g, image.color.b, 0);
				}
				else
				{
					Text text = fadingElements[i].transform.GetComponent<Text>();
					fadingElements[i].transform.GetComponent<Text>().color = new Color(text.color.r, text.color.g, text.color.b, 0);
				}

				if (fadingElements[i].duration == 0)
				{
					fadingElements[i].duration = 1;
				}

				fadingElements[i].onView = false;
			}

			foreach (UIToggleableElement element in toggleableElements)
			{
				element.button = element.transform.GetComponent<Button>();

				element.transform.gameObject.SetActive(false);
				element.onView = false;
			}

			foreach (UIScalableElement element in scalableElements)
			{
				element.button = element.transform.GetComponent<Button>();

				if (element.duration == 0)
				{
					element.duration = 1;
				}

				element.transform.localScale = new Vector2(0, 0);
				element.onView = false;
			}
		}

		void Start()
		{
			Reset();
		}

		public void Reset()
		{
			ChangeView(UIViews.Menu);
		}

		public void ChangeView(UIViews view)
		{
			Debug.Log("--------------Change view to: " + view);
			if (!changing)
			{
				if (mode)
				{
					Change(view, (bool callback0) =>
					{
						changing = false;
					});
				}
				else
				{
					Change2(view, (bool callback0) =>
					{
						changing = false;
					});
				}
			}
		}

		public void ChangeView(UIViews view, System.Action<bool> callback)
		{
			Debug.Log("--------------Change view to: " + view);
			if (!changing)
			{
				if (mode)
				{
					Change(view, (bool callback0) =>
					{
						if (callback0)
						{
							changing = false;
							callback(true);
						}
					});
				}
				else
				{
					Change2(view, (bool callback0) =>
					{
						if (callback0)
						{
							changing = false;
							callback(true);
						}
					});
				}
			}
		}

		void Change(UIViews view, System.Action<bool> callback0)
		{
			changing = true;
			currentView = view;

			bool leaveMovables = false;
			bool leaveFadeables = false;
			bool leaveScalables = false;
			bool enterMovables = false;
			bool enterFadeables = false;
			bool enterScalables = false;

			LeaveMovables((bool callback) =>
			{
				if (callback)
				{
					leaveMovables = true;
					if (leaveFadeables && leaveScalables)
					{
						leaveMovables = false;  //not double path
						LeaveToggleables();
						EnterMovables((bool callback2) =>
						{
							if (callback2)
							{
								enterMovables = true;
								if (enterFadeables && enterScalables)
								{
									enterMovables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
						EnterFadings((bool callback2) =>
						{
							if (callback2)
							{
								enterFadeables = true;
								if (enterMovables && enterScalables)
								{
									enterFadeables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
						EnterScalables((bool callback2) =>
						{
							if (callback2)
							{
								enterScalables = true;
								if (enterMovables && enterFadeables)
								{
									enterScalables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
					}
				}
			});

			LeaveFadings((bool callback) =>
			{
				if (callback)
				{
					leaveFadeables = true;
					if (leaveMovables && leaveScalables)
					{
						leaveFadeables = false;  //not double path
						LeaveToggleables();
						EnterMovables((bool callback2) =>
						{
							if (callback2)
							{
								enterMovables = true;
								if (enterFadeables && enterScalables)
								{
									enterMovables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
						EnterFadings((bool callback2) =>
						{
							if (callback2)
							{
								enterFadeables = true;
								if (enterMovables && enterScalables)
								{
									enterFadeables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
						EnterScalables((bool callback2) =>
						{
							if (callback2)
							{
								enterScalables = true;
								if (enterMovables && enterFadeables)
								{
									enterScalables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
					}
				}
			});

			LeaveScalables((bool callback) =>
			{
				if (callback)
				{
					leaveScalables = true;
					if (leaveMovables && leaveFadeables)
					{
						leaveScalables = false;  //not double path
						LeaveToggleables();
						EnterMovables((bool callback2) =>
						{
							if (callback2)
							{
								enterMovables = true;
								if (enterFadeables && enterScalables)
								{
									enterMovables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
						EnterFadings((bool callback2) =>
						{
							if (callback2)
							{
								enterFadeables = true;
								if (enterMovables && enterScalables)
								{
									enterFadeables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
						EnterScalables((bool callback2) =>
						{
							if (callback2)
							{
								enterScalables = true;
								if (enterMovables && enterFadeables)
								{
									enterScalables = false;  //not double path
									EnterToggleables();
									callback0(true);
								}
							}
						});
					}
				}
			});
		}

		void Change2(UIViews view, System.Action<bool> callback0)
		{
			changing = true;
			currentView = view;

			bool leaveMovables = false;
			bool leaveFadeables = false;
			bool leaveScalables = false;
			bool enterMovables = false;
			bool enterFadeables = false;
			bool enterScalables = false;

			LeaveMovables((bool callback) =>
			{
				if (callback)
				{
					leaveMovables = true;
					if (leaveFadeables && leaveScalables)
					{
						leaveMovables = false;  //not double path
						EnterMovables((bool callback2) =>
						{
							enterMovables = true;
							if(enterFadeables && enterScalables)
							{
								enterMovables = false;  //not double path
								callback0(true);
							}
                        });
						EnterFadings((bool callback2) =>
						{
							enterFadeables = true;
							if (enterMovables && enterScalables)
							{
								enterFadeables = false;  //not double path
								callback0(true);
							}
						});
						EnterScalables((bool callback2) =>
						{
							enterScalables = true;
							if (enterMovables && enterFadeables)
							{
								enterScalables = false;  //not double path
								callback0(true);
							}
						});
						EnterToggleables();
					}
				}
			});

			LeaveFadings((bool callback) =>
			{
				if (callback)
				{
					leaveFadeables = true;
					if (leaveMovables && leaveScalables)
					{
						leaveFadeables = false;  //not double path
						EnterMovables((bool callback2) =>
						{
							enterMovables = true;
							if (enterFadeables && enterScalables)
							{
								enterMovables = false;  //not double path
								callback0(true);
							}
						});
						EnterFadings((bool callback2) =>
						{
							enterFadeables = true;
							if (enterMovables && enterScalables)
							{
								enterFadeables = false;  //not double path
								callback0(true);
							}
						});
						EnterScalables((bool callback2) =>
						{
							enterScalables = true;
							if (enterMovables && enterFadeables)
							{
								enterScalables = false;  //not double path
								callback0(true);
							}
						});
						EnterToggleables();
					}
				}
			});

			LeaveScalables((bool callback) =>
			{
				if (callback)
				{
					leaveScalables = true;
					if (leaveMovables && leaveFadeables)
					{
						leaveScalables = false;  //not double path
						EnterMovables((bool callback2) =>
						{
							enterMovables = true;
							if (enterFadeables && enterScalables)
							{
								enterMovables = false;  //not double path
								callback0(true);
							}
						});
						EnterFadings((bool callback2) =>
						{
							enterFadeables = true;
							if (enterMovables && enterScalables)
							{
								enterFadeables = false;  //not double path
								callback0(true);
							}
						});
						EnterScalables((bool callback2) =>
						{
							enterScalables = true;
							if (enterMovables && enterFadeables)
							{
								enterScalables = false;  //not double path
								callback0(true);
							}
						});
						EnterToggleables();
					}
				}
			});

			LeaveToggleables();
		}

		bool EnterMovables(System.Action<bool> callback)
		{
			Debug.Log("Enter movables.");
			int i = 0;

			List<UIMovableElement> changingElements = new List<UIMovableElement>();

			foreach (UIMovableElement element in movableElements)
			{
				if ((element.views & currentView) != 0 && !element.onView)    //movable leave
				{
					changingElements.Add(element);
				}
			}

			//No changes
			if (changingElements.Count == 0)
			{
				callback(true);
				return false;
			}

			foreach (UIMovableElement element in changingElements)
			{
				i++;
				element.onView = true;

				if (element.button)
				{
					element.button.interactable = true;
				}
				if (i != changingElements.Count) //last one
				{
					movement.MoveAsinc(element.outPosition, element.inPosition, element.duration, element.transform, element.easeType);
				}
				else
				{
					movement.MoveAsinc(element.outPosition, element.inPosition, element.duration, element.transform, (bool callback2) =>
					{
						if (callback2) //last one
						{
							callback(true);
						}
					}, element.easeType);
				}
			}
			return true;
		}

		bool LeaveMovables(System.Action<bool> callback)
		{
			Debug.Log("Leave movables.");
			int i = 0;

			List<UIMovableElement> changingElements = new List<UIMovableElement>();

			foreach (UIMovableElement element in movableElements)
			{
				if (!((element.views & currentView) != 0) && element.onView)    //movable leave
				{
					changingElements.Add(element);
				}
			}

			//No changes
			if (changingElements.Count == 0)
			{
				callback(true);
				return false;
			}

			foreach (UIMovableElement element in changingElements)
			{
				i++;
				element.onView = false;

				if (element.button)
				{
					element.button.interactable = false;
				}

				if (i != changingElements.Count)
				{
					movement.MoveAsinc(element.inPosition, element.outPosition, element.duration, element.transform, element.easeType);
				}
				else //last one
				{
					movement.MoveAsinc(element.inPosition, element.outPosition, element.duration, element.transform, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}, element.easeType);
				}
			}
			return true;
		}

		bool EnterFadings(System.Action<bool> callback)
		{
			Debug.Log("Enter fadings.");
			int i = 0;

			List<UIFadingElement> changingElements = new List<UIFadingElement>();

			foreach (UIFadingElement element in fadingElements)
			{
				if ((element.views & currentView) != 0 && !element.onView)    //movable leave
				{
					changingElements.Add(element);
				}
			}

			//No changes
			if (changingElements.Count == 0)
			{
				callback(true);
				return false;
			}

			foreach (UIFadingElement element in changingElements)
			{
				i++;
				element.onView = true;

				if (element.button)
				{
					element.button.interactable = true;
				}
				if (i != changingElements.Count) //last one
				{
					fading.FadeAsinc(1, element.duration, element.transform, element.easeType);
				}
				else
				{
					fading.FadeAsinc(1, element.duration, element.transform, (bool callback2) =>
					{
						if (callback2) //last one
						{
							callback(true);
						}
					}, element.easeType);
				}
			}
			return true;
		}

		bool LeaveFadings(System.Action<bool> callback)
		{
			Debug.Log("Leave Fadings.");
			int i = 0;

			List<UIFadingElement> changingElements = new List<UIFadingElement>();

			foreach (UIFadingElement element in fadingElements)
			{
				if (!((element.views & currentView) != 0) && element.onView)    //Fading leave
				{
					changingElements.Add(element);
				}
			}

			//No changes
			if (changingElements.Count == 0)
			{
				callback(true);
				return false;
			}

			foreach (UIFadingElement element in changingElements)
			{
				i++;
				element.onView = false;

				if (element.button)
				{
					element.button.interactable = false;
				}

				Fading.EaseType ease = element.easeType;

				if (element.easeType == Fading.EaseType.Boing)
				{
					ease = Fading.EaseType.Linear;
				}

				if (i != changingElements.Count)
				{
					fading.FadeAsinc(0, element.duration, element.transform, ease);
				}
				else //last one
				{
					fading.FadeAsinc(0, element.duration, element.transform, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}, ease);
				}
			}
			return true;
		}

		void EnterToggleables()
		{
			Debug.Log("Enter toggleables.");
			foreach (UIToggleableElement element in toggleableElements)
			{
				if ((element.views & currentView) != 0 && !element.onView)    //has to enter view
				{
					element.onView = true;
					element.transform.gameObject.SetActive(true);
					if (element.effect)
					{
						scaling.ScaleAsinc(element.transform.localScale * 0.9f, element.transform.localScale, 0.4f, element.transform, Scaling.EaseType.Boing);
					}
				}
			}
		}

		void LeaveToggleables()
		{
			Debug.Log("Leave toggleables.");
			foreach (UIToggleableElement element in toggleableElements)
			{
				if (!((element.views & currentView) != 0) && element.onView)    //toggleable leave
				{
					element.onView = false;
					element.transform.gameObject.SetActive(false);
				}
			}
		}

		bool EnterScalables(System.Action<bool> callback)
		{
			Debug.Log("Enter scalables.");
			int i = 0;

			List<UIScalableElement> changingElements = new List<UIScalableElement>();

			foreach (UIScalableElement element in scalableElements)
			{
				if ((element.views & currentView) != 0 && !element.onView)    //scalable leave
				{
					changingElements.Add(element);
				}
			}

			//No changes
			if (changingElements.Count == 0)
			{
				callback(true);
				return false;
			}

			foreach (UIScalableElement element in changingElements)
			{
				i++;
				element.onView = true;

				if (element.button)
				{
					element.button.interactable = true;
				}
				if (i != changingElements.Count) //last one
				{
					scaling.ScaleAsinc(new Vector2(0, 0), new Vector2(1, 1), element.duration, element.transform, element.easeType);
				}
				else
				{
					scaling.ScaleAsinc(new Vector2(0, 0), new Vector2(1, 1), element.duration, element.transform, (bool callback2) =>
					{
						if (callback2) //last one
						{
							callback(true);
						}
					}, element.easeType);
				}
			}
			return true;
		}

		bool LeaveScalables(System.Action<bool> callback)
		{
			Debug.Log("Leave scalables.");
			int i = 0;

			List<UIScalableElement> changingElements = new List<UIScalableElement>();

			foreach (UIScalableElement element in scalableElements)
			{
				if (!((element.views & currentView) != 0) && element.onView)    //scalable leave
				{
					changingElements.Add(element);
				}
			}

			//No changes
			if (changingElements.Count == 0)
			{
				callback(true);
				return false;
			}

			foreach (UIScalableElement element in changingElements)
			{
				i++;
				element.onView = false;

				if (element.button)
				{
					element.button.interactable = false;
				}

				Scaling.EaseType ease = element.easeType;

				if (element.easeType == Scaling.EaseType.Boing)
				{
					ease = Scaling.EaseType.Linear;
				}

				if (i != changingElements.Count)
				{
					scaling.ScaleAsinc(new Vector2(1, 1), new Vector2(0, 0), element.duration, element.transform, ease);
				}
				else //last one
				{
					scaling.ScaleAsinc(new Vector2(1, 1), new Vector2(0, 0), element.duration, element.transform, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}, ease);
				}
			}
			return true;
		}

		/*
		///Preparing for waitings between actions.
		IEnumerator WaitForSeconds(float seconds, System.Action<bool> callback)
		{
			yield return new WaitForSeconds(seconds);
			callback(true);
		}
		*/

#if UNITY_EDITOR
		void Update()
		{
			if (changeView)
			{
				changeView = false;
				ChangeView(currentView);
			}
		}
#endif
	}
}