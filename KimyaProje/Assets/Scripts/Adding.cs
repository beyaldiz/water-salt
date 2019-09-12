using UnityEngine;

public class Adding : MonoBehaviour {

    public Buttons but;

    public GameObject water;

    public GameObject salt;

    public GameObject cases;

    private GameObject chosen;

    private string currentState = "AddCase";

    public float insTime = .3f;

    private bool canInstantiate = false;

    private float timer = 0f;

    public float insTimeForCases = .3f;

    private bool canInstantiateForCases = false;

    private float timerForCases = 1f;

    void Start()
    {
        chosen = null;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= insTime)
        {
            canInstantiate = true;
            timer = insTime;
        }
            
        else
            canInstantiate = false;

        timerForCases += Time.deltaTime;

        if (currentState != "AddCase" && !but.isOn && chosen != null && Input.GetMouseButton(0) && canInstantiate)
        {
            Vector2 posMouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(chosen, posMouseToWorld, chosen.transform.rotation);
            timer = 0f;
        }

        if (timerForCases >= insTimeForCases)
        {
            canInstantiateForCases = true;
            timerForCases = insTimeForCases;
        }
            
        else
            canInstantiateForCases = false;

        if (currentState == "AddCase" && chosen != null && !but.isOn && Input.GetMouseButtonDown(0) && canInstantiateForCases)
        {
            Vector2 posMouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(chosen, posMouseToWorld, chosen.transform.rotation);
            timerForCases = 0f;
        }
    }

    public void ChooseWater()
    {
        chosen = water;
        currentState = "AddWater";
    }

    public void ChooseSalt()
    {
        chosen = salt;
        currentState = "AddSalt";
    }

    public void ChooseCase()
    {
        chosen = cases;
        currentState = "AddCase";
    }

    public void ChoosePositioner()
    {
        chosen = null;
        currentState = "Positioner";
    }

    public void ChooseRotater()
    {
        chosen = null;
        currentState = "Rotater";
    }

    public void ChooseDeleter()
    {
        chosen = null;
        currentState = "Deleter";
    }

    public string GetState()
    {
        return currentState;
    }
}
