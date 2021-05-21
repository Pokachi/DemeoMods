using MelonLoader;
using Prototyping;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DemeoMods.UI
{
    class DifficultyMenu : MonoBehaviour
    {

        private Canvas _canvas;
        private RectTransform _transform;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            MelonLogger.Msg("(DifficultyMod|Info) Initializing...");
            //Creating the Canvas to hold the menu
            _canvas = gameObject.AddComponent<Canvas>();
            _canvas.renderMode = RenderMode.WorldSpace;
            _canvas.worldCamera = RG.ActiveCamera;


            foreach (Camera cam in Resources.FindObjectsOfTypeAll<Camera>())
            {
                MelonLogger.Msg("Camera " + cam.name);
            }

            _transform = (RectTransform) transform;
            _transform.position = new Vector3(35, 23, -20);
            _transform.sizeDelta = new Vector2(30, 40);
            _transform.anchorMin = new Vector2(0, 0);
            _transform.anchorMax = new Vector2(0, 0);
            _transform.pivot = new Vector2(0.5f, 0.5f);
            _transform.rotation = Quaternion.Euler(0, 50, 0);
            _transform.localScale = Vector3.one;


            /*
            for  (float x = -200; x < 200; x+= 10)
            {
                for (float y = -200; y < 200; y+= 10)
                {

                    CreateText(_canvas, new Vector2(x,y), 15, x + " " + y, "(" + x + "," + y + ")");
                }
            }*/

            //CreateText(_canvas, new Vector2(105, 37), 15, "Enemy HP Multiplier", "Enemy HP Multiplier");


            MelonLogger.Msg("(DifficultyMod|Info) Creating UI Elements...");
            GameObject backgroundPanel = CreatePanel(_canvas.transform, "Difficulty Menu Panel");
            CreateText(backgroundPanel.transform, new Vector3(0, -5, 0), 20, "Difficulty Menu", "Difficulty Menu", TextAlignmentOptions.Center);
            CreateText(backgroundPanel.transform, new Vector3(3, -8, 0), 15, "Enemy HP Multiplier", "Enemy HP Multiplier", TextAlignmentOptions.Left);
            CreateSlider(backgroundPanel.transform, new Vector3(3, -10, 0), "Enemy HP Multiplier Slider", 4, 20);
        }

        private static GameObject CreateSlider(Transform parent, Vector3 position, string name, int minValue, int maxValue)
        {
            GameObject gameObject = new GameObject(name, typeof(RectTransform), typeof(Slider));
            gameObject.SetActive(false);

            RectTransform rectTransform = (RectTransform)gameObject.transform;
            rectTransform.SetParent(parent, false);
            rectTransform.anchorMin = new Vector2(0f, 1f);
            rectTransform.anchorMax = new Vector2(0f, 1f);
            rectTransform.pivot = new Vector2(0f, 1f);
            rectTransform.sizeDelta = new Vector2(250, 15);
            rectTransform.transform.localPosition = Vector3.zero;
            rectTransform.localScale = new Vector3(0.1f, 0.1f);
            rectTransform.anchoredPosition = position;

            MelonLogger.Msg("(DifficultyMod|Info) Creating Slider Background");

            // Background
            GameObject background = new GameObject(name + " Background", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            background.SetActive(false);

            RectTransform backgroundRectTransform = (RectTransform)background.transform;
            backgroundRectTransform.SetParent(rectTransform, false);
            backgroundRectTransform.anchorMin = new Vector2(0f, 0.25f);
            backgroundRectTransform.anchorMax = new Vector2(1f, 0.75f);
            backgroundRectTransform.pivot = new Vector2(0.5f, 0.5f);
            backgroundRectTransform.offsetMin = new Vector2(0, 0);
            backgroundRectTransform.offsetMax = new Vector2(0, 0);
            backgroundRectTransform.localScale = Vector3.one;
            backgroundRectTransform.transform.localPosition = Vector3.zero;

            CanvasRenderer backgroundcanvasRenderer = background.GetComponent<CanvasRenderer>();
            backgroundcanvasRenderer.cullTransparentMesh = true;

            Image backgroundImage = background.GetComponent<Image>();
            backgroundImage.sprite = Resources.FindObjectsOfTypeAll<Sprite>().Last(x => x.name == "Background");
            backgroundImage.color = Color.white;
            backgroundImage.type = Image.Type.Sliced;
            backgroundImage.fillCenter = true;

            background.SetActive(true);
            
            MelonLogger.Msg("(DifficultyMod|Info) Creating Slider Fill Area");

            // Fill Area
            GameObject fillArea = new GameObject(name + " Fill Area", typeof(RectTransform));
            fillArea.SetActive(false);

            RectTransform fillAreaRectTransform = (RectTransform)fillArea.transform;
            fillAreaRectTransform.SetParent(rectTransform, false);
            fillAreaRectTransform.anchorMin = new Vector2(0f, 0.25f);
            fillAreaRectTransform.anchorMax = new Vector2(1f, 0.75f);
            fillAreaRectTransform.pivot = new Vector2(0.5f, 0.5f);
            fillAreaRectTransform.offsetMin = new Vector2(5, 0);
            fillAreaRectTransform.offsetMax = new Vector2(15, 0);
            fillAreaRectTransform.localScale = Vector3.one;
            fillAreaRectTransform.transform.localPosition = Vector3.zero;

            fillArea.SetActive(true);

            MelonLogger.Msg("(DifficultyMod|Info) Creating Slider Fill");

            // Fill
            GameObject fill = new GameObject(name + " Fill", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            fill.SetActive(false);

            RectTransform fillRectTransform = (RectTransform)fill.transform;
            fillRectTransform.SetParent(fillAreaRectTransform, false);
            fillRectTransform.anchorMin = new Vector2(0f, 0f);
            fillRectTransform.anchorMax = new Vector2(0f, 1f);
            fillRectTransform.pivot = new Vector2(0.5f, 0.5f);
            fillRectTransform.offsetMin = new Vector2(0, 0);
            fillRectTransform.offsetMax = new Vector2(0, 0);
            fillRectTransform.sizeDelta = new Vector2(10, 0);
            fillRectTransform.localScale = Vector3.one;
            fillRectTransform.transform.localPosition = Vector3.zero;

            CanvasRenderer fillcanvasRenderer = fill.GetComponent<CanvasRenderer>();
            fillcanvasRenderer.cullTransparentMesh = true;

            Image fillImage = fill.GetComponent<Image>();
            fillImage.sprite = Resources.FindObjectsOfTypeAll<Sprite>().Last(x => x.name == "UISprite");
            fillImage.color = Color.white;
            fillImage.type = Image.Type.Sliced;
            fillImage.fillCenter = true;

            fill.SetActive(true);

            MelonLogger.Msg("(DifficultyMod|Info) Creating Slider Handle Slide Area");

            // Handle Slide Area
            GameObject handleSlideArea = new GameObject(name + " Handle Slide Area", typeof(RectTransform));
            handleSlideArea.SetActive(false);

            RectTransform handleSlideAreaTransform = (RectTransform)handleSlideArea.transform;
            handleSlideAreaTransform.SetParent(rectTransform, false);
            handleSlideAreaTransform.anchorMin = new Vector2(0f, 0f);
            handleSlideAreaTransform.anchorMax = new Vector2(1f, 1f);
            handleSlideAreaTransform.pivot = new Vector2(0.5f, 0.5f);
            handleSlideAreaTransform.offsetMin = new Vector2(10, 0);
            handleSlideAreaTransform.offsetMax = new Vector2(10, 0);
            handleSlideAreaTransform.localScale = Vector3.one;
            handleSlideAreaTransform.transform.localPosition = Vector3.zero;

            handleSlideArea.SetActive(true);
            MelonLogger.Msg("(DifficultyMod|Info) Creating Slider Handle");

            // Handle
            GameObject handle = new GameObject(name + " Handle", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            handle.SetActive(false);

            RectTransform handleRectTransform = (RectTransform)handle.transform;
            handleRectTransform.SetParent(handleSlideAreaTransform, false);
            handleRectTransform.anchorMin = new Vector2(0f, 0f);
            handleRectTransform.anchorMax = new Vector2(0f, 1f);
            handleRectTransform.pivot = new Vector2(0.5f, 0.5f);
            handleRectTransform.sizeDelta = new Vector2(20, 0);
            handleRectTransform.localScale = Vector3.one;
            handleRectTransform.transform.localPosition = Vector3.zero;
            
            CanvasRenderer handlecanvasRenderer = handle.GetComponent<CanvasRenderer>();
            handlecanvasRenderer.cullTransparentMesh = true;

            Image handleImage = handle.GetComponent<Image>();
            handleImage.sprite = Resources.FindObjectsOfTypeAll<Sprite>().Last(x => x.name == "DecoSideLeft");
            handleImage.color = new Color(248, 217, 90);
            handleImage.type = Image.Type.Sliced;
            handleImage.fillCenter = true;

            handle.SetActive(true);

            Slider slider = gameObject.GetComponent<Slider>();
            slider.interactable = true;
            slider.targetGraphic = handleImage;
            slider.fillRect = fillRectTransform;
            slider.handleRect = handleRectTransform;
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.wholeNumbers = true;

            gameObject.SetActive(true);

            return gameObject;

        }

        private static GameObject CreatePanel(Transform transform, string name)
        {
            GameObject gameObject = new GameObject(name, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            gameObject.SetActive(false);

            RectTransform rectTransform = (RectTransform) gameObject.transform;

            rectTransform.SetParent(transform, false);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.localScale = Vector3.one;

            CanvasRenderer canvasRenderer = gameObject.GetComponent<CanvasRenderer>();
            canvasRenderer.cullTransparentMesh = true;

            Image image = gameObject.GetComponent<Image>();
            image.sprite = Resources.FindObjectsOfTypeAll<Sprite>().Last(x => x.name == "Paper");
            image.color = Color.white;
            image.type = Image.Type.Sliced;
            image.fillCenter = true;

            gameObject.SetActive(true);

            return gameObject;
        }

        private static TextMeshPro CreateText(Transform parent, Vector2 position, float fontSize, string name, string text, TextAlignmentOptions alignment) {
            GameObject gameObject = new GameObject(name);
            gameObject.SetActive(false);

            TextMeshPro textMeshProUgui = gameObject.AddComponent<TextMeshPro>();

            RectTransform rectTransform =textMeshProUgui.rectTransform;
            rectTransform.SetParent(parent, false);
            rectTransform.anchorMin = new Vector2(0f, 1f);
            rectTransform.anchorMax = new Vector2(0f, 1f);
            rectTransform.pivot = new Vector2(0f, 1f);
            rectTransform.sizeDelta = new Vector2(30f, 1f);
            rectTransform.transform.localPosition = Vector3.zero;
            rectTransform.localScale = Vector3.one;
            rectTransform.anchoredPosition = position;

            textMeshProUgui.font = TMP_FontAsset.CreateFontAsset(new Font("Assets/Font/Demeo.ttf"));
            textMeshProUgui.text = text;
            textMeshProUgui.color = Color.black;
            //textMeshProUgui.color = new Color(248, 217, 90);
            textMeshProUgui.alignment = alignment;
            textMeshProUgui.GetComponent<Renderer>().material.shader = Shader.Find("TextMeshPro/Distance Field Overlay");
            textMeshProUgui.GetComponent<Renderer>().sortingOrder = 1;

            gameObject.SetActive(true);

            // I don't know why, but these only works after the game object is active
            textMeshProUgui.fontSize = fontSize;



            return textMeshProUgui;
        }
    }
}
