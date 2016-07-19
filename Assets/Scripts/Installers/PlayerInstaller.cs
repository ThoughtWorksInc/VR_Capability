using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private Rigidbody _rigidbody;

    public override void InstallBindings()
    {
        Container.Bind<PlayerModel>().AsSingle();
        Container.BindAllInterfaces<PlayerMovementHandler>().To<PlayerMovementHandler>().AsSingle();
        Container.BindInstance(_rigidbody);
    }
}