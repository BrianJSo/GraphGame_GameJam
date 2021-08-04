using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PachinkoBallScript : MonoBehaviour
{
    private bool dropped;
    private Animator anim;
    private Rigidbody rigBod;

    // Start is called before the first frame update
    void Start()
    {
        dropped = false;
        anim = this.gameObject.GetComponent<Animator>();
        rigBod = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dropped)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                anim.speed = 0;
                anim.enabled = false;
                dropped = true;
                this.gameObject.AddComponent(typeof(Rigidbody));
            }
        }
    }
}
