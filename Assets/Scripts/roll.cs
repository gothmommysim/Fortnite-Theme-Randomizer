using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class roll : MonoBehaviour
{
    string themesList = @"Red
Orange
Yellow
Green
Blue
Purple
Pink
White
Black
Gold
Silver
Gay
Straight
Bi
Transfem
Transmasc
Enby
Ace
Boomers
Gen Z
Millennials
Girl Boss
Animals
Foods
Music
Jocks
Preps
Goths
Emos
Republicans
Chaotic
Bruh Girls
Mysterious
Twinks
Celebrities
Bears
Doms
Subs
Switches
Business Majors
Cucks
Holiday
Bitches
Moms
Dads
Pajamas
Mascots
Met Gala
Blue Collar
Virgins
Tide Pod Eaters
Aliens
Monsters
Pups
Feet
Sparkles
Chrome
Bootycore
Slimecore
Golden Retriever Energy
Clown
Cam Girls
Butches
Boots";

    public static List<string> themes = new List<string>();
    [SerializeField] TextMeshProUGUI themeField;
    public Button rollButton;

    // Start is called before the first frame update
    void Start()
    {
        ListFromFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ListFromFile()
    {
        //StartCoroutine(GetText());
        GetText();
    }

    public void RollTheme()
    {
        rollButton.GetComponent<Button>().interactable = false;
        //Debug.Log(rollButton.IsInteractable());

        int randomVar = Random.Range(0, themes.Count);
        //Debug.Log(randomVar);

        StartCoroutine(RollAnimation(randomVar));

        //themes.Count

    }

    IEnumerator RollAnimation(int randomVar)
    {
        float time = 0.05f;
        for (int i = 0; i < themes.Count; i++)
        {
            yield return new WaitForSeconds(time);
            themeField.text = themes[Random.Range(0, themes.Count)];
            themeField.color = Random.ColorHSV(0,1,1,1,1,1);
            time += 0.009f*Mathf.Exp(-1);
            //Debug.Log(themeField.text);
        }
        themeField.text = themes[randomVar];
        themeField.color = Color.white;
        

        rollButton.GetComponent<Button>().interactable = true;
        //Debug.Log(rollButton.IsInteractable());
    }

    //IEnumerator GetText()
    void GetText()
    {
        //UnityWebRequest www = UnityWebRequest.Get("https://cdn.discordapp.com/attachments/1044393551699644466/1044393576961953832/Themes.list");
        //yield return www.SendWebRequest();

        // Show results as text
        string importText;
        //importText = www.downloadHandler.text;
        importText = themesList;

        //StringReader reader = new StringReader(www.downloadHandler.text);
        StringReader reader = new StringReader(themesList);

        while (reader.Peek() >= 0)
        {
            themes.Add(reader.ReadLine());
        }

        reader.Close();
    }

}
