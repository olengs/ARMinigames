using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JC_COMMON_FUNCS
{
    public class JCCommonFuncs
    {
        public static Quaternion getshortestArc(Vector3 from, Vector3 to)
        {
            Vector3 temp = Vector3.Cross(from, to);
            float w = Mathf.Sqrt(from.sqrMagnitude * to.sqrMagnitude) + Vector3.Dot(from, to);
            return new Quaternion(temp.x, temp.y, temp.z, w);
        }

        public static Quaternion getshortestArc(Quaternion from, Quaternion to)
        {
            return from * Quaternion.Inverse(to);
        }

        public static bool randomBool()
        { 
            if (Random.Range(0f,1f) > 0.5f)
            {
                return true;
            }
            return false;
        }

        //ratio 0 to 1 (percentage) for true
        public static bool randomBool(float trueratio)
        {
            if (Random.Range(0f, 1f) > trueratio)
            {
                return true;
            }
            return false;
        }
    }


}