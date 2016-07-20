using UnityEngine;
using System.Collections;
using System.Threading;
using Zenject;

public sealed class PickupSpawner : IFixedTickable
{
	private PickupFacade.Factory _factory;
	private Vector3 originPosition = new Vector3 (0f, 0.5f, 0f);
	private int _maxAmountOfPickups;
	private float _angle;
	private int _pickupsOnScene = 0;
	private int _cooldown;
	private bool _enableSpawn = false;
	private GameLoaded.Trigger _loadedSignal;

	[Inject]
	public void Construct (PickupFacade.Factory factory, int maxPickups, GameLoaded.Trigger loadedSignal)
	{
		_factory = factory;
		_maxAmountOfPickups = maxPickups;
		_angle = 2 * Mathf.PI / _maxAmountOfPickups;
		_loadedSignal = loadedSignal;
	}

	public void SpawnPickups ()
	{
		_enableSpawn = true;
	}

	public void FixedTick ()
	{
		TrySpawnPickup ();
	}

	private void TrySpawnPickup ()
	{
		if (ShouldNotSpawnNew())return;

		SpawnPickup ();
		RaiseLoadedEventWhenCompleted ();
	}

	private bool ShouldNotSpawnNew(){
		return _pickupsOnScene >= _maxAmountOfPickups
		|| !_enableSpawn
		|| _cooldown-- > 0;
	}

	private void RaiseLoadedEventWhenCompleted(){
		if (_pickupsOnScene == _maxAmountOfPickups)
			_loadedSignal.Fire ();
	}

	private void SpawnPickup ()
	{
		_cooldown = 5;
		var pickup = _factory.Create ();
		var theta = _angle * _pickupsOnScene++;
		pickup.Position = originPosition + Vector3.right * Mathf.Cos (theta) * 5 + Vector3.forward * Mathf.Sin (theta) * 5;
	}
}
