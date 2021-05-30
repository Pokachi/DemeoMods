using System;

namespace DemeoMods.DifficultyMod.Core
{
    public static class DifficultySettings
    {
        private const float ENEMY_HP_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_HP_MULTIPLIER_MAX = 5f;
        private const float ENEMY_ATTACK_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_ATTACK_MULTIPLIER_MAX = 5f;

        public static float EnemyHPMultiplier { get; set; } = 2;
        public static float EnemyAttackMultiplier { get; set; } = 2;

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

        public static void DecreaseEnemyAttackMultiplier(Action<float> callBack)
        {
            if (EnemyAttackMultiplier > ENEMY_ATTACK_MULTIPLIER_MIN)
            {
                EnemyAttackMultiplier -= 0.25f;
            }

            callBack(EnemyAttackMultiplier);
        }

        public static void IncreaseEnemyAttackMultiplier(Action<float> callBack)
        {
            if (EnemyAttackMultiplier < ENEMY_ATTACK_MULTIPLIER_MAX)
            {
                EnemyAttackMultiplier += 0.25f;
            }

            callBack(EnemyAttackMultiplier);
        }
    }
}