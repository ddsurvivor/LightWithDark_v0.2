using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Rings;
    public PlayerController PlayerController;
    //public GameObject player;

    //private int playerIndex;
    // 圆环的旋转由游戏管理器统一控制
    public float rotateStartTime;
    private float rotateTime;

    public float playerFreezeTime;
    private float freezeTime;

    //public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotateTime = rotateStartTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotateTime >= 0)
        {
            rotateTime -= Time.deltaTime;
            //PlayerController.moveable = true;
        }
        else
        {

            foreach (var item in Rings)
            {
                item.GetComponent<RingRotation>().ClockWise();
            }
            int clock = Rings[PlayerController.playerIndex].GetComponent<RingRotation>().clock;
            PlayerController.ClockWise(clock);
            if (PlayerController.GetComponentInChildren<PlayerData>().hitEnemy.Count != 0)
            {
                GameObject item = PlayerController.GetComponentInChildren<PlayerData>().hitEnemy[0];
                item.SetActive(true);
                PlayerController.GetComponentInChildren<PlayerData>().hitEnemy.RemoveAt(0);

            }


            //transform.localEulerAngles = new Vector3(0, 0, transform.rotation.z + 45);
            rotateTime = rotateStartTime;
        }
        if (rotateTime <= playerFreezeTime)
        {
            PlayerController.moveable = false;
            freezeTime = 2 * playerFreezeTime;
        }
        if (freezeTime > 0)
        {
            freezeTime -= Time.deltaTime;
        }
        else
        {
            PlayerController.moveable = true;
        }
    }

    public void ChangeRing(int _index)
    {
        foreach (var item in Rings)
        {
            //item.GetComponent<RingRotation>().autoRotate = true;
        }
        //Rings[_index].GetComponent<RingRotation>().autoRotate = false;
    }
}
