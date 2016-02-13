using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using CoherentNoise;
using CoherentNoise.Generation;
using CoherentNoise.Generation.Voronoi;
using CoherentNoise.Generation.Displacement;
using CoherentNoise.Generation.Fractal;
using CoherentNoise.Generation.Modification;
using CoherentNoise.Generation.Patterns;

public class RandomizedGrid : MonoBehaviour {

    // Basic grid data
    public List<List<GameObject>> cubeGrid = new List<List<GameObject>>();
    //public int height;
    //public int width;
    public Material cubeColorBase;

    // Randomization data
   // private List<List<float>> heightMap = new List<List<float>>();
    public int seed;
    public float threshold = .6f;

    // Use this for initialization
    /*void Start () {
        PopulateGrid();
    }*/

    public List<List<GameObject>> PopulateGrid(int height, int width)
    {
        Generator noise = CreateGenerator();

        for (int y = 0; y < height; y++)
        {
            List<GameObject> cubeGridSub = new List<GameObject>();
            cubeGrid.Add(cubeGridSub);
            for (int x = 0; x < width; x++)
            {
                float noiseVal = noise.GetValue(x, y, 0);
                if (noiseVal < threshold)
                {
                    continue;
                }

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.AddComponent<Rigidbody>();
                //Debug.Log(noiseVal);
                cube.transform.position = new Vector3(height / 2 - x, (noiseVal - threshold) / 2, width / 2 - y);
                cube.transform.localScale = new Vector3(1, noiseVal - threshold, 1);

                Color cubeColor;
				cubeColor = Color.white;//new Color((noiseVal - threshold) * 10, (noiseVal - threshold) * 10, (noiseVal - threshold) * 10);

                Material newMat = new Material(cubeColorBase);
                newMat.SetColor("_Color", cubeColor);
                cube.GetComponent<MeshRenderer>().material = newMat;

                cubeGridSub.Add(cube);
            }
        }
        return cubeGrid;
    }

    // Defines the noise generator to be used
    public Generator CreateGenerator()
    {
        PinkNoise baseNoise = new PinkNoise(seed);
        baseNoise.Persistence = .05f;
        baseNoise.Frequency = .1f;
        Generator baseNoiseGain = baseNoise.Gain(0f);

        VoronoiValleys2D voronoiMod = new VoronoiValleys2D(seed);
        voronoiMod.Frequency = .05f;
        Generator voronoiModGain = voronoiMod.Gain(.5f);

        Generator noise = voronoiModGain * baseNoiseGain;
        //noise.Binarize(threshold);

        noise = noise.ScaleShift(1f, .5f);
        noise = noise.ScaleShift(5, 0);

        return noise;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
