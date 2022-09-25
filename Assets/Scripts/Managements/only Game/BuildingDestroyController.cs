using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestroyController : MonoBehaviour
{
    [Header("�ړ����������r���Q")]
    public GameObject buildings;
    public float maxPosY;
    public float moveSpeedY;

    [Header("�ȍ~�r���j��G�t�F�N�g")]
    public GameObject explosionEffect;
    [System.Serializable]
    public struct Explosion
    {
        public GameObject positionAsObject;
        public Vector3 posDifference;
        public Vector3 effectScale;
        public float bomTime;
    }
    public Explosion[] bomgo = new Explosion[1];
    private int bomNum = 0;
    private float bomTimer = 0;

    // Update is called once per frame
    void Update()
    {

        //�j�󂪏I�������K�v�Ȃ��̂Ŕj��
        if (buildings.transform.position.y <= maxPosY) { Destroy(this.GetComponent<BuildingDestroyController>()); }
        else
        {
            //�G�t�F�N�g���\�񂳂�Ă���ꍇ
            if (bomNum < bomgo.Length)
            {
                //�r���̔��j�J�E���g
                bomTimer += Time.deltaTime;
                if (bomgo[bomNum].bomTime <= bomTimer)
                {
                    //���j�G�t�F�N�g����
                    Explosion ex = bomgo[bomNum];
                    GameObject go = Instantiate(explosionEffect,
                                                ex.positionAsObject.transform.position,
                                                new Quaternion(0, 0, 0, 0));
                    //�ʒu��������уT�C�Y����
                    go.transform.position += ex.posDifference;
                    go.gameObject.GetComponent<EffectController>().Scale = ex.effectScale;
                    //�J�E���g�C���N�������g
                    ++bomNum;
                }
            }

            //�r���̈ړ�
            buildings.transform.Translate(new Vector3(0, -moveSpeedY * Time.deltaTime, 0), 0);

        }
    }
}
