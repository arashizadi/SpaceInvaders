using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshPro hud;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hud.text = $"SCORE<1> HI-SCORE SCORE<2>\n{score.ToString()} HI-SCORE <2>";
    }

}
