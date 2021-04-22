using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SphereController : MonoBehaviour
{
    Rigidbody rb;
    float moveTimer = 0;
    [SerializeField, Tooltip("往復運動を実行する時間")] float roundTripSpan;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 球体を自動で動かす
        // moveTimer += Time.fixedDeltaTime;
        // if (moveTimer < (roundTripSpan / 2))
        // {
        //     rb.AddForce(new Vector3(3.0f, 0.0f, 0.0f));
        // }
        // else if (moveTimer < roundTripSpan)
        // {
        //     rb.AddForce(new Vector3(-3.0f, 0.0f, 0.0f));
        // }
        // else if (roundTripSpan < moveTimer)
        // {
        //     moveTimer = 0;
        // }
    }
}

