using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTransfer : MonoBehaviour
{
    public string LevelToLoad;

    private MovemnetPlayerController Player;
    private Camera_Controller Camera;

    public string PointNameToPutPlayer;
    public string PointName;

    public static bool HasJustExited = true;
    public bool IgnoreSceneLoad;

    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<MovemnetPlayerController>();
        if (Player.StartPoint == PointName)
        {
            Player.transform.position = transform.position;
            Camera = FindObjectOfType<Camera_Controller>();
            Camera.transform.position = new Vector3(transform.position.x, Camera.transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && HasJustExited && other is BoxCollider)
        {
            if (!IgnoreSceneLoad)
            {
                Application.LoadLevel(LevelToLoad);
            }
            Player.StartPoint = PointNameToPutPlayer;
            HasJustExited = false;
        }
    }

    void OnTriggerExit()
    {
        HasJustExited = true;
    }
}
