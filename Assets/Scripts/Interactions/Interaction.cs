using System.Collections;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static Interaction Instance;
    public enum Property { LeverRoom }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [Header("LeverRoom")]
    public GameObject wall;
    public void Interact(InteractionData _interactionData)
    {
        if (!_interactionData)
            return;
        switch (_interactionData.interactionType)
        {
            case Property.LeverRoom:
                LeverRoom();
                break;
        }
    }


    #region LeverRoom
    public void LeverRoom()
    {
        StartCoroutine(RotateWall());
    }
    
    private IEnumerator RotateWall()
    {
        float _yRotation = 0;
        float _rotateSpeed = 2f;
        while (_yRotation > -90f)
        {
            _yRotation -= Time.deltaTime * _rotateSpeed;
            wall.transform.rotation = new Quaternion(wall.transform.rotation.x, _yRotation, wall.transform.rotation.z, wall.transform.rotation.w);
            yield return null;
        }
    }
    #endregion
}
