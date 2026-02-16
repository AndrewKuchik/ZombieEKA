using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] Zombies;
    public Vector3 selectedSize;
    InputAction left, right, jump;
    private int selectedIndex = 0;
    public Vector3 pushForce;
    public TMP_Text timerText;
    float time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectZombie(0);
        left = InputSystem.actions.FindAction("PrevZombie");
        right = InputSystem.actions.FindAction("NextZombie");
        jump = InputSystem.actions.FindAction("Jump");
    }

    void SelectZombie(int index) 
    {
        if (selectedZombie != null)
        { 
        selectedZombie.transform.localScale = Vector3.one;
        }
        selectedZombie = Zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected: " + selectedZombie.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(left.WasPressedThisFrame())
        {
           selectedIndex--;
            if (selectedIndex < 0)
            { selectedIndex = Zombies.Length-1; }
            SelectZombie(selectedIndex);
        }
        if (right.WasPressedThisFrame())
        {
            selectedIndex++;
            if (selectedIndex >= Zombies.Length)
            { selectedIndex = 0; }
            SelectZombie(selectedIndex);
            Debug.Log("RightPressed");
        }
        if (jump.WasPressedThisFrame())
        {
            GetComponent<Rigidbody>();
                
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            rb.AddForce(pushForce);
            Debug.Log ("Es Lecu");
        }
        time += Time.deltaTime;
        timerText.text = "Time: " + time.ToString("F1") + " S";
    }
}
