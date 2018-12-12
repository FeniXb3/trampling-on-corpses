using Services;
using Services.Implementations;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private ILocalStorageService localStorageService;
    public static int TotalDeaths;
    
    private void Start()
    {
        LoadServices();
        ClearSavedPlayerColor();
        MakeCorpseWalkable();
        BlockPosition();
        TotalDeaths++;
    }

    private void ClearSavedPlayerColor()
    {
        localStorageService.DeleteColorKey("playerColor");
    }

    private void BlockPosition()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
        rb.mass = 999999f; // my suggestion of fixing being able to move dead corpse around
    }

    private void MakeCorpseWalkable()
    {
        gameObject.tag = "Ground";
        gameObject.layer = LayerMask.NameToLayer("Ground");
    }

    private void LoadServices()
    {
        if (localStorageService == null)
        {
            localStorageService = new PlayerPrefsLocalStorageService();
        }
    }
}