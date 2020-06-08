using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReplicator : MonoBehaviour
{
    public GameObject prefab;
    public Vector3Int dup = new Vector3Int(10, 10, 10);
    public Vector3 delta = new Vector3(1.2f, 1.2f, 1.2f);

    void Start()
    {
        Vector3 position = transform.position;
        for (int ix = 0; ix < dup.x; ix++)
        {
            for (int iy = 0; iy < dup.y; iy++)
            {
                for (int iz = 0; iz < dup.z; iz++)
                {
                    position.x = transform.position.x + ix * delta.x;
                    position.y = transform.position.y + iy * delta.y;
                    position.z = transform.position.z + iz * delta.z;
                    GameObject go = Instantiate(prefab, transform);
                    go.transform.position = position;
                }
            }
        }
    }
}
