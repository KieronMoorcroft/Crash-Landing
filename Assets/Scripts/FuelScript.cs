using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FuelScript : MonoBehaviour {

    public float speed;
    public RectTransform fuelTransform;
    private float cachedY;
    private float minXValue;
    private float maxXValue;
    private int currentFuel;
    public Vector2 fallDown = new Vector2(100, -200);

    private int CurrentFuel
    {
        get { return currentFuel; }
        set { 
            currentFuel = value;
            HandleFuel();
        }
    }
    public int maxFuel;
    public Text fuelText;
    public float coolDown;
    private bool onCD;
    
    // Use this for initialization
	void Start () {

        cachedY = fuelTransform.position.y;
        maxXValue = fuelTransform.position.x;
        minXValue = fuelTransform.position.x - fuelTransform.rect.width;
        currentFuel = maxFuel;
        onCD = false;
	}
	
	// Update is called once per frame
	void Update () {

        HandleFuel();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!onCD && currentFuel > 0)
            {
                StartCoroutine(CoolDownFuel());
                CurrentFuel -= 25;
            }
        }
        if (currentFuel == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(fallDown);
        }
	}
    IEnumerator CoolDownFuel()
    {
        onCD = true;
        yield return new WaitForSeconds(coolDown);
        onCD = false;
    }
    private void HandleFuel()
    {
        fuelText.text = "Fuel: " + currentFuel;

        float currentXValue = MapValues(currentFuel, 0, maxFuel, minXValue, maxXValue);

        fuelTransform.position = new Vector3(currentXValue, cachedY);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Fuel")
        {
            Debug.Log("this hit?");
            if (currentFuel < 200)
            {
                CurrentFuel += 25;
            }

        }
         Debug.Log(CurrentFuel);
    }
    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
