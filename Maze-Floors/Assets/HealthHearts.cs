using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHearts : MonoBehaviour
{
    public GameObject heartsPrefab;

    public DamageableCharacter Health;
    List<HealthManager> hearts = new List<HealthManager>();

    private void OnEnable() {
        DamageableCharacter.OnPLayerDamaged += DrawHearts;
    }

    private void OnDisable() {
        DamageableCharacter.OnPLayerDamaged -= DrawHearts;
    }
    private void Start() {
        DrawHearts();
    }

    public void DrawHearts() {
        clearHearts();

        float maxHealthRemainder = Health.maxHealth % 2;
        int heartsToMake = (int)((Health.maxHealth / 2) + maxHealthRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for(int i = 0; i < hearts.Count; i++) {
            int heartStatusRemainder = (int)Mathf.Clamp(Health.health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart() {
        GameObject newHeart = Instantiate(heartsPrefab);
        newHeart.transform.SetParent(transform);

        HealthManager heartComponent = newHeart.GetComponent<HealthManager>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void clearHearts() {
        foreach(Transform t in transform) {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthManager>();
    }
    
}
