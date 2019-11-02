using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour {

    public int state = 0;
    float currBtnAlpha = 0f;

    float particleTimer = 0f;

    bool alphaSetOff = false;
    float alphaTimer = 0f;

    bool loadingAdded = false;
    public GameObject canvas;

    float bgmvolume = 1f;

    public int selectedOption = 0;
    public GameObject leftSelector;
    public GameObject rightSelector;
    public GameObject buttonsPanel;
    public GameObject particleCanvas;
    public GameObject silhouettes;
    public Image creditsImage;

    Vector3 leftFinalPos = new Vector3(-55.5f, -18, 0);
    Vector3 rightFinalPos = new Vector3(55.5f, -18, 0);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 0 || state == 1)
        {
            #region pre
            if (alphaSetOff && currBtnAlpha < 1f)
            {
                currBtnAlpha += Time.deltaTime;
                if (currBtnAlpha >= 0.1f)
                {
                    state = 1;
                }
                if (currBtnAlpha >= 1f)
                {
                    currBtnAlpha = 1f;
                    
                    silhouettes.SetActive(true);
                }
            }
            
            foreach (Transform gObject in buttonsPanel.transform)
            {
                gObject.GetComponent<Image>().color = new Color(1, 1, 1, currBtnAlpha);
            }

            #endregion
        }
        if (state == 1)
        {
            #region default

            if (!loadingAdded)
            {
                loadingAdded = true;
                canvas.GetComponent<Canvas>().sortingOrder = 5;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                if (selectedOption == 0)
                {
                    //SceneManager.LoadScene("StoryIntro");
                    GetComponent<SceneTransitioner>().TransitionWithFade("StoryIntro", Color.black);
                    InventoryHolder.AddItems();
                    GlobalHolder.stage1Complete = false;
                    GlobalHolder.stage1Checkpoint = false;
                    GlobalHolder.hollowAlphaSeen = false;
                    GlobalHolder.mainLabTipsSeen = false;
                    state = 3;
                }
                else if (selectedOption == 1)
                {
                    state = 2;
                }
                else if (selectedOption == 2)
                {
                    Application.Quit();
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedOption++;
                selectedOption = selectedOption % 3;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selectedOption == 0)
                {
                    selectedOption = 2;
                }
                else
                {
                    selectedOption--;
                }

            }

            if (selectedOption == 0)
            {
                leftFinalPos = new Vector3(-55.5f, -18, 0);
                rightFinalPos = new Vector3(55.5f, -18, 0);
            }
            else if (selectedOption == 1)
            {
                leftFinalPos = new Vector3(-47.5f, -106, 0);
                rightFinalPos = new Vector3(47.5f, -106, 0);
            }
            else
            {
                leftFinalPos = new Vector3(-43.5f, -150, 0);
                rightFinalPos = new Vector3(43.5f, -150, 0);
            }

            leftSelector.transform.localPosition += (leftFinalPos - leftSelector.transform.localPosition) / 2f;
            rightSelector.transform.localPosition += (rightFinalPos - rightSelector.transform.localPosition) / 2f;

            if (particleTimer >= 0.2f)
            {
                particleTimer = 0f;
                GameObject particle = Instantiate(Resources.Load<GameObject>("Prefabs/TitleParticle"));
                particle.transform.SetParent(particleCanvas.transform);
                particle.transform.localPosition = new Vector3(Random.Range(-320f, 320f), 200, 0);
            }
            else
            {
                particleTimer += Time.deltaTime;
            }

            if (creditsImage.color.a > 0f)
            {
                creditsImage.color = new Color(1, 1, 1, Mathf.Max(creditsImage.color.a - Time.deltaTime * 2f, 0f));
            }
            #endregion
        }
        else if (state == 2)
        {
            #region credits

            if (creditsImage.color.a < 1f)
            {
                creditsImage.color = new Color(1, 1, 1, Mathf.Min(creditsImage.color.a + Time.deltaTime * 2f, 1f));
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            {
                state = 1;
            }

                #endregion
            }
        else if (state == 3)
        {
            #region transitioning

            bgmvolume -= Time.deltaTime / 2f;
            GetComponent<AudioSource>().volume = bgmvolume;

            if (creditsImage.color.a > 0f)
            {
                creditsImage.color = new Color(1, 1, 1, Mathf.Max(creditsImage.color.a - Time.deltaTime, 0f));
            }
            #endregion
        }
    }

    public void SetOffAlpha()
    {
        alphaSetOff = true;
    }

    
}
