using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
namespace Utils{ 
    [System.Serializable]
    public struct Point2D {
       Point2D(double x =0.0, double y = 0.0){
        X = x;
        Y = y;

       }
    

    public double Y {get;}
    public double X {get;}
    public override string ToString() => $"({X},{Y})";
    }
    
}