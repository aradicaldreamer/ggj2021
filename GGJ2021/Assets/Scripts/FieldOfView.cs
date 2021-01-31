// FOV built using Code Monkey tutorial found here: https://www.youtube.com/watch?v=CSeUMTaNFYk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask playerLayerMask;
    private Mesh mesh;
    [SerializeField] private float fov = 90f;
    [SerializeField] private int rayCount = 10;
    private Vector3 origin;
    private float startingAngle;
    
    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }

    private void LateUpdate()
    {
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;
        
        Vector3[] verticies = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[verticies.Length];
        int[] triangles = new int[rayCount *3];

        verticies[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                // No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // hit
                // Debug.Log("Raycast hit object with name " + raycastHit2D.transform.name);
                vertex = raycastHit2D.point;
            }

            RaycastHit2D catCheck = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, playerLayerMask);
            if (catCheck.collider != null)
            {
                //Debug.Log("Cat Found!");
                GameOver();
            }

            verticies[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex -1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex ++;
            angle -= angleIncrease;
        }

        mesh.vertices = verticies;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = (GetAngleFromVectorFloat(aimDirection) - fov / 2f) + 90f;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
