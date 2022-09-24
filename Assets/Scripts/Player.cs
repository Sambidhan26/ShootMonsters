using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 cameraMousePosition;

    public Text scoreText;
    public Text scoreHealth;

    private int healthScore;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreCanvas").GetComponentInChildren<Text>();
        scoreHealth = GameObject.Find("HealthCanvas").GetComponentInChildren<Text>();

        healthScore = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;

        cameraMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //cameraMousePosition = cameraMousePosition - transform.position;

        cameraMousePosition.z = 0;

        cameraMousePosition.x = Mathf.Clamp(cameraMousePosition.x, -8.0f, 8.0f);
        cameraMousePosition.y = Mathf.Clamp(cameraMousePosition.y, -4.0f, 4.0f);

        transform.position = cameraMousePosition;

        scoreText.text = MonsterSpawn.score.ToString();
        scoreHealth.text = healthScore.ToString();
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Monsters")
        {
            healthScore -= 1;

            if (healthScore < 0)
            {
                Destroy(this.gameObject);

                SceneManager.LoadScene(0);
            }
        }
    }
}
