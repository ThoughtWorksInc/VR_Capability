using System;
using UnityEngine;
using Zenject;

public sealed class GameLoader : MonoBehaviour
{
	private LoadGame _loadGame;

	[Inject]
	public void Construct (LoadGame loadGame)
	{
		_loadGame = loadGame;
	}

	public void Load(){
		_loadGame.Execute ();
	}
}

