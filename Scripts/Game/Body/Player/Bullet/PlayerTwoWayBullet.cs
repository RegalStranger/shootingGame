﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerTwoWayBullet : IPlayerBulletCommand {

    public override void Start() {
        base.Start();
        Init();
    }

    void Update() {
        Move();
    }

    public override void Init() {
        Damage = 7f;
        Speed = 10f;
        BulletParent = this.transform.parent.GetComponent<PlayerBulletBase>();
    }

    public override void Move() {
        GetComponent<Rigidbody2D>().velocity = YkSys.Pose ? (Vector2)transform.up.normalized * Speed : Vector2.zero;
    }

    public override void OnTriggerEnter2D(Collider2D col2) {
        if (BulletParent.GetUnenableTag(col2.gameObject.tag)) {
            this.gameObject.SetActive(false);
            this.transform.localPosition = BulletParent.gameObject.transform.localPosition;
            BulletParent.SetStopBullet();
        }
    }

}
