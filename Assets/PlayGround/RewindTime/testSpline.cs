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

    [SerializeField] Transform Alpha0;
    [SerializeField] Transform Alpha1;
    [SerializeField] Transform Alpha2;
    [SerializeField] Transform Alpha3;

    private Transform[] tab = new Transform[4];

    [SerializeField] float interpolateAmount;

    private Vector3[] pastPosition = new Vector3 [4];
    private int i = 0;
    private bool isTimed = true;

    private bool isRewinded = false;
    private bool timeRewind = false;


    


    void Start()
    {
        tab[0] = Alpha0;
        tab[1] = Alpha1;
        tab[2] = Alpha2;
        tab[3] = Alpha3;      
    }


    void Update()
    {
        interpolateAmount = (interpolateAmount + Time.deltaTime) % 1f;
        //gameObject.transform.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount);


        if (isTimed && !isRewinded) 
        {
            StartCoroutine(addPastPosition());
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            TimeRewind();
        }

        if (timeRewind)
        {
            //gameObject.transform.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount);
            gameObject.transform.position = CubicLerp(Alpha3.transform.position, Alpha2.transform.position, Alpha1.transform.position, Alpha0.transform.position, interpolateAmount);
        }

        
    }

    #region Interpolation
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

    #region Tableau Position
    IEnumerator addPastPosition()
    {
        isTimed = false;

        if (i < pastPosition.Length)
        {
            pastPosition[i] = gameObject.transform.position;
            //GameObject point = new GameObject();
            //point.name = "point" + i;

            //faire tab[,] ->  tab{{point, posPoint},{...}}, set les points dès l'ini du tab, et updt position comme prévu


            i++;
        }
        else
        {
            //showTab();
            i = 0;
            pastPosition[i] = gameObject.transform.position;
        }

        yield return new WaitForSeconds(0.5f);

        
        isTimed = true;
 
    }

    void showTab()
    {
        for (int k = 0; k < i; k++)
        {
            Debug.Log(k);
            Debug.Log(pastPosition[k]);
        }
    }
    #endregion

    private void TimeRewind()
    {
        //Créa bool isRewinded pour contrôler le stockage des positions
        //Afficher Alpha du sprite sur points 
        //Set Interpolation (voir ci-dessus) avec les points crées
        //Lancer méthode quand touche pressée + activer Lerp + "Animation"

        isRewinded = true;

        /*
        int k = 0;
        foreach (Transform elements in tab)
        {
            elements.transform.position = pastPosition[k];
            k++;
        }
        */

        for (int j = 0; j < tab.Length; j++)
        {
            Debug.Log(j);
            Debug.Log(tab[j].transform.position);
        }

        StartCoroutine(startRewind());
        isRewinded = false;
    }

    IEnumerator startRewind()
    {
        gameObject.transform.position = tab[3].position;
        timeRewind = true;
        yield return new WaitForSeconds(interpolateAmount);
        timeRewind = false;
    }
}

