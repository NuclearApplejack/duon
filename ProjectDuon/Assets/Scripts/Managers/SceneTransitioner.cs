using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitioner : MonoBehaviour {

    GameObject targetEffectHolder;
    GameObject loadingUI;
    Text loadingTip;
    float preSceneTimer = 0f;
    string sceneName = "";
    Color color = Color.black;
    Color currColor = new Color(1, 1, 1, 0);
    public bool transitioning = false;

    float initialTimer = 1f;

    

    void Start()
    {
        
        targetEffectHolder = GameObject.Find("ScreenEffect");
        loadingUI = GameObject.Find("LoadingUI");
        loadingTip = GameObject.Find("LoadingTip").GetComponent<Text>();
        loadingTip.text = LoadingTipsHolder.currTip;
        //loadingUI.SetActive(false);
        //targetEffectHolder.GetComponent<Image>().color = Color.black;


    }

    void Update()
    {
        loadingTip.text = LoadingTipsHolder.currTip;

        if (initialTimer > 0f)
        {
            initialTimer -= Time.deltaTime;
            currColor = new Color(color.r, color.g, color.b, Mathf.Min(initialTimer, 0.5f) / 0.5f);
            //targetEffectHolder.GetComponent<Image>().color = currColor;
            loadingUI.GetComponent<CanvasGroup>().alpha = currColor.a;
        }
        else
        {
            //targetEffectHolder.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (transitioning)
        {
            //loadingUI.SetActive(true);
            preSceneTimer += Time.deltaTime;

            currColor = new Color(color.r, color.g, color.b, preSceneTimer / 0.5f);
            //targetEffectHolder.GetComponent<Image>().color = currColor;

            loadingUI.GetComponent<CanvasGroup>().alpha = currColor.a;

            if (preSceneTimer >= 0.5f)
            {
                StartCoroutine(LoadScene());
            }
        }
    }

    IEnumerator LoadScene()
    {

        yield return new WaitForSeconds(3f);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            yield return null;
        }

    }

    public void TransitionWithFade(string sceneName, Color color)
    {
        if (!transitioning)
        {
            this.sceneName = sceneName;
            this.color = color;
            transitioning = true;
            LoadingTipsHolder.GenerateNewTip();
        }
    }

    public void TransitionInstantlyWithFadeIn(string sceneName)
    {
        loadingUI.GetComponent<CanvasGroup>().alpha = 1f;
        this.sceneName = sceneName;
        StartCoroutine(LoadScene());
    }
	
}
