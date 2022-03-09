using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// This script will flash a UI Image component with the given parameters. Useful for creating
/// quick, animated UI flashes.
/// Created by: Adam Chandler
/// Make sure that you attach this script to an Image component. You can optionally call the
/// flash remotely and pass in new flash values, or you can predefine settings in the Inspector
/// </summary>

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    Image image = null;
    Coroutine currentFlashRout = null;
    void Awake(){
        image = GetComponent<Image>();
    }
    public void StartFlash(float secondsForOneFlash, float maxAlp, Color newCol){
        image.color = newCol;
        maxAlp = Mathf.Clamp(maxAlp, 0,1);
        if (currentFlashRout != null){
            StopCoroutine(currentFlashRout);
        }
        currentFlashRout = StartCoroutine(Flash(secondsForOneFlash, maxAlp));
    }

    IEnumerator Flash(float secondsForOneFlash, float maxAlp){
        // animate flash in
        float flashInDur = secondsForOneFlash /2;
        for (float i = 0; i < flashInDur; i += Time.deltaTime){
            Color colThisFr = image.color;
            colThisFr.a = Mathf.Lerp(0,maxAlp, i/flashInDur);
            image.color = colThisFr;
            yield return null;
        }
        // animate flash out
        float flashOutDur = secondsForOneFlash/2;
        for (float i = 0; i < flashOutDur; i += Time.deltaTime){
            Color colThisFr = image.color;
            colThisFr.a = Mathf.Lerp(maxAlp,0,i/flashOutDur);
            image.color = colThisFr;
            yield return null;
        }

        //return 0
        image.color = new Color32(0,0,0,0);
    }
}
