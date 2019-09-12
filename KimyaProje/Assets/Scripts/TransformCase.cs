using UnityEngine;

public class TransformCase : MonoBehaviour {

    public Rigidbody2D rb;

    public Rigidbody2D rbt;

    private Adding ad;

    void Start()
    {
        ad = GameObject.FindWithTag("Manager").GetComponent<Adding>();
    }

    void LateUpdate()
    {
        rbt.position = transform.position + new Vector3(0, 2, 0);
    }

    void OnMouseDrag()
    {
        ad = GameObject.FindWithTag("Manager").GetComponent<Adding>();
        if (ad.GetState() == "Positioner")
        {
            Vector2 mouseAxis = Vector2.zero;
            mouseAxis.x = Input.GetAxis("Mouse X");
            mouseAxis.y = Input.GetAxis("Mouse Y");
            rb.MovePosition(mouseAxis * .2f + rb.position);
        }

        if(ad.GetState() == "Rotater")
        {
            float mouseX = Input.GetAxis("Mouse X");
            rb.MoveRotation(rb.rotation - 1.2f * mouseX);
        }
    }

    void OnMouseDown()
    {
        if (ad.GetState() == "Deleter")
            Destroy(gameObject);
    }
}
