﻿using Boardgame;
using Boardgame.BoardEntities;
using Boardgame.BoardgameActions;
using Boardgame.Data;
using Boardgame.Networking;
using Boardgame.SerializableEvents;
using DataKeys;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace DemeoMods.DifficultyMod.Core
{
    static class DifficultyPatcher
    {
        private static GameStateMachine StateMachine { get; set; } 

        public static void SetGameStateMachine()
        {
            StateMachine = GameObject.Find("GameLogic").GetComponent<GameStateMachine>();
        }

        public static int ModifyEnemyHPMultiplier(int defaultHP, PieceConfig pieceConfig)
        {
            // Do not modify the HP if the game is public (i.e. anyone can join without room code)
            if (!IsPrivateGame())
            {
                return defaultHP;
            }

            if (pieceConfig.HasPieceType(DataKeys.PieceType.Enemy))
            {
                return (int)(defaultHP * DifficultySettings.EnemyHPMultiplier);
            }

            return defaultHP;
        }

        public static int ModifyEnemyAttackMultiplier(int defaultAttack, PieceConfig pieceConfig)
        {

            // Do not modify the Attack if the game is public (i.e. anyone can join without room code)
            if (!IsPrivateGame())
            {
                return defaultAttack;
            }

            if (pieceConfig.HasPieceType(DataKeys.PieceType.Enemy))
            {
                return (int)(defaultAttack * DifficultySettings.EnemyAttackMultiplier);
            }

            return defaultAttack;
        }

        private static bool IsPrivateGame()
        {
            CreateGameMode gameMode = (CreateGameMode) typeof(GameStateMachine).GetField("createGameMode", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(StateMachine);
            return gameMode == CreateGameMode.Private;
        }

        [HarmonyPatch(typeof(Piece), "CreatePiece")]
        class EnemyHPMultiplierPatcher
        {
            static MethodInfo m_MyExtraMethod = AccessTools.Method(typeof(DifficultyPatcher), nameof(ModifyEnemyHPMultiplier), new[] { typeof(int), typeof(PieceConfig) });

            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                foreach (CodeInstruction instruction in instructions)
                {
                    if (instruction.opcode == OpCodes.Callvirt)
                    {
                        string strOperand = instruction.operand.ToString();
                        if (strOperand.Contains("get_StartHealth"))
                        {
                            yield return instruction;

                            yield return new CodeInstruction(OpCodes.Ldarg_0);
                            yield return new CodeInstruction(OpCodes.Call, m_MyExtraMethod);

                            continue;
                        }
                    }

                    yield return instruction;
                }
            }
        }

        [HarmonyPatch(typeof(Piece), "CreatePiece")]
        class EnemyAttackMultiplierPatcher
        {
            static MethodInfo m_MyExtraMethod = AccessTools.Method(typeof(DifficultyPatcher), nameof(ModifyEnemyAttackMultiplier), new[] { typeof(int), typeof(PieceConfig) });

            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                foreach (CodeInstruction instruction in instructions)
                {
                    if (instruction.opcode == OpCodes.Callvirt)
                    {
                        string strOperand = instruction.operand.ToString();
                        if (strOperand.Contains("get_AttackDamage"))
                        {
                            yield return instruction;

                            yield return new CodeInstruction(OpCodes.Ldarg_0);
                            yield return new CodeInstruction(OpCodes.Call, m_MyExtraMethod);

                            continue;
                        }
                    }
                    yield return instruction;
                }
            }
        }

        [HarmonyPatch(typeof(CardPowder), "GetPowderScale")]
        class EnergyGainMultiplierPatcher
        {
            static void Postfix(ref float __result)
            {
                if (IsPrivateGame())
                {
                    __result *= DifficultySettings.EnergyGainMultiplier;
                }
            }
        }

        [HarmonyPatch(typeof(SerializableEventPickup), MethodType.Constructor, typeof(int), typeof(IntPoint2D), typeof(bool))]
        class GoldPileGainMultiplierPatcher
        {
            static void Postfix(SerializableEventPickup __instance)
            {
                if (IsPrivateGame())
                {
                    __instance.goldAmount = (int) (__instance.goldAmount * DifficultySettings.GoldPileGainMultiplier);
                }
            }
        }

        [HarmonyPatch(typeof(CardHandController), "GetCardSellValue")]
        class CardSaleMultiplierPatcher
        {
            static void Postfix(ref int __result)
            {
                if (IsPrivateGame())
                {
                    __result = (int) (__result * DifficultySettings.CardSaleMultiplier);
                }
            }
        }
    }
}
