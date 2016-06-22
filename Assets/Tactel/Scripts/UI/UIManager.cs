#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

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

                if(!element.outTransform || !element.inTransform)
                {
                    if(UIManagerPositions)
                    {
                        foreach(Transform pos in UIManagerPositions.transform)
                        {
                            if(pos.name.Contains(element.transform.name + "In"))
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

                if(element.duration == 0)
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

        void Reset()
        {
            ChangeView(UIViews.Menu);
        }

        public void ChangeView(UIViews view)
        {
            if(!changing)
            {
                Change(view);
            }
        }

        void Change(UIViews view)
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
                                }
                            }
                        });
                    }
                }
            });
            changing = false;
        }

        void EnterMovables(System.Action<bool> callback)
        {
            int i = 0;
            bool noElementToChange = true;

            foreach (UIMovableElement element in movableElements)
            {
                i++;
                if ((element.views & currentView) != 0 && !element.onView)    //has to enter view
                {
                    noElementToChange = false;
                    element.onView = true;
                    if (element.button)
                    {
                        element.button.interactable = true;
                    }
                    movement.MoveAsinc(element.outPosition, element.inPosition, element.duration, element.transform, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            if (i == movableElements.Count) //last one
                        {
                                callback(true);
                            }
                        }
                    }, element.easeType);
                }
                else if (i == movableElements.Count)
                {
                    callback(true);
                }
            }
            if (noElementToChange)
            {
                callback(true);
            }
        }

        void LeaveMovables(System.Action<bool> callback)
        {
            int i = 0;
            bool noElementToChange = true;
            foreach (UIMovableElement element in movableElements)
            {
                i++;
                if (!((element.views & currentView) != 0) && element.onView)    //movable leave
                {
                    noElementToChange = false;
                    element.onView = false;
                    if (element.button)
                    {
                        element.button.interactable = false;
                    }
                    if (i != movableElements.Count)
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
                else if(i == movableElements.Count)
                {
                    callback(true);
                }
            }

            if (noElementToChange)
            {
                callback(true);
            }
        }

        void EnterFadings(System.Action<bool> callback)
        {
            int i = 0;
            bool noElementToChange = true;
            foreach (UIFadingElement element in fadingElements)
            {
                i++;
                if ((element.views & currentView) != 0 && !element.onView)    //has to enter view
                {
                    noElementToChange = false;
                    element.onView = true;
                    if (element.button)
                    {
                        element.button.interactable = true;
                    }
                    fading.FadeAsinc(1, element.duration, element.transform, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            if (i != fadingElements.Count)
                            {
                                callback(true);
                            }
                        }
                    }, element.easeType);
                }
                else if (i == movableElements.Count)
                {
                    callback(true);
                }
            }

            if (noElementToChange)
            {
                callback(true);
            }
        }

        void LeaveFadings(System.Action<bool> callback)
        {
            int i = 0;
            bool noElementToChange = true;
            foreach (UIFadingElement element in fadingElements)
            {
                i++;
                if (!((element.views & currentView) != 0) && element.onView)    //fading leave
                {
                    noElementToChange = false;
                    element.onView = false;
                    if (element.button)
                    {
                        element.button.interactable = false;
                    }
                    if (i != fadingElements.Count)
                    {
                        fading.FadeAsinc(0, element.duration, element.transform, element.easeType);
                    }
                    else //last one
                    {
                        fading.FadeAsinc(0, element.duration, element.transform, (bool callback2) =>
                        {
                            if (callback2)
                            {
                                callback(true);
                            }
                        }, element.easeType);
                    }
                }
                else if (i == movableElements.Count)
                {
                    callback(true);
                }
            }

            if (noElementToChange)
            {
                callback(true);
            }
        }

        void EnterToggleables()
        {
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
            foreach (UIToggleableElement element in toggleableElements)
            {
                if (!((element.views & currentView) != 0) && element.onView)    //toggleable leave
                {
                    element.onView = false;
                    element.transform.gameObject.SetActive(false);
                }
            }
        }

        void EnterScalables(System.Action<bool> callback)
        {
            int i = 0;
            bool noElementToChange = true;

            foreach (UIScalableElement element in scalableElements)
            {
                i++;
                if ((element.views & currentView) != 0 && !element.onView)    //has to enter view
                {
                    noElementToChange = false;
                    element.onView = true;
                    if (element.button)
                    {
                        element.button.interactable = true;
                    }
                    scaling.ScaleAsinc(new Vector2(0,0), new Vector2(1,1), element.duration, element.transform, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            if (i == scalableElements.Count) //last one
                            {
                                callback(true);
                            }
                        }
                    }, element.easeType);
                }
                else if (i == movableElements.Count)
                {
                    callback(true);
                }
            }
            if (noElementToChange)
            {
                callback(true);
            }
        }

        void LeaveScalables(System.Action<bool> callback)
        {
            int i = 0;
            bool noElementToChange = true;
            foreach (UIScalableElement element in scalableElements)
            {
                i++;
                if (!((element.views & currentView) != 0) && element.onView)    //scalable leave
                {
                    noElementToChange = false;
                    element.onView = false;
                    if (element.button)
                    {
                        element.button.interactable = false;
                    }
                    if (i != scalableElements.Count)
                    {
                        scaling.ScaleAsinc(new Vector2(1,1), new Vector2(0,0), element.duration, element.transform, Scaling.EaseType.Linear);
                    }
                    else //last one
                    {
                        scaling.ScaleAsinc(new Vector2(1,1), new Vector2(0,0), element.duration, element.transform, (bool callback2) =>
                        {
                            if (callback2)
                            {
                                callback(true);
                            }
                        }, Scaling.EaseType.Linear);
                    }
                }
                else if (i == movableElements.Count)
                {
                    callback(true);
                }
            }

            if (noElementToChange)
            {
                callback(true);
            }
        }

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