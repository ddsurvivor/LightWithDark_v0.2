using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    //public KeyCode jumpKey;
    //public KeyCode moveOutKey;
    //public KeyCode moveInKey;

    //private float[] playerPoses = {3.83f, 5.11f};
    public int playerIndex;

    private Vector3 targetPos;
    private Quaternion targetRotation;

    private GameManager GameManager;

    public float moveStartTime;
    private float moveTime;

    public GameObject playaerImage;

    public bool moveable;


    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.ChangeRing(playerIndex);

    }
    private void FixedUpdate()
    {
        if (moveTime >= 0)
        {
            moveTime -= Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(0.0f, playerIndex * 1.4f + 1.2f, 0.0f);
        playaerImage.transform.localPosition = Vector3.Slerp(playaerImage.transform.localPosition, targetPos, moveSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);
        if (moveTime < 0 && moveable)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ClockWise(1);
                moveTime = moveStartTime;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ClockWise(-1);
                moveTime = moveStartTime;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (playerIndex < GameManager.Rings.Length - 1)
                {
                    playerIndex++;
                    GameManager.ChangeRing(playerIndex);
                    moveTime = moveStartTime;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (playerIndex > 0)
                {
                    playerIndex--;
                    GameManager.ChangeRing(playerIndex);
                    moveTime = moveStartTime;
                }
            }
        }
    }
    public void ClockWise(int _clock)
    {
        targetRotation = Quaternion.Euler(0.0f, 0.0f, transform.rotation.eulerAngles.z - _clock * 45.0f);
    }
}
