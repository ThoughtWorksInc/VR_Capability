using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public GameSettings Settings;

	public override void InstallBindings ()
	{
		Container
			.BindFactory<PickupFacade, PickupFacade.Factory> ()
			.FromSubContainerResolve ()
			.ByPrefab (Settings.PickupPrefab)
			.UnderGameObjectGroup ("Pickups");

		Container.BindAllInterfaces<PickupSpawner> ().To<PickupSpawner> ().AsSingle();
    
		Container.BindInstance (Settings.maxPickUps).WhenInjectedInto<PickupSpawner> ();

		Container.BindCommand<LoadGame> ().To<PickupSpawner> (x => x.SpawnPickups).AsSingle().WhenInjectedInto<GameLoader>();

		Container.BindSignal<GameLoaded> ().WhenInjectedInto<PlayerMovementHandler> ();
		Container.BindTrigger<GameLoaded.Trigger> ().WhenInjectedInto<PickupSpawner>();
	}

	[Serializable]
	public class GameSettings
	{
		public GameObject PickupPrefab;
		public int maxPickUps;
	}
}