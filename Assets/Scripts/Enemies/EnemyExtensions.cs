using System;
using UnityEngine;

namespace skripts.Enemies {
    public static class EnemyExtensions {
        public static float CalculateDistance(this Transform objectA, Transform objectB) {
            return (float) Math.Sqrt(Math.Pow(objectA.position.x - objectB.position.x, 2) +
                                     Math.Pow(objectA.position.y - objectB.position.y, 2));
        }
    }
}