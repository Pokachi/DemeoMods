using Boardgame;
using Boardgame.BoardEntities;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace DemeoMods.DifficultyMod.Core
{
    public static class DifficultySettings
    {
        private const float ENEMY_HP_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_HP_MULTIPLIER_MAX = 5f;

        public static float EnemyHPMultiplier { get; set; } = 2;

        public static void DecreaseEnemyHPMultiplier(Action<float> callBack)
        {
            if (EnemyHPMultiplier > ENEMY_HP_MULTIPLIER_MIN)
            {
                EnemyHPMultiplier -= 0.25f;
            }

            callBack(EnemyHPMultiplier);
        }

        public static void IncreaseEnemyHPMultiplier(Action<float> callBack)
        {
            if (EnemyHPMultiplier < ENEMY_HP_MULTIPLIER_MAX)
            {
                EnemyHPMultiplier += 0.25f;
            }

            callBack(EnemyHPMultiplier);
        }

        public static int ModifyEnemyHPMultiplier(int defaultHP, PieceConfig pieceConfig)
        {
            if (pieceConfig.HasPieceType(DataKeys.PieceType.Enemy))
            {
                return (int)(defaultHP * EnemyHPMultiplier);
            }

            return defaultHP;
        }

        [HarmonyPatch(typeof(Piece), "CreatePiece")]
        public static class EnemyHPMultiplierPatcher
        {
            private const int numInstructionToWait = 1;
            static MethodInfo m_MyExtraMethod = AccessTools.Method(typeof(DifficultySettings), nameof(ModifyEnemyHPMultiplier), new[] { typeof(int), typeof(PieceConfig) });

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
    }
}