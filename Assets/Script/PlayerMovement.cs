using UnityEngine;
using UnityEngine.InputSystem; 
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gameManager;
    
 public float kecepatan = 5f;
 private Vector2 arahGerak; 
 public int skor = 0;
 public TextMeshProUGUI text;
 // ... kode gerak dari Tugas 1 ...
 // nilai dari action "Move"
 // Dipanggil OTOMATIS oleh komponen Player Input
 // saat action "Move" pada asset InputSystem_Actions aktif.
 // Nama method WAJIB: On + nama action -> OnMoves

    void Start()
{
    gameManager = FindFirstObjectByType<GameManager>();
}

    void OnMove(InputValue value)
 {
 // TODO: ambil nilai Vector2 dari input, simpan ke arahGerak
 arahGerak = value.Get<Vector2>();
 }


    // Update is called once per frame
        void Update()
    {
        Vector3 arah = new Vector3(arahGerak.x, arahGerak.y, 0);
 transform.position += arah * kecepatan * Time.deltaTime;
    }


void OnTriggerEnter2D(Collider2D other)
 {
 if (other.CompareTag("Coin"))
 {
 Destroy(other.gameObject);
 // TODO: tambah skor sebanyak 1
 skor += 1;
 // TODO: tampilkan skor ke Console
 Debug.Log("Skor: " + skor);
 text.text = skor + "";
 gameManager.AmbilKoin();
 }
 }
}
