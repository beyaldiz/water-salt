using UnityEngine;

public class CounterCol : MonoBehaviour {

    public Counter ct;

    public static int nextIndex = 0;

    public int index;

    void Start()
    {
        nextIndex += 1;
        index = nextIndex;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Su")
        {
            ct.numOfSalt += other.gameObject.GetComponent<Water>().saltIn;
            other.gameObject.GetComponent<Water>().caseIndex = index;
            ct.numOfWater += 1;
        }
        if (other.gameObject.tag == "Tuz")
        {
            other.gameObject.GetComponent<Salt>().caseIndex = index;
            ct.numOfSalt += 1;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Su")
        {
            ct.numOfSalt -= other.gameObject.GetComponent<Water>().saltIn;
            other.gameObject.GetComponent<Water>().caseIndex = 0;
            ct.numOfWater -= 1;
        }
        if (other.gameObject.tag == "Tuz")
        {
            other.gameObject.GetComponent<Salt>().caseIndex = 0;
            ct.numOfSalt -= 1;
        }
    }
}
