using UnityEngine;
using System.Collections;
using System.Threading;
using Zenject;

public class PickupSpawner : MonoBehaviour
{

    private PickupFacade.Factory _factory;
    private Vector3 originPosition = new Vector3(0f,0.5f,0f);
    private int _maxAmountOfPickups;
    private float _angle;
    private int _pickupsOnScene = 0;
    private int _cooldown;

    [Inject]
    public void Construct(PickupFacade.Factory factory)
    {
        _factory = factory;
    }

    public void SpawnPickups(int amount)
    {
        _maxAmountOfPickups = amount;
        _angle = 2 * Mathf.PI / _maxAmountOfPickups;

    }

    public void FixedUpdate()
    {
        if (_cooldown-- > 0) return;
        if (_pickupsOnScene < _maxAmountOfPickups)
        {
            SpawnPickup();
        }
    }
    private void SpawnPickup()
    {
        _cooldown = 5;
        var pickup = _factory.Create();
        var theta = _angle * _pickupsOnScene++;
        pickup.Position = originPosition + Vector3.right * Mathf.Cos(theta) * 5 + Vector3.forward * Mathf.Sin(theta) * 5;
    }
}
