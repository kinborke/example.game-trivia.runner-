using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;


public class Json : MonoBehaviour
{
    public List<General> quest;
    public List<TextMeshProUGUI> soruText;

    List<string> result;
    General zart;
    bool z = false;

    public class General
    {
        public string question;
        public string option1;
        public string option2;
        public bool answerOne;
        public bool answerTwo;
    }



    void Start()
    {

        quest = new List<General>();
        QuestionAdd("WHICH ONE IS THE BIGGEST", "WHALES", "FISH", true, false);
        QuestionAdd("WHICH ONE IS THE SMALLEST", "ANT", "CAT", true, false);
        QuestionAdd("WHICH ONE IS THE MORE TERRIBLE", "BIRD", "LION", false, true);
        QuestionAdd("WHICH ONE IS THE SWEETEST", "DOG", "FROG", true, false);
        QuestionAdd("WHICH ONE IS THE OLDER", "MESSI", "PELE", false, true);
        result = new List<string>();
        Questions questions = new Questions();
        generate();

    }



    void QuestionAdd(string question, string option1, string option2, bool answer1, bool answer2)
    {
        General general = new General()
        {
            question = question,
            option1 = option1,
            option2 = option2,
            answerOne = answer1,
            answerTwo = answer2
        };
        quest.Add(general);

    }


    public void generate()
    {
        foreach (var item in soruText)
        {
            do
            {
                zart = quest[Random.Range(0, quest.Count)];

                if (!result.Any(x => x == zart.question))
                {
                    item.text = zart.question;

                    result.Add(zart.question);
                    item.transform.parent.parent.GetChild(1).GetComponent<TrueFalse>().answer = zart.answerOne;
                    item.transform.parent.parent.GetChild(2).GetComponent<TrueFalse>().answer = zart.answerTwo;
                    item.transform.parent.parent.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = zart.option1;
                    item.transform.parent.parent.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = zart.option2;
                    break;
                }
            } while (result.Any(x => x == zart.question));


            //do
            //{
            //    zart = quest[Random.Range(0, quest.Count)];

            //    if (result.Any(x => x == zart))
            //    {
            //        // item.text = zart;
            //        z = false;
            //        // result.Add(quest[Random.Range(0, quest.Count)]);


            //    }
            //    else
            //    {
            //        z = true;

            //    }
            //} while (z == false/*result.Any(x =>x==zart)==true*/) ;
            //if(z==true)
            //{
            //    result.Add(zart);
            //    item.text = zart;
            //    z = false;

            //}

            //   }







        }
    }
}