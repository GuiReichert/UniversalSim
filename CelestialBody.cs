using UnityEngine;
using UnityEngine.UIElements;

public class CelestialBody : MonoBehaviour
{
    public float mass = 0;
    public float radius = 0;
    public Vector3 velocity = new Vector3(0, 0, 0); 
    public Vector3 acceleration = new Vector3(0,0,0); 
    public bool isStaticBody = false;
    

    void Update()
    {
        UpdatePosition();
        UpdateVelocity();        
    }

    void UpdateVelocity (){
        velocity += acceleration;
    }

    void UpdatePosition (){
        transform.position += new Vector3(velocity.x, 0,velocity.z);
    }
}
