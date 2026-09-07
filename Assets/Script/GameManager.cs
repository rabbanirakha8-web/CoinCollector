using UnityEngine;
// using TMPro;
// Simpan jumlah total koin di awal permainan. Setiap koin diambil, bandingkan skor dengan total. 
// Bila sama, panggil kondisi menang.
public class GameManager : MonoBehaviour
{  
  public int totalKoin ;
  private int koinTerkumpul = 0;

 void Start()
 {
 // TODO: hitung jumlah koin di scene saat mulai
 totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length;
 Debug.Log("Total koin di scene: " + totalKoin + " ,dapatkan coin untuk menang!");
 }
 public void AmbilKoin()
 {
 koinTerkumpul++;
 // TODO: jika koinTerkumpul == totalKoin, panggil Menang()
 if (koinTerkumpul == totalKoin) Menang();
 }
  // void UpdateSkor()
  //   {
  //       skorText.text = "Skor : " + koinTerkumpul;
  //   }
 void Menang()
 {
 Debug.Log("KAMU MENANG!");
 }
}
