using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    private TextMeshProUGUI tutorialTips;

    bool thirdTutorialTip = false;
    //bool lmbClicked = false;
    bool rmbClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorialTips = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(TutorialTipDelay1());
        
    }

    void Update()
    {
        if (thirdTutorialTip == true && Input.GetMouseButtonDown(1))
        {
            StartCoroutine(TutorialTipDelay2());
        }

        if (rmbClicked == true && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TutorialTipDelay3());
        }
    }

    void FirstTutorialTip()
    {
        tutorialTips.text = "Welcome to your home!";
    }

    void SecondTutorialTip()
    {
        tutorialTips.text = "Pesky businessmen have moved in uninvited, \nand turned your abode into the \"Good Night Hotel\"";
    }

    void ThirdTutorialTip()
    {   
        thirdTutorialTip = true;
        tutorialTips.text = "As a ghost, you can look around using the RMB...";
    }

    void SixthTutorialTip()
    {
        tutorialTips.text = "At night and to survive, prevent them from sleeping \nand hopefully they'll leave for good!";
        Invoke("LoadMainLevel", 10f);
    }

    private void LoadMainLevel()
    {
        SceneManager.LoadScene(1);
    }

    // void SeventhTutorialTip()
    // {
    //     tutorialTips.text = "Oh look! Here comes our first victim!";
    // }

    private IEnumerator TutorialTipDelay1()
    {
        yield return new WaitForSeconds(1f);
        FirstTutorialTip();
        yield return new WaitForSeconds(5f);
        SecondTutorialTip();
        yield return new WaitForSeconds(8f);
        ThirdTutorialTip();
        // yield return new WaitForSeconds(5f);
        // FourthTutorialTip();
        // yield return new WaitForSeconds(3f);
        // SixthTutorialTip();
        // yield return new WaitForSeconds(3f);
    }

    private IEnumerator TutorialTipDelay2()
    {   
        yield return new WaitForSeconds(3f);
        tutorialTips.text = "...and move around using the LMB";
        thirdTutorialTip = false;
        rmbClicked = true;
    }

    private IEnumerator TutorialTipDelay3()
    {   rmbClicked = false;
        yield return new WaitForSeconds(3f);
        tutorialTips.text = "Great! Lets give the guests a scare just before they fall asleep \nby interacting with them or with objects using the LMB, when they are near";
        yield return new WaitForSeconds(8f);
        tutorialTips.text = "Watch for the meter above their head to know when they are going to sleep!";
        yield return new WaitForSeconds(8f);
        tutorialTips.text = " ";
        yield return new WaitForSeconds(5f);
        SixthTutorialTip();
        yield return new WaitForSeconds(8f);
        tutorialTips.text = " ";
    }
}
