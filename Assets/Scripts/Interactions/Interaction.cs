using System.Collections;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static Interaction Instance;
    public enum Property { LeverRoom }
    private InteractionData lastInteraction;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [Header("LeverRoom")]
    public GameObject wall;
    bool leverRoomIsActive = false;

    public void Interact(InteractionData _interactionData)
    {
        lastInteraction = _interactionData;
        if (!_interactionData || !_interactionData.IsInteractable)
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
        float _yRotation = leverRoomIsActive ? wall.transform.rotation.y : 0;
        float _rotateSpeed = 2f;
        float _maxRotation = leverRoomIsActive ? 0 : -.6f;
        Debug.Log("Lever pressed");
        if (!leverRoomIsActive)
        {
            leverRoomIsActive = true;
            while (true)
            {
                _yRotation -= _rotateSpeed * Time.deltaTime;
                wall.transform.Rotate(new Vector3(wall.transform.rotation.x, _yRotation, wall.transform.rotation.z));
                if (wall.transform.rotation.y < _maxRotation)
                    yield break;
                yield return null;
            }
        } else
        {
            leverRoomIsActive = false;
            while(true)
            {
                _yRotation += _rotateSpeed * Time.deltaTime;
                wall.transform.Rotate(new Vector3(wall.transform.rotation.x, _yRotation, wall.transform.rotation.z));
                if (wall.transform.rotation.y > _maxRotation)
                    yield break;
                yield return null;
            }
        }
    }
    #endregion
}
