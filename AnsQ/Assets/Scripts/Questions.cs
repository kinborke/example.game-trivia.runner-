using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Questions : MonoBehaviour
{
    string path;
    string jsonString;


}


public class Question
{
    public string no;
    public string question;
    public string[] options;
    public string answer;

}

public class QuestionList
{
    public Question[] questions;
    
}