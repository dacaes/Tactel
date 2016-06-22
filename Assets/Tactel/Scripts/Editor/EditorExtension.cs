#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using UnityEditor;


public class EditorExtension : Editor
{
	static Quaternion lastRotation = Quaternion.identity;
	static Vector3 origPosition = Vector3.zero;

	[MenuItem ("EditorExtensions/yaw +90 &z")]
	static void MenuRotate90Yaw()
	{
		Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);

		if (transforms.Length == 1)
		{
			transforms [0].eulerAngles += new Vector3 (0, 90, 0);
		}
		else if (transforms.Length != 0)
		{
			Vector3 centroid = Vector3.zero;
			foreach (Transform transform in transforms)
			{
				centroid += transform.position;
			}

			centroid /= transforms.Length;

			foreach (Transform transform in transforms)
			{
				transform.RotateAround (centroid, Vector3.up, 90);
			}
		}
	}

	[MenuItem ("EditorExtensions/scale -z &x")]
	static void MenuScaleInvertZ()
	{
		Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);
		foreach(Transform transform in transforms)
		{
			transform.localScale = new Vector3 (1, 1, -transform.localScale.z);
		}
	}

    /*
	[MenuItem ("EditorExtensions/scene top &c")]
	static void MenuSceneCameraTop()
	{
		Quaternion rotation = Quaternion.identity;
		rotation.eulerAngles = new Vector3 (90, 0, 0);

		Quaternion last = SceneView.lastActiveSceneView.rotation;
		//Si ya está en 90 grados
		if (SceneView.lastActiveSceneView.rotation == rotation)
		{
			SceneView.lastActiveSceneView.rotation = lastRotation;
		}
		else
		{
			SceneView.lastActiveSceneView.rotation = rotation;
		}

		lastRotation = last;
	}
    */
}