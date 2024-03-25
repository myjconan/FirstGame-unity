using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Canvas canvas_ui;
    public Text CherryNum;
    public Text GemNum;
    public int gem = 0;
    public int cherry = 0;
    private void Update()
    {
        CherryNum.text = cherry.ToString();
        GemNum.text = gem.ToString();

    }
    public void CherryCount()
    {
        cherry += 1;
    }
    public void GemCount()
    {
        gem += 1;
    }
}
