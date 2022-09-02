using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTag : MonoBehaviour
{
    private const string LOADED_TABLE = "LoadedTable";
    private const string TABLE = "Table";
    private bool robotOnTable = false;
    public GameManager gm;

    // Update is called once per frame
    void Update()
    {
        if (robotOnTable)
        {
            gameObject.tag = LOADED_TABLE;
        }
        else
        {
            gameObject.tag = TABLE;
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Robot"))
        {
            robotOnTable = true;
            Debug.Log("Robot resting on table");

        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Robot"))
        {
            robotOnTable = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // This checks for tag loadedtable and if player presses enter
            if (gameObject.tag == LOADED_TABLE && Input.GetKeyDown(KeyCode.Return))
            {
                gm.LoadRobotRepair();
            }
        }
    }
}
