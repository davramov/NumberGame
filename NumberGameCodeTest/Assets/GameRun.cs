using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRun : MonoBehaviour
{
    // Initialize Animations and GameObjects (dynamically assigned in UI)
    public RuntimeAnimatorController firstAnim;
    public RuntimeAnimatorController secondAnim;
    public RuntimeAnimatorController wrongAnswerAnim;
    public RuntimeAnimatorController correctAnswerAnim;
    public GameObject gameObj;

    public Image[] answerImg;
    public Sprite[] answerSprite;
    public Image questionImg;

    public Sprite nextArrowInactiveSprite;
    public Sprite nextArrowActiveSprite;
    public Button nextBtn;

    public static int questionIndex;
    string actionSpriteName;
    public Text answerText;

    public Sprite correctResponse;
    public Sprite incorrectResponse;
    public Image responseImage;

    public AudioSource correctSound;
    public AudioSource incorrectSound;

    // Start is called before the first frame update
    void Start()
    {
        responseImage.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        questionIndex = 1;
        nextBtn.interactable = false;
        nextBtn.GetComponent<Image>().sprite = nextArrowInactiveSprite;
        gameObj.GetComponent<Animator>().runtimeAnimatorController = firstAnim;
        setSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextButton()
    {
        answerText.text = "";
        responseImage.GetComponent<Image>().sprite = null;
        responseImage.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        if (questionIndex < 9)
        {
            ++questionIndex;

        }
        else
        {
            questionIndex = 1;
        }

        // Set second animation
        gameObj.GetComponent<Animator>().runtimeAnimatorController = secondAnim;
        StartCoroutine(startAnimation());
    }

    // Set animation again
    public IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        gameObj.GetComponent<Animator>().runtimeAnimatorController = firstAnim;
        setSprite();
        answerText.text = "";
        nextBtn.interactable = false;
        nextBtn.GetComponent<Image>().sprite = nextArrowInactiveSprite;
        responseImage.GetComponent<Image>().sprite = null;
        responseImage.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);


    }

    public void setSprite()
    {
        // Set sprite to question
        questionImg.GetComponent<Image>().sprite = answerSprite[questionIndex - 1];
        for (int i = 0; i < 9; i++)
        {
            answerImg[i].GetComponent<Image>().sprite = answerSprite[i];
            answerImg[i].GetComponent<Animator>().runtimeAnimatorController = null;
        }
    }

    public void correctAnswer()
    {
        // Set question image sprite name
        string questionName = questionImg.sprite.name;
        if(questionName.Equals(actionSpriteName))
        {
            answerText.text = "Correct Answer!";
            answerImg[questionIndex-1].GetComponent<Animator>().runtimeAnimatorController = correctAnswerAnim;
            nextBtn.interactable = true;
            nextBtn.GetComponent<Image>().sprite = nextArrowActiveSprite;
            correctSound.Play();
            responseImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            responseImage.GetComponent<Image>().sprite = correctResponse;

        }
        else
        {
            answerText.text = "Wrong Answer!";
            incorrectSound.Play();
            responseImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            responseImage.GetComponent<Image>().sprite = incorrectResponse;
        }
    }


    public void answerSpriteAction(Image image)
    {
        // Answer button actions
        actionSpriteName = image.sprite.name;
        image.GetComponent<Animator>().runtimeAnimatorController = wrongAnswerAnim;
        correctAnswer();

    }

    public void closeButton()
    {
        SceneManager.LoadScene(0);
    }
}
