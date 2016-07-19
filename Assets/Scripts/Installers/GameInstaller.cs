using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameSettings Settings;

    public override void InstallBindings()
    {
        Container.BindFactory<PickupFacade, PickupFacade.Factory>().FromSubContainerResolve().ByPrefab(Settings.PickupPrefab).UnderGameObjectGroup("Pickups");
    }

    [Serializable]
    public class GameSettings
    {
        public GameObject PickupPrefab;
    }
}