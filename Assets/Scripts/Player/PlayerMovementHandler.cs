using System;
using UnityEngine;
using System.Collections;
using Zenject;

public class PlayerMovementHandler : IFixedTickable, IInitializable, IDisposable
{

	private bool isEnabled;
	private PlayerModel _player;

	public float Speed { get; set; }

	private readonly GameLoaded _loadedSignal;

	public PlayerMovementHandler (PlayerModel player, float speed, GameLoaded loadedSignal)
	{
		isEnabled = false;
		Speed = speed;
		_player = player;
		_loadedSignal = loadedSignal;
	}

	public void FixedTick ()
	{
		if (!isEnabled)
			return;
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		var movement = new Vector3 (moveH, 0.0f, moveV);
		_player.AddForce (movement * Speed);

	}

	public void EnableMovement ()
	{
		isEnabled = true;
	}

	public void Initialize ()
	{
		_loadedSignal.Event += OnGameLoaded;
	}

	public void Dispose ()
	{
		_loadedSignal.Event -= OnGameLoaded;

	}

	private void OnGameLoaded ()
	{
		isEnabled = true;
	}
}
