using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCam : MonoBehaviour {

    public Transform Target;
    public float Distance = 10f;
    public float Height = 8f;
    public float dampTrace = 20.0f;

    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tr.position = Vector3.Lerp(tr.position
            , Target.position
            - (Target.forward * Distance)
            + (Vector3.up * Height)
            , Time.deltaTime * dampTrace);
        tr.LookAt(Target.position);
    }
}
