using UnityEngine;

public class Enemy : MonoBehaviour , IDamageable
{
    [SerializeField] private int hp = 100;
    public float MS= 2f;
    protected Transform player;

    [Header("pengaturan state machine")]
    [SerializeField] private float jarakDeteksi = 6f; // masuk chase
    [SerializeField] private float jarakSerang = 1.5f; // masuk attack
    [SerializeField] private float jedaSerang = 1f;

    private StateZombie currentState = StateZombie.Idle;
    private float waktuSerangTerakhir;

 protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            Debug.Log("kamu dikejar rrq");
        }
    }

  void Update()
    {
        

     PeriksaTransisi();

    switch(currentState)
    {
        case StateZombie.Idle: PerilakuIdle(); break;  
        case StateZombie.Patrol: PerilakuPatrol(); break;
        case StateZombie.Chase: PerilakuChase(); break;
        case StateZombie.Attack: PerilakuAttack(); break;
    }

    }

    public void Kejar()

    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(

            transform.position,
            player.position,
            MS * Time.deltaTime
        );
     }

public virtual void Serang()
    {
        Debug.Log("Enemy menyerang player");
    }

    public void KenaDamage(int jumlah)
    {
        hp -= jumlah;
        Debug.Log($"{gameObject.name} terkena damage {jumlah}, sisa HP: {hp}");
        if (hp <= 0)
        {
            Mati();
        }
    }
    
    private void Mati()
    {
        Debug.Log($"{gameObject.name} mati");
        Destroy(gameObject);
    }

    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, player.position);

    }

    void PeriksaTransisi()
    {
    float jarak = JarakKePlayer();

    if(jarak<= jarakSerang)
    {
        currentState = StateZombie.Attack;
    }
    else if(jarak <= jarakDeteksi)
    {
        currentState = StateZombie.Chase;
    }
    else
    {
        currentState = StateZombie.Patrol;

    }
    }

void PerilakuIdle()
{  }

void PerilakuPatrol(){  Debug.Log(" Zombie Patrol");  }
void PerilakuChase(){  Debug.Log(" Zombie Chase"); Kejar();  }
void PerilakuAttack(){  Debug.Log(" Zombie Attack");  }

  
}



