using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text 사용하기 때문에

public class ClickScript : MonoBehaviour
{

    int clickCount;
    private int level01_Count; // 레벨1 달성 목표치
    private int level02_Count; // 레벨2 달성 목표치 
    private int level03_Count; // 레벨3 달성 목표치
    private int level04_Count; // 레벨4 달성 목표치
    private int ending_Count; // 엔딩 달성 목표치

    public GameObject level00_Background; // 첫 시작 배경
    public GameObject level01_Background; // 레벨1 달성되었을 때 배경
    public GameObject level02_Background; // 레벨2 달성되었을 때 배경
    public GameObject level03_Background; // 레벨3 달성되었을 때 배경
    public GameObject level04_Background; // 레벨4 달성되었을 때 배경
    public GameObject ending_Background; // 엔딩 배경

    // 점수 
    public Text score;
    public GameObject scoreObject; 

    public GameObject pick01; // 곡갱이 이미지01
    public GameObject pick02; // 곡갱이 이미지02

    // 엔딩시 출력 텍스트 
    public GameObject endingText01;
    public GameObject endingText02;

    // 버튼
    public GameObject playButton; // 곡갱이질 버튼
    public GameObject replayButton; // 다시 게임 버튼

    public GameObject DiamondImg; // 엔딩시 나오는 다이아몬드 이미지

    void Start()
    {
        level01_Count = 10; // 정의해놓은 level01_Count 변수 값 설정
        // 즉, 10으로 해두면, 카운트가 10이 되면 1레벨 달성됨
        level02_Count = 20; // 정의해놓은 level02_Count 변수 값 설정
        level03_Count = 30; // 정의해놓은 level03_Count 변수 값 설정
        level04_Count = 40; // 정의해놓은 level04_Count 변수 값 설정
        ending_Count = 50; // 정의해놓은 ending_Count 변수 값 설정

        score.text = "0";
    }

    void Update()
    {

    }

    public void clickMethod()
    {
        //Debug.Log("Click!!");
        clickCount++; // clickCount = clickCount + 1; // 클릭 카운트 올리기
        score.text = clickCount.ToString();  // clickCount의 값을 score에 삽입
        //Debug.Log("clickCount: " + clickCount); // Debug.Log : 개발자 확인 가능 텍스트

        // 클릭 수에 따른 곡갱이 이미지 변화
        // 짝수일 때
        if (clickCount % 2 == 0)
        {
            pick01.SetActive(true); // 클릭수가 짝수일 때, pick01 곡갱이 이미지 나오도록
            pick02.SetActive(false); // pick02 곡갱이 이미지는 안보이도록
        }
        else
        { // 홀수일 때
            pick02.SetActive(true); // 클릭수가 홀수일 때, pick02 곡갱이 이미지 나오도록
            pick01.SetActive(false);  // pick01 곡갱이 이미지는 안보이도록
        }



        // 클릭 수에 따른 배경 변화
        if (clickCount == level01_Count) // clickCount가 레벨1 목표치를 달성했을 때
        {
            level01_Background.SetActive(true); // 레벨1 배경 나오도록
            level00_Background.SetActive(false);
        }
        else if (clickCount == level02_Count) // clickCount가 레벨2 목표치를 달성했을 때
        {
            level02_Background.SetActive(true); // 레벨2 배경 나오도록
            level01_Background.SetActive(false);
        }
        else if (clickCount == level03_Count) // clickCount가 레벨3 목표치를 달성했을 때
        {
            level03_Background.SetActive(true); // 레벨3 배경 나오도록
            level02_Background.SetActive(false);
        }
        else if (clickCount == level04_Count) // clickCount가 레벨4 목표치를 달성했을 때
        {
            level04_Background.SetActive(true); // 레벨4 배경 나오도록
            level03_Background.SetActive(false);
        }
        else if (clickCount == ending_Count) // 엔딩
        {
            // 엔딩시 필요한 요소 보이도록 설정
            // 엔딩 화면 요소 ture
            ending_Background.SetActive(true); // 배경
            endingText01.SetActive(true); // 텍스트 
            endingText02.SetActive(true); // 텍스트
            replayButton.SetActive(true); // 다시하기 버튼
            DiamondImg.SetActive(true); // 다이아몬드 이미지

            // 레벨4까지 사용된 화면 요소 안보이도록 설정
            // level4 화면 요소 false
            level04_Background.SetActive(false); // 레벨4 배경 이미지
            scoreObject.SetActive(false); // 점수
            playButton.SetActive(false); // 곡갱이질 버튼
            pick01.SetActive(false); // 곡갱이 이미지 01
            pick02.SetActive(false); // 곡갱이 이미지 02
        }

    }

    // 다시하기 버튼 눌렀을 때, 실행될 부분
    public void replayMethod()
    {
        score.text = "0"; // 점수 초기화
        clickCount = 0; // 카운트 초기화
        score.text = clickCount.ToString(); // 초기화된 점수 적용
        
        // 엔딩시 사용된 요소들 모두 안보이도록
        // 엔딩 화면 요소 false
        ending_Background.SetActive(false); 
        endingText01.SetActive(false);
        endingText02.SetActive(false);
        replayButton.SetActive(false);
        DiamondImg.SetActive(false);

        // 다시 레벨1부터 실행하기 위해서 
        // 사용될 요소들 보이도록
        // level1 화면 요소 true
        level01_Background.SetActive(true);
        scoreObject.SetActive(true);
        playButton.SetActive(true);
        pick01.SetActive(true);
    }
}
