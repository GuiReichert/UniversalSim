using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class GravitySimulator : MonoBehaviour
{
    public List<CelestialBody> bodies;
    public float G = 0.5f;
    void Update()
    {
        UpdateBodies();
    }

    void UpdateBodies(){
        foreach(var body in bodies){
            if (body.isStaticBody) continue;
            Vector3 totalacceleration = Vector3.zero;

            foreach(var differentbody in bodies){
                if (differentbody == body) continue;

                Vector3 direction = differentbody.transform.position - body.transform.position;
                float distance = direction.magnitude;

                if (distance == 0f) continue;
                float accelerationMagnitude = CalculateAcceleration(differentbody.mass, distance);
                Vector3 acceleration = accelerationMagnitude * direction.normalized;

                totalacceleration += acceleration;  
            }

            body.acceleration = totalacceleration*0.001f;
        }
    }


    private float CalculateAcceleration(float diffBodyMass, float distance){
        return G*diffBodyMass/Mathf.Pow(distance,2);

    }
}
