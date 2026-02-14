using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPreFab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPreFab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        // Destroy all of the falling Apples and Refrigerators
        DestroyObjectsWithTag("Apple");
        DestroyObjectsWithTag("Refrigerator");

        // Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // Remove the basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_02_Game_Over");
        } else
        {
            GameObject roundGO = GameObject.Find("RoundCounter");
            RoundCounter roundCounter = roundGO.GetComponent<RoundCounter>();
            roundCounter.IncrementRound();
        }
    }
    private void DestroyObjectsWithTag(string tag)
    {
        GameObject[] fallingObjectArray;
        fallingObjectArray = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject tempGO in fallingObjectArray)
        {
            Destroy(tempGO);
        }
    }
}
