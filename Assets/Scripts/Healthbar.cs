using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Image imageFilled;
    [SerializeField] Vector3 offset;

    float hp;
    float maxHp;

    private Transform hbtarget;
    // Start is called before the first frame update
    void Update()
    {
        imageFilled.fillAmount = Mathf.Lerp(imageFilled.fillAmount, hp / maxHp, Time.deltaTime * 5f);
        transform.position = hbtarget.position + offset;
    }

    public void OnInit(float maxHp, Transform hbtarget)
    {
        this.hbtarget = hbtarget;
        this.maxHp = maxHp;
        hp = maxHp;
        imageFilled.fillAmount = 1;
    }

    public void SetHp(float hp)
    {
        this.hp = hp;
        //imageFilled.fillAmount = hp / maxHp;
    }
}
