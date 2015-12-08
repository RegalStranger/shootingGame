using UnityEngine;
using System.Collections;
using System;

public class PlayerShellBullet : IPlayerBulletCommand {

    private Vector3 initPos = new Vector3();

    public override void Start() {
        base.Start();
        Init();
    }

    void Update() {
        Move();
    }

    public override void Init() {
        Damage = 10f;
        Speed = 6f;
        initPos.Set(this.transform.localPosition.x, this.transform.localPosition.y + 0.33f, this.transform.localPosition.z);
        BulletParent = this.transform.parent.GetComponent<PlayerBulletBase>();
    }

    public override void Move() {
        GetComponent<Rigidbody2D>().velocity = YkSys.Pose ? (Vector2)transform.up.normalized * Speed : Vector2.zero;
    }

    public override void OnTriggerEnter2D(Collider2D col2) {
        if (BulletParent.GetUnenableTag(col2.gameObject.tag)) {
            this.gameObject.SetActive(false);
            this.transform.localPosition = BulletParent.gameObject.transform.localPosition;
            this.transform.localPosition = initPos;
            BulletParent.SetStopBullet();
        }

        if(col2.gameObject.tag == "EnemyBullet") {
            this.gameObject.SetActive(false);
            this.transform.localPosition = BulletParent.gameObject.transform.localPosition;
            BulletParent.SetStopBullet();
            col2.gameObject.SetActive(false);
        }
    }
}
