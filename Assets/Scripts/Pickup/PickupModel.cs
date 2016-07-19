using UnityEngine;
using System.Collections;

public class PickupModel
{

    public Vector3 Position {
        get { return _rigidbody.transform.position;  }
        set { _rigidbody.transform.position = value;  }
    }
    private Rigidbody _rigidbody;

    public PickupModel(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }
}
