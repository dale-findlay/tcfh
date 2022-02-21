using UnityEngine;

public abstract class LevelScript : MonoBehaviour
{
    public static LevelScript levelScript;

    public delegate void LevelLoad();
    public event LevelLoad levelLoad;

    public delegate void LevelEnd();
    public event LevelLoad levelEnd;

    public GameObject gameUI;
    public GameObject fadeCanvas;

    public void OnLevelLoad()
    {
        LevelFadeIn levelFadeIn = fadeCanvas.GetComponent<LevelFadeIn>();
        if(levelFadeIn)
        {
            levelFadeIn.start = true;
        }
        else
        {
            Debug.Log("Failed to start fade.");
        }
        ExecuteLevelLoad();
    }

    public void OnLevelEnd()
    {
        //Start LevelFadeOut.
        LevelFadeOut levelFadeOut = fadeCanvas.GetComponent<LevelFadeOut>();
        levelFadeOut.start = true;
        levelFadeOut.fadeComplete += ExecuteLevelEnd;
    }
    private void ExecuteLevelLoad()
    {
        if(levelLoad != null)
        {
            levelLoad();
        }
    }
    private void ExecuteLevelEnd()
    {
        if (levelEnd != null)
        {
            levelEnd();
        }
    }

    void Start()
    {
        levelLoad();
    }

    protected void AwakeScript()
    {
        if (levelScript)
        {
            DestroyImmediate(this);
        }
        else
        {
            levelScript = this;
        }

        //Ensure that the fade canvas.
        fadeCanvas.SetActive(true);

        //ensure that the game's UI is enabled.
        gameUI.SetActive(true);
    }
}