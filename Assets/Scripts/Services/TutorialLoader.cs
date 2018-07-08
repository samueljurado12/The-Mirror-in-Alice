using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLoader : MonoBehaviour {

    [SerializeField]
    private LevelManager levelManager;

    [SerializeField]
    private Animator animator;

    public void loadCoopTutorial()
    {
        
        levelManager.LoadScene("02a_CoopTutorial");
    }

    public void loadVsTutorial()
    {
        levelManager.LoadScene("02b_VsTutorial");
    }

    public void loadEndlessTutorial()
    {
        levelManager.LoadScene("02c_EndlessTutorial");
    }

    public void fadeOutCanvas() {
        animator.Play("FadeOut");
    }
}
