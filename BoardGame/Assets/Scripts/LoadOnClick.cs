using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public void LoadGameMode(int level)
    {
        for (int i = 1; i < this.transform.childCount; ++i)
        {
            if(i != level)
                this.transform.GetChild(i).gameObject.SetActive(false);
            else
            {
                Debug.Log("Loaded Level 1");
            }
        }
        Application.LoadLevel(1);
        
    }
}
