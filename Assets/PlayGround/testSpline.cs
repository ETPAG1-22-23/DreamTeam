using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class testSpline : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform pointC;
    [SerializeField] Transform pointD;

    [SerializeField] float interpolateAmount;

    private Vector3[] pastPosition = new Vector3 [5];
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interpolateAmount = (interpolateAmount + Time.deltaTime) % 1f;
        gameObject.transform.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD!.position, interpolateAmount);


        //Debug.Log(test(gameObject.transform.position));
        StartCoroutine(waiter());
    }

    #region testLerp
    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(ab, bc, t);
    }

    private Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuadraticLerp(a, b, c, t);
        Vector3 bc_cd = QuadraticLerp(b,c, d, t);
        return Vector3.Lerp(ab_bc, bc_cd, t);
    }
    #endregion


    private Vector3 test(Vector3 Player)
    {
        if ( i < pastPosition.Length - 1)
        {
            pastPosition[i] = Player;
            i++;
        }
        else
        {
            i = 0;
            pastPosition[i] = Player;
        }
        return pastPosition[0];
    
    }

    IEnumerator waiter()
    {
        float counter = 0;

        float waitTime = 1;

        while(counter < waitTime)
        {
            counter += Time.deltaTime;
            Debug.Log("Counter: " +counter);
            if (i < pastPosition.Length - 1)
            {
                pastPosition[i] = gameObject.transform.position;
                i++;
            }
            else
            {
                i = 0;
                pastPosition[i] = gameObject.transform.position;
            }
            
            yield return null;
        }
        Debug.Log(pastPosition[0]);
        

    }

}
