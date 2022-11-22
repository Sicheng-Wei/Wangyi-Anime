using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    List<Vector3> verts;
    List<int> indices;
    int N = 10;
    void Start()
    {
        verts = new List<Vector3>();
        indices = new List<int>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        BuildModel();
    }

    void BuildModel()
    {
        for (float i = -N / 2f; i <= N / 2f; i++)
        {
            for (float j = -N / 2f; j <= N / 2f; j++)
            {
                verts.Add(new Vector3(i, j, -N / 2f));
            }
        }
        for (float i = -N / 2f; i <= N / 2f; i++)
        {
            for (float j = -N / 2f; j <= N / 2f; j++)
            {
                verts.Add(new Vector3(N / 2f, j, i));
            }
        }
        for (float i = -N / 2f; i <= N / 2f; i++)
        {
            for (float j = -N / 2f; j <= N / 2f; j++)
            {
                verts.Add(new Vector3(i, N / 2f, j));
            }
        }
        for (float i = -N / 2f; i <= N / 2f; i++)
        {
            for (float j = -N / 2f; j <= N / 2f; j++)
            {
                verts.Add(new Vector3(-N / 2f, j, i));
            }
        }
        for (float i = -N / 2f; i <= N / 2f; i++)
        {
            for (float j = -N / 2f; j <= N / 2f; j++)
            {
                verts.Add(new Vector3(i, j, N / 2f));
            }
        }
        for (float i = -N / 2f; i <= N / 2f; i++)
        {
            for (float j = -N / 2f; j <= N / 2f; j++)
            {
                verts.Add(new Vector3(i, -N / 2f, j));
            }
        }

        //真正控制球体成型的部分
        for (int i = 0; i < verts.Count; i++)
        {
            verts[i] = verts[i].normalized;
        }
        //绘制
        MakePos(0);
        MakePos(1);
        MakePos(2);
        OtherMakePos(3);
        OtherMakePos(4);
        OtherMakePos(5);
        Draw();
    }
    public void MakePos(int num)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                int index = j * (N + 1) + (N + 1) * (N + 1) * num + i;
                int up = (j + 1) * (N + 1) + (N + 1) * (N + 1) * num + i;
                indices.AddRange(new int[] { index, index + 1, up + 1 });
                indices.AddRange(new int[] { index, up + 1, up });
            }
        }
    }
    public void OtherMakePos(int num)
    {
        for (int i = 0; i < N + 1; i++)
        {
            for (int j = 0; j < N + 1; j++)
            {
                if (i != N && j != N)
                {
                    int index = j * (N + 1) + (N + 1) * (N + 1) * num + i;
                    int up = (j + 1) * (N + 1) + (N + 1) * (N + 1) * num + i;
                    indices.AddRange(new int[] { index, up + 1, index + 1 });
                    indices.AddRange(new int[] { index, up, up + 1 });
                }
            }
        }
    }
    public void Draw()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = verts.ToArray();
        mesh.triangles = indices.ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        meshFilter.mesh = mesh;
    }
}
