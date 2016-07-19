using UnityEngine;
using System.Collections;

public class PlayerModel {
    
    private readonly Rigidbody _rigidbody;

    public PlayerModel(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void AddForce(Vector3 vector3)
    {
        _rigidbody.AddForce(vector3);
    }
}
