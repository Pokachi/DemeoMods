using DemeoMods.DifficultyMod.Core;
using DemeoMods.DifficultyMod.UI;
using MelonLoader;
using UnityEngine;

namespace DemeoMods.DifficultyMod
{
    public class DifficultyMod : MelonMod
    {
        private const string LOBBY_SCENE_NAME = "LobbySteamVR";

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (LOBBY_SCENE_NAME.Equals(sceneName))
            {
                new GameObject("Difficulty Menu", typeof(DifficultyMenu));
            }
        }
    }
}
