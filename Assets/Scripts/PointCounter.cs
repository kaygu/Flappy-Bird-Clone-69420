using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;
    private int points = 0;
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Pipe(Clone)")
        {
            ++points;
            pointsText.text = points.ToString();
        }
    }
}
