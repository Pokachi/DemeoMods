using MelonLoader;
using System;

namespace DemeoMods.DifficultyMod.Core
{
    public static class DifficultySettings
    {
        private const string MELON_PREF_NAME = "DemeoDifficultyMod";
        private const string MELON_PREF_ENEMY_HP_MULTIPLIER_NAME = "EnemyHpMultiplier";
        private const string MELON_PREF_ENEMY_ATTACK_MULTIPLIER_NAME = "EnemyAttackMultiplier";
        private const string MELON_PREF_ENERGY_GAIN_MULTIPLIER_NAME = "EnergyGainMultiplier";
        private const string MELON_PREF_GOLD_PILE_GAIN_MULTIPLIER_NAME = "GoldGainMultiplier";

        private const float ENEMY_HP_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_HP_MULTIPLIER_MAX = 5f;
        private const float ENEMY_ATTACK_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_ATTACK_MULTIPLIER_MAX = 5f;
        private const float ENERGY_GAIN_MULTIPLIER_MIN = 0.1f;
        private const float ENERGY_GAIN_MULTIPLIER_MAX = 5f;
        private const float GOLD_PILE_GAIN_MULTIPLIER_MIN = 0.1f;
        private const float GOLD_PILE_GAIN_MULTIPLIER_MAX = 5f;

        public static void RegisterSettings()
        {
            MelonPreferences.CreateCategory(MELON_PREF_NAME, "Demeo Difficulty Settings");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENEMY_HP_MULTIPLIER_NAME, 1f, "Enemy HP Multiplier");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENEMY_ATTACK_MULTIPLIER_NAME, 1f, "Enemy Attack Multiplier");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENERGY_GAIN_MULTIPLIER_NAME, 1f, "Energy Gain Multiplier");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_GOLD_PILE_GAIN_MULTIPLIER_NAME, 1f, "Gold Pile Gain Multiplier");
        }

        public static float EnemyHPMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_ENEMY_HP_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_ENEMY_HP_MULTIPLIER_NAME, value);
            }
        }

        public static float EnemyAttackMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_ENEMY_ATTACK_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_ENEMY_ATTACK_MULTIPLIER_NAME, value);
            }
        }

        public static float EnergyGainMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_ENERGY_GAIN_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_ENERGY_GAIN_MULTIPLIER_NAME, value);
            }

        }

        public static float GoldPileGainMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_GOLD_PILE_GAIN_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_GOLD_PILE_GAIN_MULTIPLIER_NAME, value);
            }

        }

        public static void DecreaseEnemyHPMultiplier(Action<float> callBack)
        {
            if (EnemyHPMultiplier > ENEMY_HP_MULTIPLIER_MIN)
            {
                EnemyHPMultiplier = (float) Math.Round(EnemyHPMultiplier - 0.25f, 2);
            }

            callBack(EnemyHPMultiplier);
        }

        public static void IncreaseEnemyHPMultiplier(Action<float> callBack)
        {
            if (EnemyHPMultiplier < ENEMY_HP_MULTIPLIER_MAX)
            {
                EnemyHPMultiplier = (float)Math.Round(EnemyHPMultiplier + 0.25f, 2);
            }

            callBack(EnemyHPMultiplier);
        }

        public static void DecreaseEnemyAttackMultiplier(Action<float> callBack)
        {
            if (EnemyAttackMultiplier > ENEMY_ATTACK_MULTIPLIER_MIN)
            {
                EnemyAttackMultiplier = (float)Math.Round(EnemyAttackMultiplier - 0.25f, 2);
            }

            callBack(EnemyAttackMultiplier);
        }

        public static void IncreaseEnemyAttackMultiplier(Action<float> callBack)
        {
            if (EnemyAttackMultiplier < ENEMY_ATTACK_MULTIPLIER_MAX)
            {
                EnemyAttackMultiplier = (float)Math.Round(EnemyAttackMultiplier + 0.25f, 2);
            }

            callBack(EnemyAttackMultiplier);
        }

        public static void DecreaseEnergyGainMultiplier(Action<float> callBack)
        {
            if (EnergyGainMultiplier > ENERGY_GAIN_MULTIPLIER_MIN)
            {
                EnergyGainMultiplier = (float)Math.Round(EnergyGainMultiplier - 0.1f, 2);
            }

            callBack(EnergyGainMultiplier);
        }

        public static void IncreaseEnergyGainMultiplier(Action<float> callBack)
        {
            if (EnergyGainMultiplier < ENERGY_GAIN_MULTIPLIER_MAX)
            {
                EnergyGainMultiplier = (float)Math.Round(EnergyGainMultiplier + 0.1f, 2);
            }

            callBack(EnergyGainMultiplier);
        }

        public static void DecreaseGoldPileGainMultiplier(Action<float> callBack)
        {
            if (GoldPileGainMultiplier > GOLD_PILE_GAIN_MULTIPLIER_MIN)
            {
                GoldPileGainMultiplier = (float)Math.Round(GoldPileGainMultiplier - 0.1f, 2);
            }

            callBack(EnergyGainMultiplier);
        }

        public static void IncreaseGoldPileGainMultiplier(Action<float> callBack)
        {
            if (GoldPileGainMultiplier < GOLD_PILE_GAIN_MULTIPLIER_MAX)
            {
                GoldPileGainMultiplier = (float)Math.Round(GoldPileGainMultiplier + 0.1f, 2);
            }

            callBack(GoldPileGainMultiplier);
        }
    }
}