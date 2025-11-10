using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCaster2D : MonoBehaviour
{
    public Camera mainCamera;
    
    
    
    [Header("Inpunt Action")]
    public InputAction shootAction;

    [Header("Shoot Settings")]
    public LayerMask shootLayerMask;



    public void OnEnable()
    {
        shootAction.Enable();
        shootAction.performed += OnShootPerform;
    }

    public void OnDisable()
    {
        shootAction.performed -= OnShootPerform;
    }

    public void OnShootPerform(InputAction.CallbackContext context)
    {
        Vector3 mouseViewPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition =  mainCamera.ScreenToWorldPoint(mouseViewPosition);



        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, 20, shootLayerMask);

        if (hit.collider != null) 
        {
           string layerName = LayerMask.LayerToName(hit.collider.gameObject.layer);
            if (layerName == "enemy")
            {

              EnemyBase enemy =  hit.collider.gameObject.GetComponent<EnemyBase>();
                if(enemy != null)
                {
                    enemy.Hit();
                }
                else
                {
                    Debug.Log("ERORR! hit dosen't have a EnemyBase componet! >:(");
                }
            }

            else if (layerName == "obstacole")
            {
                Debug.Log("Hai colpitoun ostacolo");
            }
        }

    }

}
