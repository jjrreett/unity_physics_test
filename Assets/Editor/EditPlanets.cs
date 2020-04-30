using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FloatBall))]
public class EditPlanets : Editor {

    public override void OnInspectorGUI() {
        FloatBall planet = (FloatBall)target;

        if (DrawDefaultInspector()){
            planet.Init();

        }

        if( GUILayout.Button("Update")){
            planet.Init();
        }
    }
}
