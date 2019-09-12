using UnityEngine;

public class Counter : MonoBehaviour {

    public float numOfWater = 0;
    public float numOfSalt = 0;
    private float derisim = 0;
    public bool doygunMu = false;
    public float cozunurluk = 17f;
    public TextMesh tm;
    

    void LateUpdate()
    {
        derisim = (numOfSalt * 100 / (numOfWater + numOfSalt));
        if (derisim >= cozunurluk)
            doygunMu = true;
        else
            doygunMu = false;

        tm.text = "Su: " + numOfWater.ToString() + "\nTuz: " + numOfSalt.ToString() + "\nDerişim: %" + derisim.ToString() + ((doygunMu)?"\nDoygun":"\nDoygun Değil");
    }
}
