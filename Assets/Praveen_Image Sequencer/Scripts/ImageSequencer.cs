using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageSequencer : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private FadeTransition fadeTransition;
    [SerializeField] private Image image;
    [SerializeField] private float waitTime;

    [SerializeField] private GameObject playerObject;

    private bool IsChanging;
    private int temp;

    private void OnEnable()
    {
        StartSequence();
    }

    public void StartSequence()
    {
        if (IsChanging) return;
        temp = 0;
        IsChanging = true;
        playerObject.SetActive(false);
        StartCoroutine(OnEnablingObject());
    }

    private IEnumerator OnEnablingObject()
    {
        fadeTransition.FadeIn();
        yield return new WaitUntil(() => fadeTransition.IsFadeInComplete);
        StartCoroutine(C_StartSequence());
    }


    private IEnumerator C_StartSequence()
    {
        // sequence images
        for (int i = 0; i < sprites.Length; i++)
        {
            if (temp + 1 > sprites.Length - 1) break;

            // set current image
            image.sprite = sprites[i];

            // wait to change next image
            yield return new WaitForSeconds(waitTime);

            // fadein 
            fadeTransition.FadeIn();
            yield return new WaitUntil(() => fadeTransition.IsFadeInComplete);

            // choose next image
            temp++;
            image.sprite = sprites[temp];

            // fadeout
            fadeTransition.FadeOut();
            yield return new WaitUntil(() => fadeTransition.IsFadeOutComplete);
        }

        // sequence complete
        IsChanging = false;
        playerObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
