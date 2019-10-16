using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[DefaultExecutionOrder(-103)]

public class BuildNavmesh : MonoBehaviour
{
    NavMeshSurface _surface;
    void Awake()
    {
            _surface = GetComponent<NavMeshSurface>();
            _surface.BuildNavMesh();
        // GetComponent<NavMeshSurface>().Bake();
    }
}