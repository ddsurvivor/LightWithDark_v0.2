using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public string type;
    public int score;

    //public Text scoreText;

    [SerializeField]
    Sprite darkSmall;
    [SerializeField]
    Sprite darkMid;
    [SerializeField]
    Sprite darkLarge;
    [SerializeField]
    Sprite lightSmall;
    [SerializeField]
    Sprite lightMid;
    [SerializeField]
    Sprite lightLarge;


    // Start is called before the first frame update
    void Start()
    {
        if (score < 0)
        {
            //scoreText.text = score.ToString();
            if (score == -2)
            {
                GetComponent<SpriteRenderer>().sprite = darkSmall;

            }
            else if (score == -3)
            {
                GetComponent<SpriteRenderer>().sprite = darkMid;
            }
            else if (score == -5)
            {
                // Color nowColor;
                // ColorUtility.TryParseHtmlString("#C98DFF", out nowColor);
                //GetComponent<SpriteRenderer>().color = nowColor;
                GetComponent<SpriteRenderer>().sprite = darkLarge;
            }
        }

        else if (score > 0)
        {
            //scoreText.text = "+" + score.ToString();
            if (score == 1)
            {
                GetComponent<SpriteRenderer>().sprite = lightSmall;

            }
            else if (score == 3)
            {
                GetComponent<SpriteRenderer>().sprite = lightMid;
            }
            else if (score == 6)
            {
                // Color nowColor;
                // ColorUtility.TryParseHtmlString("#C98DFF", out nowColor);
                //GetComponent<SpriteRenderer>().color = nowColor;
                GetComponent<SpriteRenderer>().sprite = lightLarge;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
