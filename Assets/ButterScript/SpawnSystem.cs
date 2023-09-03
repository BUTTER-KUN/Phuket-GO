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

    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.Mouse0))
        {
            for (int i = 0; i < 100; i++) //amout of item spawning
            {
                SpawnRandomMaterial (new Vector2(Random.Range (-7f,7f),Random.Range (-6f,6f))); // Area of Spawning
            }
        }
    }

    private void SpawnRandomMaterial(Vector2 position)
    {
        Material randomMaterial = materials [GetRandomMaterialIndex () ];

        Instantiate (randomMaterial.Prefab, position, Quaternion.identity, transform);

        
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
