using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class abstractUIPanel : MonoBehaviour
{
    [Header("Panel Settings")]
    [SerializeField] private string panelName;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private bool useFadeEffect = true;//是否使用淡入淡出效果
    [SerializeField] private float fadeDuration = 0.3f;//淡入淡出时间

    private bool isInitialized = false;
    public string PanelName => panelName;

    public virtual void Awake()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }
    public virtual void Open()
    {
        if (!isInitialized)
        {
            Initialize();
            isInitialized = true;
        }
        gameObject.SetActive(true);
        if (useFadeEffect && canvasGroup != null) StartCoroutine(FadeIn());
        Refresh();
    }
    public virtual void Close()
    {
        if (useFadeEffect && canvasGroup != null)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual void Initialize() { }

    public abstract void Refresh();

    private System.Collections.IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0f;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Clamp01(timer / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
    private System.Collections.IEnumerator FadeOut()
    {
        canvasGroup.alpha = 1f;
        float timer = 0f;
        
        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;
            canvasGroup.alpha = 1f - Mathf.Clamp01(timer / fadeDuration);
            yield return null;
        }
        
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }
}
