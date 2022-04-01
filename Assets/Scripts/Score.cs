using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; 
    public Player player;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.collected.ToString();
    }
}
