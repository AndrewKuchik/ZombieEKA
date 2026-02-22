using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] Zombies;
    public Vector3 selectedSize;
    InputAction left, right, jump;
    private int selectedIndex = 0;
    public Vector3 pushForce;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public int score;
    public static GameManager instance;
    float time = 0f;
    public GameObject gameOverUI;

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;           // Останавливаем время
        gameOverUI.SetActive(true);    // Включаем UI
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectZombie(0);
        left = InputSystem.actions.FindAction("PrevZombie");
        right = InputSystem.actions.FindAction("NextZombie");
        jump = InputSystem.actions.FindAction("Jump");
    }
    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
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
