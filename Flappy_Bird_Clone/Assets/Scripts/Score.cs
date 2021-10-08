using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
