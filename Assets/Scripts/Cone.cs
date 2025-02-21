using UnityEngine;

public class Cone : MonoBehaviour
{
    public float height = 1.0f;
    public float radius = 0.5f;
    public int segments = 20; // Controls how smooth the cone is

    void Start()
    {
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mf.mesh = GenerateConeMesh();
    }

    Mesh GenerateConeMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[segments + 2]; // Cone tip + base + center point
        int[] triangles = new int[segments * 3 * 2];    // Triangles for the base and sides

        // Cone Tip
        vertices[0] = Vector3.up * height;

        // Generate base vertices
        float angleStep = 360.0f / segments;
        for (int i = 0; i <= segments; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleStep;
            vertices[i + 1] = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
        }

        // Generate triangles for the sides
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 2) % (segments + 1) + 1;
        }

        // Generate triangles for the base
        int baseCenterIndex = vertices.Length - 1;
        vertices[baseCenterIndex] = Vector3.zero; // Base center

        for (int i = 0; i < segments; i++)
        {
            int triOffset = segments * 3 + i * 3;
            triangles[triOffset] = baseCenterIndex;
            triangles[triOffset + 1] = (i + 2) % (segments + 1) + 1;
            triangles[triOffset + 2] = i + 1;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}
