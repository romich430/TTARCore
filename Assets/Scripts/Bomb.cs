using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject fire;

    public float AngleInDegrees;

    float g = Physics.gravity.y;

    public void SetVelocity(GameObject target)
    {
        Vector3 fromTo = new Vector3(target.transform.position.x, target.transform.position.y + 0.04f, target.transform.position.z) - this.transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float AngleInRads = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRads)*x)*Mathf.Pow(Mathf.Cos(AngleInRads), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        transform.LookAt(target.transform);

        GetComponent<Rigidbody>().velocity = transform.forward * v;
    }

    public void OnCollisionEnter(Collision other) 
    {
        if (!other.collider.CompareTag("Tower") && !(other.collider.CompareTag(this.gameObject.tag)) && !other.collider.CompareTag("Fire"))
        {
            StartCoroutine(SetFire());
        }
    }

    IEnumerator SetFire()
    {
        GameObject fire_ = Instantiate(fire, transform.position, Quaternion.identity);
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(3f);
        Destroy(fire_);
        Destroy(this.gameObject);
    }
}
