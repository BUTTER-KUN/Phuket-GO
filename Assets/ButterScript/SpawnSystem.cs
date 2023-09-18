using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [System.Serializable] 
public class Material
{
    public string Name;

    public GameObject Prefab;
    [Range (0f , 50f)]public float Chance = 20f ;

    [HideInInspector] public double _weight;
}


public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private Material[] materials ;

    private double accumulatedWeights;
    private System.Random rand = new System.Random ();

    private void Awake ()
    {
        CalculateWeight ();
    }

    private void Start()
    {
        
        for (int i = 0; i < 20; i++) //amout of item spawning
            {
                SpawnRandomMaterial (new Vector2(Random.Range (-6f,6f),Random.Range (-6f,6f))); // Area of Spawning
            }

    }


    private void SpawnRandomMaterial(Vector2 position)
    {
        Material randomMaterial = materials [GetRandomMaterialIndex () ];

        GameObject spawnedObject = Instantiate(randomMaterial.Prefab, position, Quaternion.identity, transform);

        BoxCollider2D collider = spawnedObject.AddComponent<BoxCollider2D>();
        
        collider.size = new Vector2(1, 1);

    }

    private int GetRandomMaterialIndex (){
        double r = rand.NextDouble () * accumulatedWeights;

        for (int i = 0; i < materials.Length; i++)
            if (materials[i]._weight >= r)
                return i;
        
        return 0;
  
    }
    private void CalculateWeight () 
    {
        accumulatedWeights = 0f;
        foreach (Material material in materials)
        {
            accumulatedWeights += material.Chance;
            material._weight =accumulatedWeights;
        }
    }
}