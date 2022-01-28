using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField]private GameObject enemy;
    public float radius;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            float x = 0, z = 0;
            x = Random.Range(-radius, radius);
            z = Mathf.Sqrt(radius*radius - x*x);
            this.transform.localPosition = new Vector3(x, this.transform.localPosition.y, z);
            Instantiate(enemy, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
