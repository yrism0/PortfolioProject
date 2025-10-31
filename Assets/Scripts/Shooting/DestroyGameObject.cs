using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{// Used for destroying objects at the end of an animation - through Events 
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
