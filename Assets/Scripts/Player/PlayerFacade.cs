using UnityEngine;
using System.Collections;
using Zenject;

public class PlayerFacade : MonoBehaviour {

    private PlayerModel _player;
    private PlayerMovementHandler _movementHandler;

    [Inject]
    public void Construct(PlayerModel player, PlayerMovementHandler movementHandler)
    {
        _player = player;
        _movementHandler = movementHandler;
    }

    public void EnableMovement()
    {
        _movementHandler.EnableMovement();
    }
}
