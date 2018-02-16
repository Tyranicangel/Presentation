using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barb : MonoBehaviour {
    Animator anim;
    public GameObject axe;
    public GameObject rWrist;
    public GameObject rShoulder;
    public GameObject effect;
    bool isEquip;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isEquip = false;
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
        if(Input.GetMouseButtonDown(0) && isEquip==true)
        {
            effect.GetComponent<ParticleSystem>().Play();
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (isEquip==true)
            {
                isEquip = false;
                anim.SetBool("Equip", false);
                Invoke("moveAxeBack", 1.05f);
            }
            else
            {
                isEquip = true;
                anim.SetBool("Equip", true);
                Invoke("moveAxe", 1.21f);
            }           
        }
	}

    void moveAxe()
    {
        axe.transform.SetParent(rWrist.transform);
        axe.transform.localPosition = new Vector3(-0.3f, 0.14f, -0.03f);
        axe.transform.localRotation = Quaternion.Euler(-52.7f, -52.9f, -239.85f);
    }

    void moveAxeBack()
    {
        axe.transform.SetParent(rShoulder.transform);
        axe.transform.localPosition = new Vector3(-0.2355748f, -0.2235136f, 0.361107f);
        axe.transform.localRotation = Quaternion.Euler(4.958f, 146.944f, 65.37701f);
    }
}
