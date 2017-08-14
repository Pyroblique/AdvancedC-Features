using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using System;

namespace AbstractClasses
{
    public class Shotgun : Weapon
    {
        public float shootAngle = 45f;
        public float shootRadius = 5f;

        private Vector2 leftDir;
        private Vector2 rightDir;

        public Vector2 GetDir(float angleD)
        {
            
        
            float angleR = angleD * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angleR), Mathf.Sin(angleR));

            return transform.rotation * dir;
        
    }

        public override void Fire()
        {
            // Loop through and spawn
                // Fire each bullet in the range and direction of player
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Shotgun))]
    public class ShotgunEditor : Editor
    {
        void OnSceneGUI()
        {
            Shotgun shotgun = (Shotgun)target;

            Transform transform = shotgun.transform;
            Vector2 pos = transform.position;

            float angle = shotgun.shootAngle;
            float radius = shotgun.shootRadius;

            Vector2 leftDir = shotgun.GetDir(angle);
            Vector2 rightDir = shotgun.GetDir(-angle);


            Handles.color = Color.magenta;
            Handles.DrawLine(pos, pos + leftDir * shotgun.shootRadius);
            Handles.DrawLine(pos, pos + rightDir * shotgun.shootRadius);

            Handles.color = Color.blue;
            Handles.DrawWireArc(pos, Vector3.forward, rightDir, angle * 2, radius);
        }
    }
#endif
}