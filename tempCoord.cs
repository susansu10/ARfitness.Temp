using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System;
public class Bone
{
    //public int boneID; // the id can be 0~31
    public double[] coord = new double[3]; // means [x,y,z]
}
public class Body
{
    public Bone[] bone = new Bone[33];
}
public class tempCoord : MonoBehaviour
{
    string path = @"E:\code\pythonProject\project\cvZoneTempCap\tempCapFile.txt";
    // string path = @"E:\code\pythonProject\project\LookatResearch\cvZone_tempCap";
    public GameObject nose, mouth_left, mouth_right, left_shoulder, right_shoulder, left_elbow, right_elbow, left_wrist, right_wrist, left_pinky, right_pinky, left_index, right_index, left_hip, right_hip, left_knee, right_knee, left_ankle, right_ankle, left_heel, right_heel, left_foot_index, right_foot_index;
    //public GameObject left_eye_inner, left_eye, left_eye_outer, right_eye_inner, right_eye, right_eye_outer, left_ear, right_ear, left_thumb, right_thumb;
    public GameObject neck,pelvis,spine,spine1;//character has but landmark doesnt
    public const float m = 1.5f;
    float a, b, c, d, e, f;
    float A, A1, B, B1, C, C1;
    //public Vector3 k;
    public void setBone(int bone_id, GameObject bone_arg, List<Bone> body_arg)
    {
        a = (float)body_arg[bone_id].coord[0]/100;
        b = (float)body_arg[bone_id].coord[1]/100;
        c = (float)body_arg[bone_id].coord[2]/300;
        bone_arg.transform.position = new Vector3(nose.transform.position.x + a, nose.transform.position.y + b, nose.transform.position.z + c);
        //bone_arg.transform.position = new Vector3( a*2,  b*2,  c*2);
        //bone_arg.transform.position = new Vector3(Center.transform.position.x + a * 2, Center.transform.position.y + b * 2, Center.transform.position.z + c * 2);
        //bone_arg.transform.position = new Vector3(a,b,c);
        //bone_arg.transform.position = new Vector3(1, 1, 1);
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader r = new StreamReader(fs))
        {
            
            string json = r.ReadToEnd();
            var bones = JsonConvert.DeserializeObject<List<Bone>>(json);
            nose.transform.position = new Vector3(0, 12, 0);
            neck.transform.position = new Vector3(0, 12, 0);
            /* setBone(1, left_eye_inner, bones);
             setBone(2, left_eye, bones);
             setBone(3, left_eye_outer, bones);
             setBone(4, right_eye_inner, bones);
             setBone(5, right_eye, bones);
             setBone(6, right_eye_outer, bones);
             setBone(7, left_ear, bones);
             setBone(8, right_ear, bones);*/
            setBone(9, mouth_left, bones);
            setBone(10, mouth_right, bones);
            setBone(11, left_shoulder, bones);
            setBone(12, right_shoulder, bones);
            setBone(13, left_elbow, bones);
            setBone(14, right_elbow, bones);
            setBone(15, left_wrist, bones);
            setBone(16, right_wrist, bones);
            setBone(17, left_pinky, bones);
            setBone(18, right_pinky, bones);
            setBone(19, left_index, bones);
            setBone(20, right_index, bones);
            /*setBone(21, left_thumb, bones);
            setBone(22, right_thumb, bones);*/
            setBone(23, left_hip, bones);
            setBone(24, right_hip, bones);
            setBone(25, left_knee, bones);
            setBone(26, right_knee, bones);
            setBone(27, left_ankle, bones);
            setBone(28, right_ankle, bones);
            setBone(29, left_heel, bones);
            setBone(30, right_heel, bones);
            setBone(31, left_foot_index, bones);
            setBone(32, right_foot_index, bones);

            //d = ((float)bones[11].coord[0] + (float)bones[12].coord[0]);
            //e = ((float)bones[11].coord[1] + (float)bones[12].coord[1]);
            // = ((float)bones[11].coord[2] + (float)bones[12].coord[2]);
            //neck.transform.position = new Vector3(Center.transform.position.x + (float)(d), Center.transform.position.y + (float)(e), Center.transform.position.z + (float)(f));
            A = ((float)bones[23].coord[0]  + (float)bones[24].coord[0])/200;
            B = ((float)bones[23].coord[1]  + (float)bones[24].coord[1]) /200;
            C = ((float)bones[23].coord[2] + (float)bones[24].coord[2]) / 600;
            A1 = A + (((float)bones[12].coord[0] + (float)bones[11].coord[0]) / 200);
            B1 = B + (((float)bones[12].coord[1] + (float)bones[11].coord[1]) / 200);
            C1 = C + (((float)bones[12].coord[2] + (float)bones[11].coord[2]) / 600);
            spine.transform.position = new Vector3(A, 12+B, C);
            pelvis.transform.position = new Vector3(A1/2, 12 + B1 /2, C1/2);
            spine1.transform.position = new Vector3(A1/2, 12 + B1 /2, C1/2);
            /*spine.transform.position  = nose.transform.position + new Vector3(A, B, C);
            pelvis.transform.position = nose.transform.position + new Vector3(A1 / 2, B1 / 2, C1 / 2);
            spine1.transform.position = nose.transform.position + new Vector3(A1 / 2, B1 / 2, C1 / 2);*/
            


        }

        Thread.Sleep(30);
    }
}
