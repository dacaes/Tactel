using UnityEngine;
using Tactel;

public class PoolTest : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab1 = null;
    [SerializeField]
    private GameObject prefab2 = null;

    public bool Pop1 = false;
    public bool Pop2 = false;
    public bool Push1 = false;
    public bool Push2 = false;

    private GameObject go1;
    private GameObject go2;

    void Awake()
    {
        ObjectPool.Instance.AddToPool(prefab1, 1);
        ObjectPool.Instance.AddToPool(prefab2, 2);
    }

    void Update()
    {
        if (Pop1)
        {
            Pop1 = false;
            go1 = ObjectPool.Instance.PopFromPool(prefab1);
            go1.transform.position += new Vector3(1,0,0);
        }

        if(Push1)
        {
            Push1 = false;
            ObjectPool.Instance.PushToPool(ref go1);
        }

        if (Pop2)
        {
            Pop2 = false;
            go2 = ObjectPool.Instance.PopFromPool(prefab2);
            go2.transform.position += new Vector3(0, 1, 0);
        }

        if (Push2)
        {
            Push2 = false;
            ObjectPool.Instance.PushToPool(ref go2);
        }
    }
}
