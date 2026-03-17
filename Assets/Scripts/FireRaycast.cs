using UnityEngine;

public class FireRaycast : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private LayerMask cameraColliderLayer;

    void Update()
    {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, cameraColliderLayer,QueryTriggerInteraction.Collide))
            {
                if (ballPrefab == null) return;

                Debug.Log("Thorwing grenade...");
                Instantiate(ballPrefab, hit.point, ballPrefab.transform.rotation);
            }
        }
    }
}
