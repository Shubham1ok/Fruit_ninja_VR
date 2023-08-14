using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CircularPlaneGenerator : MonoBehaviour
{
    public int segments = 32;
    public float radius = 1.0f;
    public float rotationSpeed = 30.0f;


    public void GenerateCircularMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[segments + 1];
        int[] triangles = new int[segments * 3];

        for (int i = 0; i <= segments; i++)
        {
            float angle = 2 * Mathf.PI * i / segments;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            vertices[i] = new Vector3(x, 0, z);

            if (i > 0)
            {
                int triIndex = (i - 1) * 3;
                triangles[triIndex] = 0;
                triangles[triIndex + 1] = i;
                triangles[triIndex + 2] = i - 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

