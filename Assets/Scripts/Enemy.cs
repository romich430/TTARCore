using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private GameObject tower;
    public float speed;
    public int hp;
    public int dmg;
    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        tower = GameObject.Find("Tower(Clone)");
        this.transform.LookAt(tower.transform);
        animator.Play("metarig|Run");
    }

    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, tower.transform.position, speed*Time.deltaTime);
        if (hp == 0)
        {
            StartCoroutine(Death());
        }
    }

    public void OnCollisionEnter(Collision other) 
    {
        if (other.collider.CompareTag("Tower"))
        {
            StartCoroutine(Attack(other.collider.gameObject));
        }
    }
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Fire"))
        {
            animator.Play("metarig|Getting hit");
            hp--;
        }
    }

    IEnumerator Attack(GameObject tower)
    {
        tower.GetComponent<Tower>().hp -= dmg;
        animator.Play("metarig|Attack_1");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    IEnumerator Death()
    {
        animator.Play("metarig|Death");
        yield return new WaitForSeconds(1f);
        int b = Int32.Parse(GameObject.Find("Score").GetComponent<Text>().text);
        b++;
        GameObject.Find("Score").GetComponent<Text>().text = b.ToString();
        Destroy(this.gameObject);
    }
}
