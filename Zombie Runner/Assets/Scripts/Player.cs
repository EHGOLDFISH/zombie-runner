using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerSpawnPoints;
    public GameObject landingAreaPrefab;
	public bool lastRespawnToggle = false;

    private bool reSpawn = false;
    private Transform[] spawnPoints;
    
    // Use this for initialization
    void Start()
    {
       // spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //debug controller
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick 1 button " + i))
            {
                print("joystick 1 button " + i);
            }
        }

        //var value = Input.GetAxis("Mouse X Joystick");
        //print(value);
        //var value2 = Input.GetAxis("Mouse X Joystick");
        //print(value2);
        //var value3 = Input.GetAxis("Horizontal JoyStick");
        //print(value3);

        //transform.position = transform.position + Camera.main.transform.forward * 8f * Time.deltaTime;
        if (lastRespawnToggle != reSpawn)
        {
            Respawn();
            reSpawn = false;
        }
        else
        {
            lastRespawnToggle = reSpawn;
        }

    }

    private void Respawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
    }

    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }

    void DropFlare()
    {
        Instantiate(landingAreaPrefab, transform.position, transform.rotation);
    }
}
