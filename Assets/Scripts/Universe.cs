using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour
{

    FloatBall[] bodies;

    [SerializeField]
    private float gravityConstant = 0.0001f;

    void Awake ()
    {
        bodies = FindObjectsOfType<FloatBall> ();
    }

    void FixedUpdate ()
    {
        // for (int i=0; i<bodies.Length; i++) {
        //     bodies[i].UpdateAcceleration (bodies, gravityConstant);
        // }
        // for (int i=0; i<bodies.Length; i++) {
        //     bodies[i].UpdateVelocity (Time.fixedDeltaTime);
        // }
        // for (int i=0; i<bodies.Length; i++) {
        //     bodies[i].UpdatePosition (Time.fixedDeltaTime);
        for (int i=0; i<bodies.Length; i++) {
            bodies[i].Force (bodies, gravityConstant);
        }

    }
}
