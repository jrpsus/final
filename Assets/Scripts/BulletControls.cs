using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControls : MonoBehaviour
{
    public float frames = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
        frames -= Time.deltaTime;
        if (frames <= 0)
        {
            Destroy(gameObject);
        }
    }
}
