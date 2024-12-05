using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{

    //Vars
    public GameObject square;
    public float waitLength;
    public float anglechoice;
    public float roatspeed;

    // Start is called before the first frame update
    void Start()
    {
        square.SetActive(false);
        StartCoroutine(WaitandAppear(waitLength));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitandAppear(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        square.SetActive(true);
        StartCoroutine(Rotation(anglechoice, roatspeed));
    }

    IEnumerator Rotation(float angle, float roatTime)
    {
        Quaternion startRotation = square.transform.rotation;
        float t = 0;
        
        while(t < 1f)
        {
            t = Mathf.Min(1f, t+Time.deltaTime / roatTime);
            Vector3 newEuler = Vector3.right * (angle + t);
            square.transform.rotation = Quaternion.Euler(newEuler) * startRotation;
            yield return null;
        }
    }

}
