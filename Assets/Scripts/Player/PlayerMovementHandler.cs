using System;
using UnityEngine;
using System.Collections;
using Zenject;

public class PlayerMovementHandler : IFixedTickable {

    private PlayerModel _player;
    public float Speed { get; set; }

    public PlayerMovementHandler(PlayerModel player)
    {
        Speed = 0f;
        _player = player;
    }

    public void FixedTick()
    {
        if (Math.Abs(Speed) <= 0) return;
       float moveH = Input.GetAxis("Horizontal");
       float moveV = Input.GetAxis("Vertical");
       var movement = new Vector3(moveH, 0.0f, moveV);
       _player.AddForce(movement * Speed);

}
}
