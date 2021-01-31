using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int playerEnergy;
    public int EnergyMax;


    public Image playerCountLight;
    public Image playerCountDark;
    //public Text playerCountText;

    // 通关标志，需要通关后才能通过出口
    public bool levelClear;

    public List<GameObject> hitEnemy;

    public GameObject darkImage;
    public GameObject lightImage;
    public GameObject restart;

    public GameObject BGM;
    public GameObject win;



    // Start is called before the first frame update
    void Start()
    {
        ShowPlayerData();
        hitEnemy = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerLight > playerLightMax)
        //{
        //    playerLight = playerLightMax;
        //}
        //if (playerDark > playerDarkMax)
        //{
        //    playerDark = playerDarkMax;
        //}


        //LightCount.fillAmount = (float)playerLight / playerLightMax;
        //DarkCount.fillAmount = (float)playerDark / playerDarkMax;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hit");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            playerEnergy -= enemy.score;
            //Destroy(collision.gameObject);
            hitEnemy.Add(collision.gameObject);
            collision.gameObject.SetActive(false);
            ShowPlayerData();
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            if (playerEnergy == 0)
            {
                Debug.Log("You Win!");
                levelClear = true;
                collision.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("You Loss! Not balance");
                GetComponentInParent<PlayerController>().playerIndex--;
            }
        }
        else if (collision.gameObject.CompareTag("Exit"))
        {
            if (levelClear)
            {
                Debug.Log("Free to go");
                win.SetActive(true);
                GetComponentInParent<PlayerController>().moveable = false;
            }
            else
            {
                Debug.Log("Keep back");
                GetComponentInParent<PlayerController>().playerIndex--;
            }
        }
        if (playerEnergy >= EnergyMax)
        {
            //Debug.Log("You Loss! Full of energy");
            BGM.SetActive(false);
            lightImage.SetActive(true);
            GetComponentInParent<PlayerController>().moveable = false;
            restart.SetActive(true);
        }
        else if (playerEnergy <= -EnergyMax)
        {
            BGM.SetActive(false);
            darkImage.SetActive(true);
            GetComponentInParent<PlayerController>().moveable = false;
            restart.SetActive(true);
        }
    }

    private void ShowPlayerData()
    {
        if (playerEnergy < 0)
        {
            //playerCountText.text = playerEnergy.ToString();
            playerCountDark.fillAmount = (float)(-playerEnergy) / EnergyMax;
            playerCountLight.fillAmount = 0.0f;
        }
        else if (playerEnergy > 0)
        {
            playerCountDark.fillAmount = 0.0f;
            playerCountLight.fillAmount = (float)(playerEnergy) / EnergyMax;
            //playerCountText.text = "+" + playerEnergy.ToString();
        }
        else
        {
            playerCountDark.fillAmount = 0.0f;
            playerCountLight.fillAmount = 0.0f;
        }

        //playerCountLight.fillAmount = (float)(playerEnergy + EnergyMax) / (2 * EnergyMax);
    }
}
