using UnityEngine;
using System.Collections;
using Zenject;

public class PickupFacade : MonoBehaviour {

    private PickupModel _pickup;

    public Vector3 Position
    {
        get { return _pickup.Position; }
        set { _pickup.Position = value; }
    }

    [Inject]
    public void Construct(PickupModel pickup)
    {
        _pickup = pickup;
    }

    public class Factory : Factory<PickupFacade>
    {

    }
}
