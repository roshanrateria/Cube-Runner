using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed* Time.deltaTime);
    }
    void ScoreUp()
    {
       
        scoreText.text = (int.Parse(scoreText.text)+1).ToString();
    }
    private void OnBecameInvisible()
    {
        ScoreUp();
        Destroy(gameObject);
        
    }
}
