using System;
using UnityEngine;
using System.Collections;
using Zenject;

public class PlayerMovementHandler : IFixedTickable
{

    private bool isEnabled;
    private PlayerModel _player;
    public float Speed { get; set; }

    public PlayerMovementHandler(PlayerModel player, float speed)
    {
        isEnabled = false;
        Speed = speed;
        _player = player;
    }

    public void FixedTick()
    {
        if (!isEnabled) return;
       float moveH = Input.GetAxis("Horizontal");
       float moveV = Input.GetAxis("Vertical");
       var movement = new Vector3(moveH, 0.0f, moveV);
       _player.AddForce(movement * Speed);

}

    public void EnableMovement()
    {
        isEnabled = true;
    }
}
