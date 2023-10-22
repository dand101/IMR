using UnityEngine;

public class CreateNewCube : MonoBehaviour
{
    public GameObject cubePrefab;

    public void CreateCube()
    {
        Instantiate(cubePrefab, cubePrefab.transform.position, Quaternion.identity);
    }
}
