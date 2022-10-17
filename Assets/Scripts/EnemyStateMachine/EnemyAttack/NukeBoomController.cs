using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBoomController : MonoBehaviour
{
    [Header("�����U���i���e�������ɐ�������I�u�W�F�N�g�j")]
    public GameObject DestroyEffect;
    public Vector3 DieEffectScale;
    public int damage;

    [Header("覐΂̐������鍂���𗐐��ŉ��Z�����炷")]
    public Vector2 createPosYPlas;


    private void Start()
    {
        float randomNum = Random.Range(createPosYPlas.x, createPosYPlas.y);
        Vector3 thisDefPos = transform.position;
        this.transform.position = new Vector3(thisDefPos.x, thisDefPos.y + randomNum, thisDefPos.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Wall") return;

        //�����G�t�F�N�g�𐶐�
        GameObject go = Instantiate(DestroyEffect) as GameObject;
        go.transform.position = this.transform.position;//�ʒu�����g�̈ʒu�ֈړ�
        go.GetComponent<EffectController>().Scale = DieEffectScale;//�傫���ύX

        //�j��
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Wall") return;

        //�����G�t�F�N�g�𐶐�
        GameObject go = Instantiate(DestroyEffect) as GameObject;
        go.transform.position = this.transform.position;//�ʒu�����g�̈ʒu�ֈړ�
        go.GetComponent<EffectController>().Scale = DieEffectScale;//�傫���ύX
        //�j��
        Destroy(gameObject);
    }

}
