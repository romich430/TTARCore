using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    public GameObject bomb;
    public int hp;

    public Text healthText;

    void Start() 
    {
        healthText = GameObject.Find("health").GetComponent<Text>();    
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit) && raycastHit.collider.CompareTag("Enemy"))
            {
                StartCoroutine(AttackTarget(raycastHit.transform.gameObject));
            }
        }

        healthText.text = hp.ToString();
        
        if (hp <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator AttackTarget(GameObject target)
    {
        this.transform.LookAt(target.transform);
        GameObject bomb_ = Instantiate (bomb, new Vector3 (transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
        bomb_.GetComponent<Bomb>().SetVelocity(target);
        yield return new WaitForSeconds(0f);
    }
}
