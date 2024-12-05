using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{

    //Vars
    private GameObject square;
    public float waitLength;
    public float anglechoice;
    public float roatspeed;
    private SpriteRenderer squareColor;
    public Color startCol;
    public Color endCol;
    public float colSpeed;

    // Start is called before the first frame update
    void Start()
    {
        square = this.gameObject;
        squareColor = square.GetComponent<SpriteRenderer>();
        squareColor.color = startCol;
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
        StartCoroutine(Colorchange(startCol, endCol, colSpeed));
    }

    IEnumerator Rotation(float angle, float roatTime)
    {
        Quaternion startRotation = square.transform.rotation;
        float t = 0;
        
        while(t < 1f)
        {
            t = Mathf.Min(1f, t+Time.deltaTime / roatTime);
            Vector3 newEuler = Vector3.right * (angle * t);
            square.transform.rotation = Quaternion.Euler(newEuler) * startRotation;
            yield return null;
        }
    }

    IEnumerator Colorchange(Color startColor, Color endColor, float changeSpeed)
    {
        float t = 0;
        while (squareColor.color != endColor)
        {
            t += Time.deltaTime * changeSpeed;
            squareColor.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

    }

}
