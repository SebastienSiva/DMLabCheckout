using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontSizeMatch : MonoBehaviour {
    public Text targetFont;
    Text thisFont;
	// Use this for initialization
	void Start () {

        
        thisFont = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (thisFont.fontSize != targetFont.cachedTextGenerator.fontSizeUsedForBestFit)
        {
            thisFont.fontSize = targetFont.cachedTextGenerator.fontSizeUsedForBestFit;
        }

	}
}
