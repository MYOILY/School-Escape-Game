using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class DeformMesh : MonoBehaviour
{
    Mesh deformingMesh;
    Vector3[] originalVertices, displacedVertices;

    void Start()
    {
        deformingMesh = GetComponent<MeshFilter>().mesh;
        originalVertices = deformingMesh.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        for (int i = 0; i < originalVertices.Length; i++)
        {
            displacedVertices[i] = originalVertices[i];
        }
    }

    void Update()
    {
        for (int i = 0; i < displacedVertices.Length; i++)
        {
            Vector3 vertex = originalVertices[i];
            // 这里添加修改顶点的逻辑，例如根据正弦波改变y坐标
            vertex.y += Mathf.Sin(Time.time) * 0.1f;
            displacedVertices[i] = vertex;
        }
        deformingMesh.vertices = displacedVertices;
        deformingMesh.RecalculateNormals(); // 重新计算法线以确保光照正确
    }
}
