using UnityEngine;

public class Raffa : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public bool raffa = true;


    public override void Serang()
    {
        Debug.Log("Raffa menyerang player");
    }

}
