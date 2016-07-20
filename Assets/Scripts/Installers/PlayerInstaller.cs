using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
	[SerializeField]
	private PlayerSettings _settings;


	public override void InstallBindings ()
	{
		Container.Bind<PlayerModel> ().AsSingle ();
		Container.BindAllInterfacesAndSelf<PlayerMovementHandler> ().To<PlayerMovementHandler> ().AsSingle ();
		Container.BindInstance (_settings.Rigidbody);
		Container.BindInstance (_settings.Speed);
	}

	[Serializable]
	public class PlayerSettings
	{
		public float Speed;
		public Rigidbody Rigidbody;
	}
}