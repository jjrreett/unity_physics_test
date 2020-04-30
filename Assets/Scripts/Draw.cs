// ﻿using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Draw {
//
//     [SerializeField]
//     public GameObject lineGeneratorPrefab;
//
//
//
//     public GameObject Line()
//     {
//         GameObject newLineGen = Instantiate(lineGeneratorPrefab);
//         LineRenderer lr = newLineGen.GetComponent<LineRenderer>();
//
//         lr.positionCount = 2;
//
//         lr.SetPosition(0, new Vector3(0,0,0));
//         lr.SetPosition(1, new Vector3(100,0,0));
//
//
//         return newLineGen;
//     }
//
// }
