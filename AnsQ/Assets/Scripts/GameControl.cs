using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class GameControl : MonoBehaviour
{
    //    string path;
    //    string jsonString;
    //    public Questions question;
    //    public QuestionList questionlist;
    //    public string quest;
    //    public int questionNumber = 0;
    //    public TextMeshProUGUI questionText1;
    //    public TextMeshProUGUI questionText2;
    //    public TextMeshProUGUI questionText3;
    //    public TextMeshProUGUI questionText4;
    //    public TextMeshProUGUI questionText5;



    //    private void Start()
    //    {
    //        StartCoroutine(ReadQuestions(0));
    //        GetQuestion(0);

    //    }


    //    private string LoadStreamingAsset(string fileName)
    //    {
    //        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

    //        string result;

    //        if (filePath.Contains("://") || filePath.Contains(":///"))
    //        {
    //            WWW www = new WWW(filePath);
    //            result = www.text;
    //        }
    //        else
    //        {
    //            result = System.IO.File.ReadAllText(filePath);
    //        }
    //        return result;
    //    }


    //    public IEnumerator ReadQuestions(int sira)
    //    {

    //        jsonString = LoadStreamingAsset("questions2.json");
    //        yield return new WaitForSeconds(1);

    //        Debug.Log(jsonString);
    //        questionlist = JsonUtility.FromJson<QuestionList>(jsonString);

    //        questionNumber = PlayerPrefs.GetInt("QuestionNumber", 0);
    //        Debug.Log(questionNumber);
    //        GetQuestion(0);
    //    }

    //    public void GetQuestion(int sira)
    //    {
    //        quest = questionlist.questions[0].question;

    //        questionText1.text = quest;


    //    }




}

