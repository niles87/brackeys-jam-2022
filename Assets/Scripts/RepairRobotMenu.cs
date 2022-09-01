using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairRobotMenu : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gm.LoadStart();
        }
    }


}
