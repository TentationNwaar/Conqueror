using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public GameObject mainMenu;
    public Canvas difficulties;

    private void Awake()
    {
        //Time.timeScale = 1f;
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Start");
        Invoke("FadeToNextLevel", 0.2f);
    }

    public void FadeToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void NextToExit()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene("S_Level01");
    }

}
