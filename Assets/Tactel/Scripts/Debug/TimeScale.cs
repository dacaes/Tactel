using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [SerializeField]
    private float scale = 0.3f;
    [SerializeField]
    private bool realTimeChange = false;

    void Awake ()
    {
        Time.timeScale = scale;
	}

    void Update()
    {
        if(realTimeChange)
            Time.timeScale = scale;
    }
}
