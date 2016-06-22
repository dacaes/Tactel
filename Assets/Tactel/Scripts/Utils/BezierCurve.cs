#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using System.Collections;

namespace Tactel
{
    public sealed class BezierCurve
    {
        private static BezierCurve instance = null;
        public static BezierCurve Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BezierCurve();
                }
                return instance;
            }
        }

        public void Reset()
        {
            instance = null;
        }
        private BezierCurve() { }

        #region functions

        public void QuadraticBezier(Vector2 start, Vector2 end, Vector2 control, float duration, Transform movingObject, bool rotate = false)
        {
            Vector2 handler1;
            Vector2 handler2;
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                handler1 = new Vector2(Mathf.Lerp(start.x, control.x, t), Mathf.Lerp(start.y, control.y, t));
                handler2 = new Vector2(Mathf.Lerp(control.x, end.x, t), Mathf.Lerp(control.y, end.y, t));
                movingObject.position = new Vector2(Mathf.Lerp(handler1.x, handler2.x, t), Mathf.Lerp(handler1.y, handler2.y, t));

                if (rotate)
                    movingObject.eulerAngles = new Vector3(0, 0, Mathf.Atan2(handler2.y - handler1.y, handler2.x - handler1.x) * 180 / Mathf.PI - movingObject.eulerAngles.z);
            }
        }

        public IEnumerator QuadraticBezierAsinc(Vector2 start, Vector2 end, Vector2 control, float duration, Transform movingObject, System.Action<bool> callback, bool rotate = false)
        {
            bool toLeft = end.x < start.x ? true : false;
            float startRotation = movingObject.eulerAngles.z;
            Vector2 handler1;
            Vector2 handler2;
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                handler1 = new Vector2(Mathf.Lerp(start.x, control.x, t), Mathf.Lerp(start.y, control.y, t));
                handler2 = new Vector2(Mathf.Lerp(control.x, end.x, t), Mathf.Lerp(control.y, end.y, t));
                movingObject.position = new Vector2(Mathf.Lerp(handler1.x, handler2.x, t), Mathf.Lerp(handler1.y, handler2.y, t));

                if (rotate)
                {
                    float currentAngle = Mathf.Atan2(handler2.y - handler1.y, handler2.x - handler1.x) * 180 / Mathf.PI;

                    if (toLeft)
                    {
                        currentAngle -= 180;
                    }

                    movingObject.eulerAngles = new Vector3(0, 0, startRotation + currentAngle);
                }

                yield return null;
            }

            callback(true);
        }

        public IEnumerator QuadraticBezierAsinc(Vector2 start, Vector2 end, Vector2 control, float duration, Transform movingObject, bool rotate = false)
        {
            Vector2 handler1;
            Vector2 handler2;
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                handler1 = new Vector2(Mathf.Lerp(start.x, control.x, t), Mathf.Lerp(start.y, control.y, t));
                handler2 = new Vector2(Mathf.Lerp(control.x, end.x, t), Mathf.Lerp(control.y, end.y, t));
                movingObject.position = new Vector2(Mathf.Lerp(handler1.x, handler2.x, t), Mathf.Lerp(handler1.y, handler2.y, t));

                if (rotate)
                    movingObject.eulerAngles = new Vector3(0, 0, Mathf.Atan2(handler2.y - handler1.y, handler2.x - handler1.x) * 180 / Mathf.PI - movingObject.eulerAngles.z);

                yield return null;
            }
        }

        #endregion
    }
}