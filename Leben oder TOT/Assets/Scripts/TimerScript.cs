using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Slider s;

    // Start is called before the first frame update
    void Start()
    {
        s.maxValue = 1f;
        s.value = 0.01f;
        StartCoroutine(WaitCheckPointCharlieToBeReached());
    }



    IEnumerator WaitCheckPointCharlieToBeReached()
    {
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
        yield return new WaitForSeconds(3);
        s.value += 0.01f;
    }
}
