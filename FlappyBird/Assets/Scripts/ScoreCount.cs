using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ScoreZone")
        {
            playerController.Score++;
            playerController.InGameScoreText.text = "Score: " + playerController.Score;
        }
    }

}
