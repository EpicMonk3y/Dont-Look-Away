using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;


    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() 
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
