using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private Vector3 minPos;
    [SerializeField] private Vector3 maxPos;
    
    public List<GameObject> trees = null;

    private void Awake()
    {
        for (int i = 0; i < 60; i++)
        {
            var pos = new Vector3(Random.Range(minPos.x, maxPos.x), 0, Random.Range(minPos.z, maxPos.z));
            Instantiate(trees[Random.Range(0, trees.Count)], pos, Quaternion.identity);
            i++;
        }
    }
}
