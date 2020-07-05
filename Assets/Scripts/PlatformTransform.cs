using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTransform : MonoBehaviour
{
    Vector3 oldPosition;
    Vector3 newPosition;
    Vector3 moveValue;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = this.gameObject.transform.position;
        newPosition = new Vector3(oldPosition.x + 50, oldPosition.y, oldPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x >= newPosition.x)
        {
            Debug.Log("done");
        }
        else
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + Speed, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

    }
}
