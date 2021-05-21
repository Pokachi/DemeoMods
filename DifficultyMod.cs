using Boardgame;
using Boardgame.BoardEntities;
using Data.GameData;
using DataKeys;
using DemeoMods.UI;
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DemeoMods
{
    public class DifficultyMod : MelonMod
    {
        private const string LOBBY_SCENE_NAME = "LobbySteamVR"; 

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (LOBBY_SCENE_NAME.Equals(sceneName))
            {
                //new GameObject("Difficulty Menu", typeof(RectTransform), typeof(DifficultyMenu));
            }
        }

        [HarmonyPatch(typeof(Boardgame.BoardEntities.Piece), "CreatePiece")]
        public class CreatePieceWithHigherHp
        {
			private static List<string> piecesSeen = new List<string>();

            static void Prefix(ref PieceConfig config)
            {
				if (!piecesSeen.Contains(config.PieceName) && !Array.Exists<PieceType>(config.PieceType, pieceType => pieceType == PieceType.Player))
				{
					PieceConfigDTO dto = new PieceConfigDTO();
					dto.PieceName = config.PieceName;
					dto.PieceNameLocalizationKey = config.PieceNameLocalizedKey;
					dto.LoreLocalizationKey = config.LoreLocalizedKey;
					dto.StartHealth = config.StartHealth * 2;
					dto.StartArmor = config.StartArmor;
					dto.AliveForRounds = config.AliveForRounds;
					dto.VisionRange = config.VisionRange;
					dto.ActionPoint = config.ActionPoint;
					dto.MoveRange = config.MoveRange;
					dto.AttackDamage = config.AttackDamage;
					dto.PowerIndex = config.PowerIndex;
					dto.CanOpenDoor = config.CanOpenDoor;
					dto.AcidSlimeTrailChance = config.AcidSlimeTrailChance;
					dto.ChanceOfDeathPanic = config.ChanceOfDeathPanic;
					dto.ChanceOfFirePanic = config.ChanceOfFirePanic;
					dto.EliteChance = config.EliteChance;
					dto.CriticalHitChance = config.CriticalHitChance;
					dto.CriticalHitDamage = config.CriticalHitDamage;
					dto.MinHealthPotions = config.MinHealthPotions;
					dto.MaxHealthPotions = config.MaxHealthPotions;
					dto.PieceType = config.PieceType;
					dto.UseWhenCreated = config.UseWhenCreated.ToArray();
					dto.Abilities = config.Abilities.ToArray();
					dto.UseWhenKilled = config.UseWhenKilled.ToArray();
					dto.Behaviours = config.Behaviours;
					dto.ImmuneToStatusEffects = config.ImmuneToStatusEffects;
					config.SetData(dto);

					piecesSeen.Add(config.PieceName);
				}
            }
        }
    }
}
