using UnityEngine;

public class Water : MonoBehaviour {

    public int caseIndex = 0;
    public float saltIn = 0;

    void OnCollisionStay2D(Collision2D other)
    {
        int len2 = GameObject.FindGameObjectsWithTag("Sayac").Length;
        bool flag = false;
        for (int i = 0; i < len2; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Sayac")[i].GetComponent<CounterCol>().index == caseIndex)
            {
                if(GameObject.FindGameObjectsWithTag("Sayac")[i].GetComponentInParent<Counter>().doygunMu == false)
                {
                    flag = true;
                }
            }
        }

        if (flag && other.gameObject.tag == "Tuz")
        {
            Destroy(other.gameObject);
            int len = GameObject.FindGameObjectsWithTag("Su").Length;
            int waterInCase = 0;
            for (int i = 0; i < len; i++)
            {
                if(GameObject.FindGameObjectsWithTag("Su")[i].GetComponent<Water>().caseIndex == caseIndex)
                {
                    waterInCase++;
                }
            }

            for (int i = 0; i < len; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Su")[i].GetComponent<Water>().caseIndex == caseIndex)
                {
                    GameObject.FindGameObjectsWithTag("Su")[i].GetComponent<Water>().saltIn += 1f / (float)waterInCase;
                }
            }

            for (int i = 0; i < len2; i++)
            {
                if(GameObject.FindGameObjectsWithTag("Sayac")[i].GetComponent<CounterCol>().index == caseIndex)
                {
                    GameObject.FindGameObjectsWithTag("Sayac")[i].GetComponentInParent<Counter>().numOfSalt += 1;
                }
            }
        }

        if(saltIn == 0 && other.gameObject.tag == "Su")
        {
            int len = GameObject.FindGameObjectsWithTag("Su").Length;
            int waterInCase = 0;
            float saltAll = 0;
            for (int i = 0; i < len; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Su")[i].GetComponent<Water>().caseIndex == caseIndex)
                {
                    waterInCase++;
                }
            }

            for (int i = 0; i < len; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Su")[i].GetComponent<Water>().caseIndex == caseIndex)
                {
                    saltAll += GameObject.FindGameObjectsWithTag("Su")[i].GetComponent<Water>().saltIn;
                }
            }

            for (int i = 0; i < len; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Su")[i].GetComponent<Water>().caseIndex == caseIndex)
                {
                    GameObject.FindGameObjectsWithTag("Su")[i].GetComponent<Water>().saltIn = saltAll / waterInCase;
                }
            }
        }
    }
}
