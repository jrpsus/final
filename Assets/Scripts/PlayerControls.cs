using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    public GameObject particle;
    public Animation shootAnimation;
    public float speed = 6.0f;
    public float x;
    public float damageCost = 45.0f;
    public float hpCost = 25.0f;
    public int bulletLevel = 1;
    public float money = 0;
    public float maxHp = 5.0f;
    public float hp = 5.0f;
    public float regen;
    public Text costText1;
    public Text costText2;
    public Text hpText;
    public Text moneyText;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BuyDamage()
    {
        if (money >= damageCost && bulletLevel <= 5)
        {
            money -= damageCost;
            bulletLevel += 1;
            damageCost *= 5;
            if (bulletLevel >= 5)
            {
                costText1.text = "---";
            }
            else
            {
                costText1.text = "$ " + damageCost;
            }
            MoneyText();
        }
    }
    public void BuyHp()
    {
        if (money >= hpCost && maxHp <= 100)
        {
            money -= hpCost;
            maxHp += 5;
            hp += 5;
            if (maxHp >= 15)
            {
                maxHp += 5;
                hp += 5;
            }
            hpCost *= 3;
            hpText.text = "HP " + hp + " / " + maxHp;
            if (maxHp >= 100)
            {
                costText2.text = "---";
            }
            else
            {
                costText2.text = "$ " + hpCost;
            }
            MoneyText();
        }
    }
    public void MoneyText()
    {
        moneyText.text = "$ " + money;
    }
    // Update is called once per frame
    void Update()
    {
        regen += Time.deltaTime;
        if (regen >= 1.0f && hp < maxHp)
        {
            hp += 1;
            regen = 0;
            hpText.text = "HP " + hp + " / " + maxHp;
        }
        x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x, 0, 0);
        movement = movement * speed * Time.deltaTime;

        Vector3 newPosition = transform.position;
        newPosition = newPosition + movement;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else
        {
            speed = 6.0f;
        }
        //transform.position = newPosition;
        controller.Move(movement);
        Vector3 bulletSpawn = transform.position + Vector3.up * 1.8f;
        if (Input.GetButtonDown("Jump"))
        {
            shootAnimation.Play();
            if (bulletLevel == 1)
            {
                Instantiate(bullet, bulletSpawn, Quaternion.identity);
            }
            else if (bulletLevel == 2)
            {
                Instantiate(bullet2, bulletSpawn, Quaternion.identity);
            }
            else if (bulletLevel == 3)
            {
                Instantiate(bullet3, bulletSpawn, Quaternion.identity);
            }
            else if (bulletLevel == 4)
            {
                Instantiate(bullet4, bulletSpawn, Quaternion.identity);
            }
            else if (bulletLevel == 5)
            {
                Instantiate(bullet5, bulletSpawn, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            BuyDamage();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            BuyHp();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SmallBouncy")
        {
            hp -= 4f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "NormalBouncy")
        {
            hp -= 7f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "LargeBouncy")
        {
            hp -= 13f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "XLBouncy")
        {
            hp -= 21f;
            Destroy(other.gameObject);
        }
        Instantiate(particle, other.transform.position, Quaternion.identity);
        if (hp <= -1.0f)
        {
            SceneManager.LoadScene("The Menu");
        }
        hpText.text = "HP " + hp + " / " + maxHp;
    }
}
