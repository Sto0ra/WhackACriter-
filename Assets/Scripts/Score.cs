using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public TextMesh displayText;

    private int currentValue = 0;

    //update data and visual display
    public void ChangeValue(int _toChange)
    {
        currentValue = currentValue + _toChange;
        displayText.text = currentValue.ToString();
            
    }

    //reset score to 0
    public void ResetScore()
    {
        currentValue = 0;
        displayText.text = currentValue.ToString();

    }

}
