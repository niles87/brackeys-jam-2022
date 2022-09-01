using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadRobotRepair() {
        SceneManager.LoadScene("RobotRepair");
    }

    public void LoadStart() {
        SceneManager.LoadScene("Start");
    }
}
