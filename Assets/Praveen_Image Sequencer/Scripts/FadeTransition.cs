using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    public Image image;

    [SerializeField] private float speed = 2;

    private Color tempColor;
    private bool isStarted;

    public bool IsFadeInComplete { get; private set; }
    public bool IsFadeOutComplete { get; private set; }

    private void Start()
    {
        image.gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        if (isStarted) return;
        isStarted = true;
        StartCoroutine(C_StartFadeIn());
    }

    public void FadeOut()
    {
        if (isStarted) return;
        isStarted = true;
        StartCoroutine(C_StartFadeOut());
    }

    private IEnumerator C_StartFadeOut()
    {
        IsFadeOutComplete = false;
        tempColor = image.color;
        tempColor.a = 1;
        image.color = tempColor;
        image.gameObject.SetActive(true);

        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime * speed;
            image.color = tempColor;
            yield return null;
        }

        isStarted = false;
        tempColor.a = 0f;
        image.color = tempColor;
        IsFadeOutComplete = true;
        image.gameObject.SetActive(false);
    }

    public IEnumerator C_StartFadeIn()
    {
        IsFadeInComplete = false;
        tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;
        image.gameObject.SetActive(true);

        while (tempColor.a < 1.0f)
        {
            tempColor.a += Time.deltaTime * speed;
            image.color = tempColor;
            yield return null;
        }

        isStarted = false;
        tempColor.a = 1.0f;
        image.color = tempColor;
        IsFadeInComplete = true;
        image.gameObject.SetActive(false);
    }
}
