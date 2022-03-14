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
    public GameObject Center,neck,rightElbow, leftElbow, rightShoulder, leftShoulder, rightHip, leftHip, rightKnee, leftKnee, rightAnkle, leftAnkle, leftHand, rightHand, leftFinger, rightFinger, leftFingerN, rightFingerN, leftToe, rightToe, leftToeN, rightToeN;
    public GameObject spine1, spine2, nose, butt,wholeBody;
    public const float m = 1.5f;
    float a, b, c, d, e, f;
    //public Vector3 k;
    public void setBone(int bone_id, GameObject bone_arg, List<Bone> body_arg)
    {
        a = (float)body_arg[bone_id].coord[0];
        b = (float)body_arg[bone_id].coord[1];
        c = (float)body_arg[bone_id].coord[2];  
        //bone_arg.transform.position = new Vector3(neck.transform.position.x + a, neck.transform.position.y + b, neck.transform.position.z + c);
        //bone_arg.transform.position = new Vector3( a*2,  b*2,  c*2);
        bone_arg.transform.position = new Vector3(Center.transform.position.x + a*2, Center.transform.position.y + b * 2, Center.transform.position.z + c * 2);
        //bone_arg.transform.position = new Vector3(1, 1, 1);
    }
    void Start()
    { 
    }
    // Update is called once per frame
    void Update()
    {

        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader r = new StreamReader(fs))
        {
            string json = r.ReadToEnd();
            var bones = JsonConvert.DeserializeObject<List<Bone>>(json);
            setBone(0, nose, bones);
            setBone(16, leftHand, bones);
            setBone(15, rightHand, bones);
            setBone(28, leftToe, bones);
            setBone(27, rightToe, bones);
            setBone(11, rightShoulder, bones);
            setBone(12, leftShoulder, bones);
            setBone(13, rightShoulder2, bones);
            setBone(14, leftShoulder2, bones);
            setBone(25, rightKnee, bones);
            setBone(26, leftKnee, bones);
            setBone(23, rightHip, bones);
            setBone(24, leftHip, bones);    
            //setBone(32, leftToeN, bones);
            //setBone(31, rightToeN, bones);
            /*setBone(22, leftFinger, bones);
            setBone(21, rightFinger, bones);
            setBone(20, leftFingerN, bones);
            setBone(19, rightFingerN, bones);*/

            d = ((float)bones[11].coord[0] + (float)bones[12].coord[0]);
            e = ((float)bones[11].coord[1] + (float)bones[12].coord[1]);
            f = ((float)bones[11].coord[2] + (float)bones[12].coord[2]);
            neck.transform.position = new Vector3(Center.transform.position.x + (float)(d), Center.transform.position.y + (float)(e), Center.transform.position.z + (float)(f));
            a = ((float)bones[23].coord[0] + (float)bones[24].coord[0]);
            b = ((float)bones[23].coord[1] + (float)bones[24].coord[1]);
            c = ((float)bones[23].coord[2] + (float)bones[24].coord[2]);
            //butt.transform.position = new Vector3(a, b, c);
            spine2.transform.position = new Vector3(a, b, c);
            spine1.transform.position = new Vector3((a + d), (b + e), (c + f));
        }
        Thread.Sleep(10);
    }
}
