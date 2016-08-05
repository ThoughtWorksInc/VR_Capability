using System;
using UnityEngine;
using System.Collections;
using Zenject;

public class PickupInstaller : MonoInstaller
{
    [SerializeField]
    private PickupSettings _settings;
    public override void InstallBindings()
    {
        Container.Bind<PickupModel>().AsSingle();
        Container.BindInstance(_settings.Rigidbody);
    }

    [Serializable]
    public class PickupSettings
    {
       public Rigidbody Rigidbody;
    }
}
