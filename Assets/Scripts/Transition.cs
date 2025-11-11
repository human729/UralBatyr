using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Transition : MonoBehaviour
{
    public static Transition Instance;

    private GameObject fadeCanvasObject;
    private Image fadeImage;
    private bool isTransitioning = false;

    public float fadeInTime = 1f;
    public float fadeOutTime = 1f;
    public float blackScreenTime = 0.3f;
    private MovementPlayer movementPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CreateFadeCanvas();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TeleportPlayer(Vector3 targetPosition)
    {
        if (!isTransitioning)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                StartCoroutine(TeleportCoroutine(player.transform, targetPosition));
            }
        }
    }

    private IEnumerator TeleportCoroutine(Transform player, Vector3 targetPosition)
    {
        isTransitioning = true;
        movementPlayer = player.GetComponent<MovementPlayer>();
        if (movementPlayer != null) movementPlayer.enabled = false;

        yield return StartCoroutine(Fade(0f, 1f, fadeInTime));
        player.position = targetPosition;

        yield return new WaitForSeconds(blackScreenTime);

        yield return StartCoroutine(Fade(1f, 0f, fadeOutTime));
        if (movementPlayer != null) movementPlayer.enabled = true;

        isTransitioning = false;
    }

    private IEnumerator Fade(float startAlpha, float targetAlpha, float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / duration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, targetAlpha);
    }

    private void CreateFadeCanvas()
    {
        fadeCanvasObject = new GameObject("InSceneFadeCanvas");
        fadeCanvasObject.transform.SetParent(transform);

        Canvas canvas = fadeCanvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 1000;

        GameObject imageObject = new GameObject("FadeImage");
        imageObject.transform.SetParent(fadeCanvasObject.transform);

        fadeImage = imageObject.AddComponent<Image>();
        fadeImage.color = new Color(0, 0, 0, 0);

        RectTransform rect = imageObject.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    public bool IsTransitioning()
    {
        return isTransitioning;
    }
}