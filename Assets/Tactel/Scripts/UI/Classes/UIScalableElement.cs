#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using UnityEngine.UI;
using Tactel.Extensions;

namespace Tactel.UI
{
    [System.Serializable]
    public class UIScalableElement
    {
        public Transform transform;
        [EnumFlags]
        public UIManager.UIViews views;
        public Scaling.EaseType easeType;
        public float duration;
        public Button button { get; set; }
        public bool onView { get; set; }
    }
}
