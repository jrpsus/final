using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouncyControls : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public float yspeed;
    public float xspeed;
    public float frames;
    public GameObject particle;
    private PlayerControls playerControls;
    public float rewardMoney;
    void Start()
    {
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
        if (Random.Range(0.0f, 1.0f) >= 0.5f)
        {
            xspeed = -1.3f;
        }
        else
        {
            xspeed = 1.3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        frames += Time.deltaTime;
        yspeed -= 7 * Time.deltaTime;
        Vector3 movement = new Vector3(xspeed * Time.deltaTime, yspeed * Time.deltaTime, 0);
        transform.position += movement;
        if (transform.position.y <= -2.4f)
        {
            yspeed = 12f;
        }
        if (transform.position.x >= 11f)
        {
            xspeed = -1.3f;
        }
        if (transform.position.x <= -11f)
        {
            xspeed = 1.3f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= 1;
            playerControls.money += 1.0f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet2")
        {
            hp -= 4;
            playerControls.money += 2.0f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet3")
        {
            hp -= 16;
            playerControls.money += 3.0f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet4")
        {
            hp -= 64;
            playerControls.money += 4.0f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet5")
        {
            hp -= 256;
            playerControls.money += 5.0f;
            Destroy(other.gameObject);
        }
        if (hp <= 0)
        {
            playerControls.money += rewardMoney;
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        playerControls.MoneyText();
    }
}
