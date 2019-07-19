using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovePlayer : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    //private float speed = 3f;

    private float min_X = -2.7f;
    private float max_X = 2.7f;

    public Text timer_Text;
    private int timer;

    void PlayerBounds() {
        Vector3 temp = transform.position;
        if (temp.x > max_X) {
            temp.x = max_X;
        } else if (temp.x < min_X) {
            temp.x = min_X;
        }
        transform.position = temp;
    }

    // Initialize game
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Time.timeScale = 1f;
        timer = 0;
        StartCoroutine(CountTime());
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBounds();
        Move();
    }

    void Move()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
        }
    }

    IEnumerator RestartGame() {
        yield return new WaitForSecondsRealtime(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    IEnumerator CountTime() {
        yield return new WaitForSeconds(1f);
        timer++;
        timer_Text.text = "Score: " + timer;
        StartCoroutine(CountTime());
    }

    void OnTriggerEnter2D(Collider2D target)
    { 
        if(target.tag == "Asteroid") {
            Time.timeScale = 0f;
            StartCoroutine(RestartGame());
        }
    }
}
