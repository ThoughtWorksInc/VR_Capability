using UnityEngine;
using System.Collections;
using Zenject;

public class PickupSpawner : MonoBehaviour
{

    private PickupFacade.Factory _factory;
    private Vector3 originPosition = new Vector3(0f,0.5f,0f);

    [Inject]
    public void Construct(PickupFacade.Factory factory)
    {
        _factory = factory;
    }

    public void SpawnPickups(int numberOfPickups)
    {
        var angle = 2*Mathf.PI/numberOfPickups;
        for (var i = numberOfPickups; i > 0; i--)
        {
            var pickup = _factory.Create();
            var theta = angle * i;
            pickup.Position = originPosition +  Vector3.right * Mathf.Cos(theta) * 5 + Vector3.forward * Mathf.Sin(theta) * 5;
        }
    }
}
