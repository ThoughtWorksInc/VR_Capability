using UnityEngine;
using System.Collections;
using Zenject;

public class PlayerFacade : MonoBehaviour {
    private PlayerModel _player;

    [Inject]
    public void Construct(PlayerModel player)
    {
        _player = player;
    }
}
