
using UnityEngine;

public class PointInTime 
{
    public Vector3 position;
    //public Quaternion rotation;
    public Vector3 velocity;
    public Vector3 AngularVelocity;
    public int id;

    public PointInTime(Vector3 _position,  Vector3 _velocity, Vector3 _AngularVelocity, int _id)
    {
        position = _position;
        velocity = _velocity;
        AngularVelocity = _AngularVelocity;
        id = _id;
    }
}
