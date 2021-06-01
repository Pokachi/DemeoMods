using MelonLoader;
using System;

namespace DemeoMods.DifficultyMod.Core
{
    public static class DifficultySettings
    {
        private const string MELON_PREF_NAME = "DemeoDifficultyMod";
        private const string MELON_PREF_ENEMY_HP_MULTIPLIER_NAME = "EnemyHpMultiplier";
        private const string MELON_PREF_ENEMY_ATTACK_MULTIPLIER_NAME = "EnemyAttackMultiplier";
        private const string MELON_PREF_ENERGY_GAIN_MULTIPLIER_NAME = "EnergyGainMultiplier"; // Trash Card
        private const string MELON_PREF_ATTACK_ENERGY_GAIN_MULTIPLIER_NAME = "AttackEnergyGainMultiplier";
        private const string MELON_PREF_KILL_ENERGY_GAIN_MULTIPLIER_NAME = "KillEnergyGainMultiplier";
        private const string MELON_PREF_GOLD_PILE_GAIN_MULTIPLIER_NAME = "GoldGainMultiplier";
        private const string MELON_PREF_CARD_SALE_MULTIPLIER_NAME = "CardSaleMultiplier";
        private const string MELON_PREF_CARD_COST_MULTIPLIER_NAME = "CardCostMultiplier";
        private const string MELON_PREF_ENEMY_CAN_OPEN_DOOR_TOGGLE_NAME = "EnemyCanOpenDoorToggle";
        private const string MELON_PREF_ENEMY_RESPAWN_TOGGLE_NAME = "EnemyRespawnToggle";
        private const string MELON_PREF_ENEMY_COUNT_MULTIPLIER_NAME = "EnemyCountMultiplier";
        private const string MELON_PREF_ENEMY_MOVE_MULTIPLIER_NAME = "EnemyMoveMultiplier";

        private const float ENEMY_HP_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_HP_MULTIPLIER_MAX = 5f;
        private const float ENEMY_ATTACK_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_ATTACK_MULTIPLIER_MAX = 5f;
        private const float ENERGY_GAIN_MULTIPLIER_MIN = 0f;
        private const float ENERGY_GAIN_MULTIPLIER_MAX = 5f;
        private const float GOLD_PILE_GAIN_MULTIPLIER_MIN = 0.1f;
        private const float GOLD_PILE_GAIN_MULTIPLIER_MAX = 5f;
        private const float CARD_SALE_MULTIPLIER_MIN = 0.1f;
        private const float CARD_SALE_MULTIPLIER_MAX = 5f;
        private const float CARD_COST_MULTIPLIER_MIN = 0.1f;
        private const float CARD_COST_MULTIPLIER_MAX = 5f;
        private const float ENEMY_COUNT_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_COUNT_MULTIPLIER_MAX = 10f;
        private const float ENEMY_MOVE_MULTIPLIER_MIN = 0.25f;
        private const float ENEMY_MOVE_MULTIPLIER_MAX = 5f;

        public static void RegisterSettings()
        {
            MelonPreferences.CreateCategory(MELON_PREF_NAME, "Demeo Difficulty Settings");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENEMY_HP_MULTIPLIER_NAME, 1f, "Enemy HP");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENEMY_ATTACK_MULTIPLIER_NAME, 1f, "Enemy Attack");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENERGY_GAIN_MULTIPLIER_NAME, 1f, "Trash Card Energy Gain");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ATTACK_ENERGY_GAIN_MULTIPLIER_NAME, 1f, "Attack Enemy Energy Gain");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_KILL_ENERGY_GAIN_MULTIPLIER_NAME, 1f, "Kill Enemy Energy Gain");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_GOLD_PILE_GAIN_MULTIPLIER_NAME, 1f, "Gold Gained From Gold Pile");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_CARD_SALE_MULTIPLIER_NAME, 1f, "Gold Gained From Selling Cards");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_CARD_COST_MULTIPLIER_NAME, 1f, "Gold Cost When Buying Cards");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENEMY_CAN_OPEN_DOOR_TOGGLE_NAME, true, "Enemy Can Open Doors");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENEMY_RESPAWN_TOGGLE_NAME, true, "Enemy Can Respawn");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENEMY_COUNT_MULTIPLIER_NAME, 1f, "Enemy Spawn Rate");
            MelonPreferences.CreateEntry(MELON_PREF_NAME, MELON_PREF_ENEMY_MOVE_MULTIPLIER_NAME, 1f, "Enemy Movement Range");
        }

        #region Properties
        public static float EnemyMoveMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_ENEMY_MOVE_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_ENEMY_MOVE_MULTIPLIER_NAME, value);
            }
        }

        public static float EnemyCountMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_ENEMY_COUNT_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_ENEMY_COUNT_MULTIPLIER_NAME, value);
            }
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

        public static float AttackEnergyGainMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_ATTACK_ENERGY_GAIN_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_ATTACK_ENERGY_GAIN_MULTIPLIER_NAME, value);
            }

        }

        public static float KillEnergyGainMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_KILL_ENERGY_GAIN_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_KILL_ENERGY_GAIN_MULTIPLIER_NAME, value);
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

        public static float CardSaleMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_CARD_SALE_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_CARD_SALE_MULTIPLIER_NAME, value);
            }

        }

        public static float CardCostMultiplier
        {
            get
            {
                return MelonPreferences.GetEntryValue<float>(MELON_PREF_NAME, MELON_PREF_CARD_COST_MULTIPLIER_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_CARD_COST_MULTIPLIER_NAME, value);
            }

        }

        public static bool EnemyCanOpenDoors
        {
            get
            {
                return MelonPreferences.GetEntryValue<bool>(MELON_PREF_NAME, MELON_PREF_ENEMY_CAN_OPEN_DOOR_TOGGLE_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_ENEMY_CAN_OPEN_DOOR_TOGGLE_NAME, value);
            }
        }

        public static bool EnemyCanRespawn
        {
            get
            {
                return MelonPreferences.GetEntryValue<bool>(MELON_PREF_NAME, MELON_PREF_ENEMY_RESPAWN_TOGGLE_NAME);
            }
            set
            {
                MelonPreferences.SetEntryValue(MELON_PREF_NAME, MELON_PREF_ENEMY_RESPAWN_TOGGLE_NAME, value);
            }
        }
        #endregion Properties

        #region Property_Modifier
        public static void DecreaseEnemyMoveMultiplier(Action<float> callBack)
        {
            if (EnemyMoveMultiplier > ENEMY_MOVE_MULTIPLIER_MIN)
            {
                EnemyMoveMultiplier = (float)Math.Round(EnemyMoveMultiplier - 0.25f, 2); ; ;
            }

            callBack(EnemyMoveMultiplier);
        }

        public static void IncreaseEnemyMoveMultiplier(Action<float> callBack)
        {
            if (EnemyMoveMultiplier < ENEMY_MOVE_MULTIPLIER_MAX)
            {
                EnemyMoveMultiplier = (float)Math.Round(EnemyMoveMultiplier + 0.25f, 2); ;
            }

            callBack(EnemyMoveMultiplier);
        }
        public static void DecreaseEnemyCountMultiplier(Action<float> callBack)
        {
            if (EnemyCountMultiplier > ENEMY_COUNT_MULTIPLIER_MIN)
            {
                EnemyCountMultiplier = (float)Math.Round(EnemyCountMultiplier - 0.25f, 2);
            }

            callBack(EnemyCountMultiplier);
        }

        public static void IncreaseEnemyCountMultiplier(Action<float> callBack)
        {
            if (EnemyCountMultiplier < ENEMY_COUNT_MULTIPLIER_MAX)
            {
                EnemyCountMultiplier = (float)Math.Round(EnemyCountMultiplier + 0.25f, 2);
            }

            callBack(EnemyCountMultiplier);
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

        public static void DecreaseAttackEnergyGainMultiplier(Action<float> callBack)
        {
            if (AttackEnergyGainMultiplier > ENERGY_GAIN_MULTIPLIER_MIN)
            {
                AttackEnergyGainMultiplier = (float)Math.Round(AttackEnergyGainMultiplier - 0.1f, 2);
            }

            callBack(AttackEnergyGainMultiplier);
        }

        public static void IncreaseAttackEnergyGainMultiplier(Action<float> callBack)
        {
            if (AttackEnergyGainMultiplier < ENERGY_GAIN_MULTIPLIER_MAX)
            {
                AttackEnergyGainMultiplier = (float)Math.Round(AttackEnergyGainMultiplier + 0.1f, 2);
            }

            callBack(AttackEnergyGainMultiplier);
        }

        public static void DecreaseKillEnergyGainMultiplier(Action<float> callBack)
        {
            if (KillEnergyGainMultiplier > ENERGY_GAIN_MULTIPLIER_MIN)
            {
                KillEnergyGainMultiplier = (float)Math.Round(KillEnergyGainMultiplier - 0.1f, 2);
            }

            callBack(KillEnergyGainMultiplier);
        }

        public static void IncreaseKillEnergyGainMultiplier(Action<float> callBack)
        {
            if (KillEnergyGainMultiplier < ENERGY_GAIN_MULTIPLIER_MAX)
            {
                KillEnergyGainMultiplier = (float)Math.Round(KillEnergyGainMultiplier + 0.1f, 2);
            }

            callBack(KillEnergyGainMultiplier);
        }

        public static void DecreaseGoldPileGainMultiplier(Action<float> callBack)
        {
            if (GoldPileGainMultiplier > GOLD_PILE_GAIN_MULTIPLIER_MIN)
            {
                GoldPileGainMultiplier = (float)Math.Round(GoldPileGainMultiplier - 0.1f, 2);
            }

            callBack(GoldPileGainMultiplier);
        }

        public static void IncreaseGoldPileGainMultiplier(Action<float> callBack)
        {
            if (GoldPileGainMultiplier < GOLD_PILE_GAIN_MULTIPLIER_MAX)
            {
                GoldPileGainMultiplier = (float)Math.Round(GoldPileGainMultiplier + 0.1f, 2);
            }

            callBack(GoldPileGainMultiplier);
        }

        public static void DecreaseCardSaleMultiplier(Action<float> callBack)
        {
            if (CardSaleMultiplier > CARD_SALE_MULTIPLIER_MIN)
            {
                CardSaleMultiplier = (float)Math.Round(CardSaleMultiplier - 0.1f, 2);
            }

            callBack(CardSaleMultiplier);
        }

        public static void IncreaseCardSaleMultiplier(Action<float> callBack)
        {
            if (CardSaleMultiplier < CARD_SALE_MULTIPLIER_MAX)
            {
                CardSaleMultiplier = (float)Math.Round(CardSaleMultiplier + 0.1f, 2);
            }

            callBack(CardSaleMultiplier);
        }

        public static void DecreaseCardCostMultiplier(Action<float> callBack)
        {
            if (CardCostMultiplier > CARD_COST_MULTIPLIER_MIN)
            {
                CardCostMultiplier = (float)Math.Round(CardCostMultiplier - 0.1f, 2);
            }

            callBack(CardCostMultiplier);
        }

        public static void IncreaseCardCostMultiplier(Action<float> callBack)
        {
            if (CardCostMultiplier < CARD_COST_MULTIPLIER_MAX)
            {
                CardCostMultiplier = (float)Math.Round(CardCostMultiplier + 0.1f, 2);
            }

            callBack(CardCostMultiplier);
        }

        public static void ToggleEnemyCanOpenDoor(Action<bool> callBack)
        {
            EnemyCanOpenDoors = !EnemyCanOpenDoors;
            callBack(EnemyCanOpenDoors);
        }

        public static void ToggleEnemyCanRespawn(Action<bool> callBack)
        {
            EnemyCanRespawn = !EnemyCanRespawn;
            callBack(EnemyCanRespawn);
        }
        #endregion Property_Modifier
    }
}