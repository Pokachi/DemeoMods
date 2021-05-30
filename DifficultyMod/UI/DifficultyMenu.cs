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


            // First Page
            GameObject difficultySettingsPageOne = new GameObject("Difficulty Settings 1");
            difficultySettingsPageOne.transform.SetParent(transform);
            difficultySettingsPageOne.transform.localScale = Vector3.one;
            difficultySettingsPageOne.transform.localRotation = Quaternion.Euler(0, 0, 0);
            difficultySettingsPageOne.transform.localPosition = Vector3.zero;
            difficultySettingsPageOne.SetActive(true);

            // Header 
            CreateText(difficultySettingsPageOne.transform, new Vector3(0.036f, 0.15f, 2.4f), 3f, new Color(0.878f, 0.752f, 0.384f, 1), "Difficulty Menu", TextAlignmentOptions.Center, FontStyles.UpperCase);

            // Enemy HP Multiplier
            GameObject enemyHPMultiplier = new GameObject("Enemy HP Multiplier");
            enemyHPMultiplier.transform.SetParent(difficultySettingsPageOne.transform);
            enemyHPMultiplier.transform.localScale = Vector3.one;
            enemyHPMultiplier.transform.localRotation = Quaternion.Euler(0, 0, 0);
            enemyHPMultiplier.transform.localPosition = Vector3.zero;
            enemyHPMultiplier.SetActive(true);

            CreateText(enemyHPMultiplier.transform, new Vector3(0.036f, 0.15f, 1.4f), 3.25f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy HP Multiplier", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro enemyHPMultiplierValue = CreateText(enemyHPMultiplier.transform, new Vector3(0.036f, 0.15f, 0.4f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy HP Multiplier Text", DifficultySettings.EnemyHPMultiplier.ToString(), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(enemyHPMultiplier.transform, new Vector3(-1f, 0.15f, 0.4f), "Enemy HP Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseEnemyHPMultiplier(text => { UpdateText(enemyHPMultiplierValue, text); }); });
            CreateButton(enemyHPMultiplier.transform, new Vector3(1.1f, 0.15f, 0.4f), "Enemy HP Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseEnemyHPMultiplier(text => { UpdateText(enemyHPMultiplierValue, text); }); });

            // Enemy Attack Multiplier
            GameObject enemyAttackMultiplier = new GameObject("Enemy Attack Multiplier");
            enemyAttackMultiplier.transform.SetParent(difficultySettingsPageOne.transform);
            enemyAttackMultiplier.transform.localScale = Vector3.one;
            enemyAttackMultiplier.transform.localRotation = Quaternion.Euler(0, 0, 0);
            enemyAttackMultiplier.transform.localPosition = Vector3.zero;
            enemyAttackMultiplier.SetActive(true);

            CreateText(enemyAttackMultiplier.transform, new Vector3(0.036f, 0.15f, -.6f), 3.25f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Attack Multiplier", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro enemyAttackMultiplierValue = CreateText(enemyAttackMultiplier.transform, new Vector3(0.036f, 0.15f, -1.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Enemy Attack Multiplier Text", DifficultySettings.EnemyAttackMultiplier.ToString(), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(enemyAttackMultiplier.transform, new Vector3(-1f, 0.15f, -1.6f), "Enemy Attack Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseEnemyAttackMultiplier(text => { UpdateText(enemyAttackMultiplierValue, text); }); });
            CreateButton(enemyAttackMultiplier.transform, new Vector3(1.1f, 0.15f, -1.6f), "Enemy Attack Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseEnemyAttackMultiplier(text => { UpdateText(enemyAttackMultiplierValue, text); }); });


            // Energy Gain Multiplier
            GameObject energyGainMultiplier = new GameObject("Energy Gain Multiplier");
            energyGainMultiplier.transform.SetParent(difficultySettingsPageOne.transform);
            energyGainMultiplier.transform.localScale = Vector3.one;
            energyGainMultiplier.transform.localRotation = Quaternion.Euler(0, 0, 0);
            energyGainMultiplier.transform.localPosition = Vector3.zero;
            energyGainMultiplier.SetActive(true);

            CreateText(energyGainMultiplier.transform, new Vector3(0.036f, 0.15f, -2.6f), 3.25f, new Color(0.0392f, 0.0157f, 0, 1), "Energy Gain Multiplier", TextAlignmentOptions.Center, FontStyles.Normal);
            TextMeshPro energyGainMultiplierValue = CreateText(energyGainMultiplier.transform, new Vector3(0.036f, 0.15f, -3.6f), 7f, new Color(0.0392f, 0.0157f, 0, 1), "Energy Gain Multiplier Text", DifficultySettings.EnergyGainMultiplier.ToString(), TextAlignmentOptions.Center, FontStyles.Normal);
            CreateButton(energyGainMultiplier.transform, new Vector3(-1f, 0.15f, -3.6f), "Energy Gain Multiplier Down", "DreadArrowDown", () => { DifficultySettings.DecreaseEnergyGainMultiplier(text => { UpdateText(energyGainMultiplierValue, text); }); });
            CreateButton(energyGainMultiplier.transform, new Vector3(1.1f, 0.15f, -3.6f), "Energy Gain Multiplier Up", "DreadArrowUp", () => { DifficultySettings.IncreaseEnergyGainMultiplier(text => { UpdateText(energyGainMultiplierValue, text); }); });

            MelonLogger.Msg("Initialized UI Elements.");
        }

        private static void UpdateText(TextMeshPro textMeshPro, float text)
        {
            textMeshPro.SetText(text.ToString());
        }

        private static ClickableButton CreateButton(Transform parent, Vector3 position, string buttonName, string meshName, Action callback)
        {
            GameObject gameObject = new GameObject(buttonName, typeof(MeshFilter), typeof(MeshRenderer), typeof(MenuButtonHoverEffect), typeof(ClickableButton));
            gameObject.SetActive(false);
            gameObject.layer = 5; //UI layer

            new MenuButtonHoverEffect();
            // Transform
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            transform.localPosition = position;
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

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

            // ClickableButton
            ClickableButton clickableButton = gameObject.GetComponent<ClickableButton>();
            clickableButton.InitButton(0, "", callback, false);

            // We add Box Collider so we don't need to make any adjustments
            BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();

            gameObject.SetActive(true);

            return clickableButton;
        }


        private static TextMeshPro CreateText(Transform parent, Vector3 position, float fontSize, Color color, string text, TextAlignmentOptions alignment, FontStyles fontStyles)
        {
            return CreateText(parent, position, fontSize, color, text, text, alignment, fontStyles);
        }

        private static TextMeshPro CreateText(Transform parent, Vector3 position, float fontSize, Color color, string name, string text, TextAlignmentOptions alignment, FontStyles fontStyles)
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
            rectTransform.offsetMax = new Vector2(1.9245f, 0.5738f);
            rectTransform.offsetMin = new Vector2(-1.8525f, -0.2737f);
            rectTransform.localRotation = Quaternion.Euler(90, 0, 0);
            rectTransform.localScale = Vector3.one;
            rectTransform.localPosition = position;

            // TextMeshPro
            TextMeshPro textMeshPro = gameObject.GetComponent<TextMeshPro>();
            textMeshPro.font = Resources.FindObjectsOfTypeAll<TMP_FontAsset>().First(x => x.name == "Demeo SDF");
            textMeshPro.fontStyle = fontStyles;
            textMeshPro.text = text;
            textMeshPro.fontSize = fontSize;
            textMeshPro.color = color;
            textMeshPro.alignment = alignment;

            gameObject.SetActive(true);



            return textMeshPro;
        }
    }
}
