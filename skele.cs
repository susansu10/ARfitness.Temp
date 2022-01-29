using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System;
public class Bone
{
    public int boneID; // the id can be 0~31
    public double[] coord = new double[3]; // means [x,y,z
}
public class Body
{
    public Bone[] bone = new Bone[33];
}
public class pose : MonoBehaviour
{
    string path = @"F:\code\python\project\AR_project\data.txt";
    //public GameObject rightElbow, leftElbow, rightShoulder, rightShoulder2, leftShoulder, leftShoulder2, rightHip, leftHip, rightKnee, leftKnee, rightAnkle, leftAnkle, leftHand, rightHand, leftFinger, rightFinger, leftFingerN, rightFingerN, leftToe, rightToe, leftToeN, rightToeN;
    //public GameObject spine1, spine2, neck, nose, butt;
    public GameObject rightHand;
    public const float m = 1.5f;
    float a, b, c, d, e, f;
    //public Vector3 k;
    public void setBone(int bone_id, GameObject bone_arg, List<Bone> body_arg)
    {
        a = (float)body_arg[bone_id].coord[0];
        b = (float)body_arg[bone_id].coord[1];
        c = (float)body_arg[bone_id].coord[2];
        bone_arg.transform.position = new Vector3(a * 3, -b * 3, -c * 12);
    }
    void Start()
    {
        //k = (nose.transform.position.x, nose.transform.position.y, nose.transform.position.z);
        //this.transform.position = new Vector3((float)-0.45, (float)3.88, (float)-4.98);
        //rightHip = GameObject.Find("DungeonSkeleton_demo/Bip001 Pelvis/Bip001 Spine/Bip001 L Thigh");

    }

    // Update is called once per frame
    void Update()
    {

        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader r = new StreamReader(fs))
        {
            string json = r.ReadToEnd();
            var bones = JsonConvert.DeserializeObject<List<Bone>>(json);
            setBone(16, rightHand, bones);
            /*float a, b, c, d, e, f;
            //setBone(0, nose, bones);
            setBone(13, rightElbow, bones);
            setBone(14, leftElbow, bones);
            setBone(11, rightShoulder, bones);
            setBone(12, leftShoulder, bones);
            setBone(23, rightHip, bones);
            setBone(24, leftHip, bones);
            setBone(25, rightKnee, bones);
            setBone(26, leftKnee, bones);
            setBone(27, rightAnkle, bones);
            setBone(28, leftToe, bones);
            setBone(27, rightToe, bones);
            setBone(32, leftToeN, bones);
            setBone(31, rightToeN, bones);
            setBone(16, leftHand, bones);
            setBone(15, rightHand, bones);
            setBone(22, leftFinger, bones);
            setBone(21, rightFinger, bones);
            setBone(20, leftFingerN, bones);
            setBone(19, rightFingerN, bones);
            d = ((float)bones[11].coord[0] + (float)bones[12].coord[0]);
            e = ((float)bones[11].coord[1] + (float)bones[12].coord[1]);
            f = ((float)bones[11].coord[2] + (float)bones[12].coord[2]);
            neck.transform.position = new Vector3((float)(-d / 2.5), (float)(-e / 2.5), (float)(-f / 2.5));
            a = ((float)bones[23].coord[0] + (float)bones[24].coord[0]);
            b = ((float)bones[23].coord[1] + (float)bones[24].coord[1]);
            c = ((float)bones[23].coord[2] + (float)bones[24].coord[2]);
            butt.transform.position = new Vector3(-a/2, -b/2, c/2);
            spine2.transform.position = new Vector3(-a/2, -b/2, c/2);
            spine1.transform.position = new Vector3(-(a + d)/4, -(b + e) / 4, -(c + f) / 4);*/
        }
        Thread.Sleep(10);
    }
}
