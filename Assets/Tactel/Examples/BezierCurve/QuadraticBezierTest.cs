using UnityEngine;
using System.Collections;

public class QuadraticBezierTest : MonoBehaviour
{
    public Transform start;
    public Transform end;

    public Transform handler1;
    public Transform handler2;
    public Transform control;

    public Transform movingObject;
    public float aTime;
    private float pasedTime = 0;
    bool myReturnValue;
    void Start()
    {
        //StartCoroutine("Move");
        
        StartCoroutine(Move((myReturnValue) => {
            if (myReturnValue)
            {
                Debug.Log("aaa");
            }
        }));
    }

    IEnumerator Move(System.Action<bool> callback)
    {
        bool toLeft = end.position.x < start.position.x ? true : false;
        float startRotation = movingObject.eulerAngles.z;
        Debug.Log("Start curve");
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / aTime)
        {
            handler1.position = new Vector2(Mathf.Lerp(start.position.x, control.position.x, t), Mathf.Lerp(start.position.y, control.position.y, t));
            handler2.position = new Vector2(Mathf.Lerp(control.position.x, end.position.x, t), Mathf.Lerp(control.position.y, end.position.y, t));
            movingObject.position = new Vector2(Mathf.Lerp(handler1.position.x, handler2.position.x, t), Mathf.Lerp(handler1.position.y, handler2.position.y, t));

            float currentAngle = Mathf.Atan2(handler2.position.y - handler1.position.y, handler2.position.x - handler1.position.x) * 180 / Mathf.PI;

            if (toLeft)
            {
                currentAngle -= 180;
            }

            movingObject.eulerAngles = new Vector3(0, 0, startRotation + currentAngle);

            Debug.Log("elapsed time " + pasedTime);
            pasedTime += Time.deltaTime;

            yield return null;
        }
        callback(true);
        Debug.Log("End curve");
    }
}
