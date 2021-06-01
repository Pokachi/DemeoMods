using DemeoMods.DifficultyMod.Core;
using MelonLoader;
using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace DemeoMods.DifficultyMod.UI
{
    class DifficultyMenu : MonoBehaviour
    {
        private const int TOTAL_PAGES = 4;
        private static int currentPage = 1;

        private static GameObject difficultySettingsPageOne;
        private static GameObject difficultySettingsPageTwo;
        private static GameObject difficultySettingsPageThree;
        private static GameObject difficultySettingsPageFour;

        private static TextMeshPro enemyOpenDoorDescription;
        private static TextMeshPro enemyOpenDoorButtonText;
        private static TextMeshPro enemyRespawnDescription;
        private static TextMeshPro enemyRespawnButtonText;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            MelonLogger.Msg("Initializing UI Elements...");
            gameObject.SetActive(false);
            gameObject.layer = 5; //UI layer

            // Creating the Mesh for the Difficulty Menu
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = Resources.FindObjectsOfTypeAll<Mesh>().First(x => x.name == "MenuBox_SettingsButton");

            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.material = Resources.FindObjectsOfTypeAll<Material>().First(x => x.name == "MainMenuMat (Instance)");

            // Set Location and Size of Difficulty Menu
            transform.SetParent(Resources.FindObjectsOfTypeAll<charactersoundlistener>().First(x => x.name == "MenuBox_BindPose").transform, false);
            transform.position = new Vector3(30, 20, -15);
            transform.rotation = Quaternion.Euler(275, 40, 0);
            transform.localScale = new Vector3(3, 1, 2);

            gameObject.AddComponent<BoxCollider>();

            gameObject.SetActive(true);

            #region First_Page(Monsters)
            difficultySettingsPageOne = CreateContainer(transform, "Difficulty Settings 1");

            // Header
            CreateText(difficultySettingsPageOne.transform, new Vector3(0.036f, 0.15f, 2.4f), 3f, new Color(0.878f, 0.752f, 0.384f, 1), "Difficulty Menu", TextAlignmentOptions.Center, FontStyles.UpperCase);

            // Enemy HP Multiplier
            GameObject enemyHPMultiplier = CreateContainer(difficultySettingsPageOne.transform, "Enemy HP Multiplier");
            CreateText(enemyHPMultiplier.transform, new Vector3(0.036f, 0.15f, 1.4f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy HP", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro enemyHPMultiplierValue = CreateText(enemyHPMultiplier.transform, new Vector3(0.036f, 0.15f, 0.4f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy HP Multiplier Text", floatToPercentStr(DifficultySettings.EnemyHPMultiplier), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(enemyHPMultiplier.transform, new Vector3(-1.3f, 0.15f, 0.4f), "Enemy HP Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseEnemyHPMultiplier(text => { UpdateText(enemyHPMultiplierValue, text); }); });
            CreateButton(enemyHPMultiplier.transform, new Vector3(1.4f, 0.15f, 0.4f), "Enemy HP Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseEnemyHPMultiplier(text => { UpdateText(enemyHPMultiplierValue, text); }); });

            // Enemy Attack Multiplier
            GameObject enemyAttackMultiplier = CreateContainer(difficultySettingsPageOne.transform, "Enemy Attack Multiplier");
            CreateText(enemyAttackMultiplier.transform, new Vector3(0.036f, 0.15f, -.6f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Attack", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro enemyAttackMultiplierValue = CreateText(enemyAttackMultiplier.transform, new Vector3(0.036f, 0.15f, -1.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Attack Multiplier Text", floatToPercentStr(DifficultySettings.EnemyAttackMultiplier), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(enemyAttackMultiplier.transform, new Vector3(-1.3f, 0.15f, -1.6f), "Enemy Attack Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseEnemyAttackMultiplier(text => { UpdateText(enemyAttackMultiplierValue, text); }); });
            CreateButton(enemyAttackMultiplier.transform, new Vector3(1.4f, 0.15f, -1.6f), "Enemy Attack Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseEnemyAttackMultiplier(text => { UpdateText(enemyAttackMultiplierValue, text); }); });

            // Enemy Movement
            GameObject enemyMove = CreateContainer(difficultySettingsPageOne.transform, "Enemy Move");
            CreateText(enemyMove.transform, new Vector3(0.036f, 0.15f, -2.6f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Movement Range", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro enemyMoveMultiplierValue = CreateText(enemyMove.transform, new Vector3(0.036f, 0.15f, -3.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Move Text", floatToPercentStr(DifficultySettings.EnemyMoveMultiplier), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(enemyMove.transform, new Vector3(-1.3f, 0.15f, -3.6f), "Enemy Move Down", "DreadArrowDown", () => { DifficultySettings.DecreaseEnemyMoveMultiplier(text => { UpdateText(enemyMoveMultiplierValue, text); }); });
            CreateButton(enemyMove.transform, new Vector3(1.4f, 0.15f, -3.6f), "Enemy Move Up", "DreadArrowUp", () => { DifficultySettings.IncreaseEnemyMoveMultiplier(text => { UpdateText(enemyMoveMultiplierValue, text); }); });

            // Navigation Button
            GameObject pageOneNavigationButtons = CreateContainer(difficultySettingsPageOne.transform, "Navigation Buttons");
            CreateButton(pageOneNavigationButtons.transform, new Vector3(-1.5f, 0.15f, -5.6f), "Previous Page", "DreadArrowDown", () => { ChangePage((currentPage - 1) % TOTAL_PAGES); }, new Vector3(0.7f, 0.7f, 0.7f));
            CreateText(pageOneNavigationButtons.transform, new Vector3(0.036f, 0.15f, -5.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Page 1", TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(pageOneNavigationButtons.transform, new Vector3(1.6f, 0.15f, -5.6f), "Next Page", "DreadArrowUp", () => { ChangePage((currentPage + 1) % TOTAL_PAGES); }, new Vector3(0.7f, 0.7f, 0.7f));
            #endregion First_Page

            #region Second_Page(Monsters)
            difficultySettingsPageTwo = CreateContainer(transform, "Difficulty Settings 2");
            difficultySettingsPageTwo.SetActive(false);
            
            // Header
            CreateText(difficultySettingsPageTwo.transform, new Vector3(0.036f, 0.15f, 2.4f), 3f, new Color(0.878f, 0.752f, 0.384f, 1), "Difficulty Menu", TextAlignmentOptions.Center, FontStyles.UpperCase);

            // Enemy Respawn Toggle
            GameObject enemyRespawnToggle = CreateContainer(difficultySettingsPageTwo.transform, "Enemy Respawn");
            enemyRespawnDescription = CreateText(enemyRespawnToggle.transform, new Vector3(0.036f, 0.15f, 1.4f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Can Respawn", TextAlignmentOptions.Center, FontStyles.Normal);
            ClickableButton enemyRespawnButton = CreateButton(enemyRespawnToggle.transform, new Vector3(0.036f, 0.15f, 0.4f), Quaternion.Euler(270, 0, 0), "Enemy Respawn Toggle", "Disable", "UIMenuMainButton", () => { DifficultySettings.ToggleEnemyCanRespawn(result => { updateEnemyCanRespawnString(result); }); }, new Vector3(0.5f, 0.66f, 0.5f));
            enemyRespawnButtonText = enemyRespawnButton.GetComponentInChildren<TextMeshPro>();

            // Enemy Count
            GameObject enemySpawnMultiplier = CreateContainer(difficultySettingsPageTwo.transform, "Enemy Spawn Multiplier");
            CreateText(enemySpawnMultiplier.transform, new Vector3(0.036f, 0.15f, -.6f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Count", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro enemySpawnMultiplierValue = CreateText(enemySpawnMultiplier.transform, new Vector3(0.036f, 0.15f, -1.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Spawn Multiplier Text", floatToPercentStr(DifficultySettings.EnemyCountMultiplier), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(enemySpawnMultiplier.transform, new Vector3(-1.3f, 0.15f, -1.6f), "Enemy Spawn Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseEnemyCountMultiplier(text => { UpdateText(enemySpawnMultiplierValue, text); }); });
            CreateButton(enemySpawnMultiplier.transform, new Vector3(1.4f, 0.15f, -1.6f), "Enemy Spawn Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseEnemyCountMultiplier(text => { UpdateText(enemySpawnMultiplierValue, text); }); });

            // Enemy Open Door Toggle
            GameObject enemyOpenDoorToggle = CreateContainer(difficultySettingsPageTwo.transform, "Enemy Open Door");
            enemyOpenDoorDescription = CreateText(enemyOpenDoorToggle.transform, new Vector3(0.036f, 0.15f, -2.6f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Can Open Door", TextAlignmentOptions.Center, FontStyles.Normal);
            ClickableButton enemyOpenDoorButton = CreateButton(enemyOpenDoorToggle.transform, new Vector3(0.036f, 0.15f, -3.6f), Quaternion.Euler(270, 0, 0), "Enemy Open Door Toggle", "Disable", "UIMenuMainButton", () => { DifficultySettings.ToggleEnemyCanOpenDoor(result => { updateEnemyCanOpenDoorString(result); }); }, new Vector3(0.5f, 0.66f, 0.5f));
            enemyOpenDoorButtonText = enemyOpenDoorButton.GetComponentInChildren<TextMeshPro>();
            updateEnemyCanOpenDoorString(DifficultySettings.EnemyCanOpenDoors);

            // Navigation Button
            GameObject pageTwoNavigationButtons = CreateContainer(difficultySettingsPageTwo.transform, "Navigation Buttons");
            CreateButton(pageTwoNavigationButtons.transform, new Vector3(-1.5f, 0.15f, -5.6f), "Previous Page", "DreadArrowDown", () => { ChangePage((currentPage - 1) % TOTAL_PAGES); }, new Vector3(0.7f, 0.7f, 0.7f));
            CreateText(pageTwoNavigationButtons.transform, new Vector3(0.036f, 0.15f, -5.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Page 2", TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(pageTwoNavigationButtons.transform, new Vector3(1.6f, 0.15f, -5.6f), "Next Page", "DreadArrowUp", () => { ChangePage((currentPage + 1) % TOTAL_PAGES); }, new Vector3(0.7f, 0.7f, 0.7f));
            #endregion Second_Page

            #region Third_Page
            difficultySettingsPageThree = CreateContainer(transform, "Difficulty Settings 3");
            difficultySettingsPageThree.SetActive(false);

            // Header
            CreateText(difficultySettingsPageThree.transform, new Vector3(0.036f, 0.15f, 2.4f), 3f, new Color(0.878f, 0.752f, 0.384f, 1), "Difficulty Menu", TextAlignmentOptions.Center, FontStyles.UpperCase);

            // Gold Pile Multiplier
            GameObject goldPileMultiplier = CreateContainer(difficultySettingsPageThree.transform, "Gold Pile Multiplier");
            CreateText(goldPileMultiplier.transform, new Vector3(0.036f, 0.15f, 1.4f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Gold Pile Amount", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro goldPileMultiplierValue = CreateText(goldPileMultiplier.transform, new Vector3(0.036f, 0.15f, 0.4f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Gold Pile Multiplier Text", floatToPercentStr(DifficultySettings.GoldPileGainMultiplier), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(goldPileMultiplier.transform, new Vector3(-1.3f, 0.15f, 0.4f), "Gold Pile Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseGoldPileGainMultiplier(text => { UpdateText(goldPileMultiplierValue, text); }); });
            CreateButton(goldPileMultiplier.transform, new Vector3(1.4f, 0.15f, 0.4f), "Gold Pile Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseGoldPileGainMultiplier(text => { UpdateText(goldPileMultiplierValue, text); }); });

            // Card Sale Multiplier
            GameObject cardSaleMultiplier = CreateContainer(difficultySettingsPageThree.transform, "Card Sale Multiplier");
            CreateText(cardSaleMultiplier.transform, new Vector3(0.036f, 0.15f, -0.6f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Card Selling Price", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro cardSaleMultiplierValue = CreateText(cardSaleMultiplier.transform, new Vector3(0.036f, 0.15f, -1.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Card Sale Multiplier Text", floatToPercentStr(DifficultySettings.CardSaleMultiplier), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(cardSaleMultiplier.transform, new Vector3(-1.3f, 0.15f, -1.6f), "Card Sale Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseCardSaleMultiplier(text => { UpdateText(cardSaleMultiplierValue, text); }); });
            CreateButton(cardSaleMultiplier.transform, new Vector3(1.4f, 0.15f, -1.6f), "Card Sale Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseCardSaleMultiplier(text => { UpdateText(cardSaleMultiplierValue, text); }); });

            // Card Cost Multiplier
            GameObject cardCostMultiplier = CreateContainer(difficultySettingsPageThree.transform, "Card Cost Multiplier");
            CreateText(cardCostMultiplier.transform, new Vector3(0.036f, 0.15f, -2.6f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Card Buying Price", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro cardCostMultiplierValue = CreateText(cardCostMultiplier.transform, new Vector3(0.036f, 0.15f, -3.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Card Cost Multiplier Text", floatToPercentStr(DifficultySettings.CardCostMultiplier), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(cardCostMultiplier.transform, new Vector3(-1.3f, 0.15f, -3.6f), "Card Cost Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseCardCostMultiplier(text => { UpdateText(cardCostMultiplierValue, text); }); });
            CreateButton(cardCostMultiplier.transform, new Vector3(1.4f, 0.15f, -3.6f), "Card Cost Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseCardCostMultiplier(text => { UpdateText(cardCostMultiplierValue, text); }); });

            // Navigation Button
            GameObject pageThreeNavigationButtons = CreateContainer(difficultySettingsPageThree.transform, "Navigation Buttons");
            CreateButton(pageThreeNavigationButtons.transform, new Vector3(-1.5f, 0.15f, -5.6f), "Previous Page", "DreadArrowDown", () => { ChangePage((currentPage - 1) % TOTAL_PAGES); }, new Vector3(0.7f, 0.7f, 0.7f));
            CreateText(pageThreeNavigationButtons.transform, new Vector3(0.036f, 0.15f, -5.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Page 3", TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(pageThreeNavigationButtons.transform, new Vector3(1.6f, 0.15f, -5.6f), "Next Page", "DreadArrowUp", () => { ChangePage((currentPage + 1) % TOTAL_PAGES); }, new Vector3(0.7f, 0.7f, 0.7f));
            #endregion Third_Page

            #region Fourth_Page
            difficultySettingsPageFour = CreateContainer(transform, "Difficulty Settings 3");
            difficultySettingsPageFour.SetActive(false);

            // Header
            CreateText(difficultySettingsPageFour.transform, new Vector3(0.036f, 0.15f, 2.4f), 3f, new Color(0.878f, 0.752f, 0.384f, 1), "Difficulty Menu", TextAlignmentOptions.Center, FontStyles.UpperCase);

            // Energy Gain Multiplier
            GameObject energyGainMultiplier = CreateContainer(difficultySettingsPageFour.transform, "Energy Gain Multiplier");
            CreateText(energyGainMultiplier.transform, new Vector3(0.036f, 0.15f, -2.6f), 4.4f, new Color(0.0392f, 0.0157f, 0, 1), "Energy Gain", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro energyGainMultiplierValue = CreateText(energyGainMultiplier.transform, new Vector3(0.036f, 0.15f, -3.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Energy Gain Multiplier Text", floatToPercentStr(DifficultySettings.EnergyGainMultiplier), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(energyGainMultiplier.transform, new Vector3(-1.3f, 0.15f, -3.6f), "Energy Gain Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseEnergyGainMultiplier(text => { UpdateText(energyGainMultiplierValue, text); }); });
            CreateButton(energyGainMultiplier.transform, new Vector3(1.4f, 0.15f, -3.6f), "Energy Gain Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseEnergyGainMultiplier(text => { UpdateText(energyGainMultiplierValue, text); }); });

            // Navigation Button
            GameObject pageFourNavigationButtons = CreateContainer(difficultySettingsPageFour.transform, "Navigation Buttons");
            CreateButton(pageFourNavigationButtons.transform, new Vector3(-1.5f, 0.15f, -5.6f), "Previous Page", "DreadArrowDown", () => { ChangePage((currentPage - 1) % TOTAL_PAGES); }, new Vector3(0.7f, 0.7f, 0.7f));
            CreateText(pageFourNavigationButtons.transform, new Vector3(0.036f, 0.15f, -5.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Page 4", TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(pageFourNavigationButtons.transform, new Vector3(1.6f, 0.15f, -5.6f), "Next Page", "DreadArrowUp", () => { ChangePage((currentPage + 1) % TOTAL_PAGES); }, new Vector3(0.7f, 0.7f, 0.7f));
            #endregion Fourth_page

            MelonLogger.Msg("Initialized UI Elements.");
        }

        private static void updateEnemyCanOpenDoorString(bool canOpenDoor)
        {
            string description = canOpenDoor ? "Enemy Can Open Doors" : "Enemy Can't Open Doors";
            string button = canOpenDoor ? "Disable" : "Enable";
            UpdateText(enemyOpenDoorDescription, description);
            UpdateText(enemyOpenDoorButtonText, button);
        }

        private static void updateEnemyCanRespawnString(bool canRespawn)
        {
            string description = canRespawn ? "Enemy Can Respawn" : "Enemy Can't Respawn";
            string button = canRespawn ? "Disable" : "Enable";
            UpdateText(enemyRespawnDescription, description);
            UpdateText(enemyRespawnButtonText, button);
        }

        private static void ChangePage(int newPage)
        {
            currentPage = newPage == 0 ? TOTAL_PAGES : newPage;

            difficultySettingsPageOne.SetActive(false);
            difficultySettingsPageTwo.SetActive(false);
            difficultySettingsPageThree.SetActive(false);
            difficultySettingsPageFour.SetActive(false);

            switch (currentPage)
            {
                case 1:
                    difficultySettingsPageOne.SetActive(true);
                    break;
                case 2:
                    difficultySettingsPageTwo.SetActive(true);
                    break;
                case 3:
                    difficultySettingsPageThree.SetActive(true);
                    break;
                case 4:
                    difficultySettingsPageFour.SetActive(true);
                    break;
            }
        }

        private static string floatToPercentStr(float number)
        {
            return number * 100 + "%";
        }

        private static void UpdateText(TextMeshPro textMeshPro, float number)
        {
            textMeshPro.SetText(floatToPercentStr(number));
        }

        private static void UpdateText(TextMeshPro textMeshPro, string text)
        {
            textMeshPro.SetText(text);
        }

        private static GameObject CreateContainer(Transform parent, string containerName)
        {
            GameObject gameObject = new GameObject(containerName);
            gameObject.SetActive(false);
            gameObject.transform.SetParent(parent);
            gameObject.transform.localScale = Vector3.one;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.SetActive(true);

            return gameObject;
        }

        private static ClickableButton CreateButton(Transform parent, Vector3 position, string buttonName, string meshName, Action callback)
        {
            return CreateButton(parent, position, Quaternion.Euler(0, 90, 0), buttonName, "", meshName, callback, new Vector3(0.5f, 0.5f, 0.5f));
        }

        private static ClickableButton CreateButton(Transform parent, Vector3 position, string buttonName, string meshName, Action callback, Vector3 scale)
        {
            return CreateButton(parent, position, Quaternion.Euler(0, 90, 0), buttonName, "", meshName, callback, scale);
        }

        private static ClickableButton CreateButton(Transform parent, Vector3 position, Quaternion rotation, string buttonName, string buttonText, string meshName, Action callback)
        {
            return CreateButton(parent, position, rotation, buttonName, buttonText, meshName, callback, new Vector3(0.5f, 0.5f, 0.5f));
        }

        private static ClickableButton CreateButton(Transform parent, Vector3 position, Quaternion rotation, string buttonName, string buttonText, string meshName, Action callback, Vector3 scale)
        {
            GameObject gameObject = new GameObject(buttonName, typeof(MeshFilter), typeof(MeshRenderer), typeof(MenuButtonHoverEffect));
            gameObject.SetActive(false);
            gameObject.layer = 5; //UI layer

            // Create Button Text
            if (!string.IsNullOrEmpty(buttonText))
            {
                CreateText(gameObject.transform, new Vector3(0f, 0f, 0.215f), Quaternion.Euler(0, 180, 180), 5, new Color(1, 1, 1, 1), Resources.FindObjectsOfTypeAll<TMP_ColorGradient>().First(x => x.name == "Demeo - Main Menu Buttons"), buttonName + "Text", buttonText, TextAlignmentOptions.Center, FontStyles.UpperCase);
            }

            new MenuButtonHoverEffect();
            // Transform
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localRotation = rotation;
            transform.localPosition = position;
            transform.localScale = scale;

            // Mesh Filter
            MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
            meshFilter.mesh = Resources.FindObjectsOfTypeAll<Mesh>().First(x => x.name == meshName);

            // Mesh Renderer
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.material = Resources.FindObjectsOfTypeAll<Material>().First(x => x.name == "MainMenuMat");

            // Menu Button Hover Effect
            MenuButtonHoverEffect menuButtonHoverEffect = gameObject.GetComponent<MenuButtonHoverEffect>();
            menuButtonHoverEffect.hoverMaterial = Resources.FindObjectsOfTypeAll<Material>().First(x => x.name == "MainMenuHover");
            menuButtonHoverEffect.Init();

            // ClickableButton (We have to add clickable button after we add the child component;
            ClickableButton clickableButton = gameObject.AddComponent<ClickableButton>();
            clickableButton.InitButton(0, buttonText, callback, false);

            // We add Box Collider last so we don't need to make any adjustments
            gameObject.AddComponent<BoxCollider>();

            gameObject.SetActive(true);

            return clickableButton;
        }


        private static TextMeshPro CreateText(Transform parent, Vector3 position, float fontSize, Color color, string text, TextAlignmentOptions alignment, FontStyles fontStyles)
        {
            return CreateText(parent, position, Quaternion.Euler(90, 0, 0), fontSize, color, null, text, text, alignment, fontStyles);
        }

        private static TextMeshPro CreateText(Transform parent, Vector3 position, float fontSize, Color color, string name, string text, TextAlignmentOptions alignment, FontStyles fontStyles)
        {
            return CreateText(parent, position, Quaternion.Euler(90, 0, 0), fontSize, color, null, name, text, alignment, fontStyles);
        }

        private static TextMeshPro CreateText(Transform parent, Vector3 position, Quaternion rotation, float fontSize, Color color, TMP_ColorGradient gradient, string name, string text, TextAlignmentOptions alignment, FontStyles fontStyles)
        {
            GameObject gameObject = new GameObject(name, typeof(TextMeshPro));
            gameObject.SetActive(false);
            gameObject.layer = 5; //UI layer

            // RectTransform
            RectTransform rectTransform = (RectTransform) gameObject.transform;
            rectTransform.SetParent(parent, false);
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.sizeDelta = new Vector2(3.777f, 0.7597f);
            rectTransform.localRotation = rotation;
            rectTransform.localScale = Vector3.one;
            rectTransform.localPosition = position;

            // TextMeshPro
            TextMeshPro textMeshPro = gameObject.GetComponent<TextMeshPro>();
            textMeshPro.font = Resources.FindObjectsOfTypeAll<TMP_FontAsset>().First(x => x.name == "Demeo SDF");
            textMeshPro.fontStyle = fontStyles;
            textMeshPro.text = text;
            textMeshPro.fontSize = fontSize;
            textMeshPro.color = color;
            textMeshPro.colorGradientPreset = gradient;
            textMeshPro.alignment = alignment;
            textMeshPro.fontSizeMax = fontSize;
            textMeshPro.fontSizeMin = 1f;
            textMeshPro.enableAutoSizing = true;

            gameObject.SetActive(true);



            return textMeshPro;
        }
    }
}
