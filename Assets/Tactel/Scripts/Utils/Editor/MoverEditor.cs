#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

//Based on http://answers.unity3d.com/questions/417837/change-inspector-variables-depending-on-enum.html
using UnityEngine;
using UnityEditor;
using Tactel;

[CustomEditor(typeof(Mover)), CanEditMultipleObjects]
public class MoverEditor : Editor
{
	public SerializedProperty
		ease,
		curve,
		start,
		end,
		duration,
		play;

	void OnEnable()
	{
		// Setup the SerializedProperties
		ease = serializedObject.FindProperty("ease");
		curve = serializedObject.FindProperty("curve");
		start = serializedObject.FindProperty("start");
		end = serializedObject.FindProperty("end");
		duration = serializedObject.FindProperty("duration");
		play = serializedObject.FindProperty("play");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(play);
		EditorGUILayout.PropertyField(ease);

		//Movement.EaseType ease1 = (Movement.EaseType)ease.intValue;

		switch ((Movement.EaseType)ease.intValue)
		{
			case Movement.EaseType.Custom:
				EditorGUILayout.PropertyField(curve, new GUIContent("Curve"));
				
				break;
		}

		EditorGUILayout.PropertyField(start);
		EditorGUILayout.PropertyField(end);
		EditorGUILayout.PropertyField(duration);

		serializedObject.ApplyModifiedProperties();
	}
}
