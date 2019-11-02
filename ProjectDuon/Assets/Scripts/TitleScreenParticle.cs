using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenParticle : MonoBehaviour {

    public List<Sprite> possibleSprites = new List<Sprite>();
    Vector3 direction;
    float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().sprite = possibleSprites[Random.Range(0, possibleSprites.Count)];
        GetComponent<Image>().color = new Color(1, 1, 1, Random.Range(0f, 0.8f));
        transform.localScale *= UITools.GetUIScalingFactor();
        direction = new Vector3(transform.localPosition.x + Random.Range(-100f, 100f), -200f, 0);
        speed = Random.Range(0.5f, 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, direction, speed);
        if (transform.localPosition.y <= -200f)
        {
            Destroy(gameObject);
        }
	}
}
