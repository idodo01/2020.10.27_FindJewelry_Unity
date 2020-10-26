using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text 사용하기 때문에

public class ClickScript : MonoBehaviour
{

    int clickCount;
    private int level01_Count;
    private int level02_Count;
    private int level03_Count;
    private int level04_Count;
    private int ending_Count;

    public GameObject level00_Background;
    public GameObject level01_Background;
    public GameObject level02_Background;
    public GameObject level03_Background;
    public GameObject level04_Background;
    public GameObject ending_Background;

    public Text score;
    public GameObject scoreObject;

    public GameObject pick01;
    public GameObject pick02;

    public GameObject endingText01;
    public GameObject endingText02;

    public GameObject playButton;
    public GameObject replayButton;

    public GameObject DiamondImg;

    void Start()
    {
        level01_Count = 10;
        level02_Count = 20;
        level03_Count = 30;
        level04_Count = 40;
        ending_Count = 50;

        score.text = "0";
    }

    void Update()
    {

    }

    public void clickMethod()
    {
        //Debug.Log("Click!!");
        clickCount++;
        score.text = clickCount.ToString();
        Debug.Log("clickCount: " + clickCount);

        // 클릭 수에 따른 곡갱이 이미지 변화
        // 짝수일 때
        if (clickCount % 2 == 0)
        {
            pick01.SetActive(true);
            pick02.SetActive(false);
        }
        else
        { // 홀수일 때
            pick02.SetActive(true);
            pick01.SetActive(false);
        }



        // 클릭 수에 따른 배경 변화
        if (clickCount == level01_Count)
        {
            level01_Background.SetActive(true);
            level00_Background.SetActive(false);
        }
        else if (clickCount == level02_Count)
        {
            level02_Background.SetActive(true);
            level01_Background.SetActive(false);
        }
        else if (clickCount == level03_Count)
        {
            level03_Background.SetActive(true);
            level02_Background.SetActive(false);
        }
        else if (clickCount == level04_Count)
        {
            level04_Background.SetActive(true);
            level03_Background.SetActive(false);
        }
        else if (clickCount == ending_Count) // 엔딩
        {
            // 엔딩 화면 요소 ture
            ending_Background.SetActive(true);
            endingText01.SetActive(true);
            endingText02.SetActive(true);
            replayButton.SetActive(true);
            DiamondImg.SetActive(true);

            // level4 화면 요소 false
            level04_Background.SetActive(false);
            scoreObject.SetActive(false);
            playButton.SetActive(false);
            pick01.SetActive(false);
            pick02.SetActive(false);
        }

    }

    public void replayMethod()
    {
        score.text = "0";
        clickCount = 0;
        score.text = clickCount.ToString();
        
        // 엔딩 화면 요소 false
        ending_Background.SetActive(false);
        endingText01.SetActive(false);
        endingText02.SetActive(false);
        replayButton.SetActive(false);
        DiamondImg.SetActive(false);

        // level1 화면 요소 true
        level01_Background.SetActive(true);
        scoreObject.SetActive(true);
        playButton.SetActive(true);
        pick01.SetActive(true);
    }
}
