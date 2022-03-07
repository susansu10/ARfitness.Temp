import json
import cv2
import mediapipe as mp
mp_drawing = mp.solutions.drawing_utils
mp_drawing_styles = mp.solutions.drawing_styles
mp_pose = mp.solutions.pose
# For webcam input:
cap = cv2.VideoCapture(0)
with mp_pose.Pose(
        min_detection_confidence=0.5,
        min_tracking_confidence=0.5) as pose:
    while cap.isOpened():
        success, image = cap.read()
        if not success:
            print("Ignoring empty camera frame.")
            # If loading a video, use 'break' instead of 'continue'.
            continue
        # To improve performance, optionally mark the image as not writeable to
        # pass by reference.
        #image.flags.writeable = False
        image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
        results = pose.process(image)
        # 劃出相關的點在圖片上
        image.flags.writeable = True
        image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
        mp_drawing.draw_landmarks(
            image,
            results.pose_landmarks,
            mp_pose.POSE_CONNECTIONS,
            landmark_drawing_spec=mp_drawing_styles.get_default_pose_landmarks_style())
        # 座標
        # in the cycle of capture
        if results.pose_landmarks:
            with open('data.txt', 'w') as outfile:
                wholeBodyCoordinate = []
                x = (results.pose_landmarks.landmark[11].x + results.pose_landmarks.landmark[12].x)/2
                y = (results.pose_landmarks.landmark[11].y + results.pose_landmarks.landmark[12].y)/2
                z = (results.pose_landmarks.landmark[11].z + results.pose_landmarks.landmark[12].z)/2
                for i in range(33):
                    coord = results.pose_landmarks.landmark[i]
                    oneBone = {
                        "boneID": i,
                        "coord":[-(x - coord.x), (y-coord.y), (z-coord.z)]
                    }
                    wholeBodyCoordinate.append(oneBone)
                jasonOutput = json.dumps(wholeBodyCoordinate)
                outfile.write(jasonOutput)
        # Flip the image horizontally for a selfie-view display.
        cv2.imshow('MediaPipe Pose', cv2.flip(image, 1))
        if cv2.waitKey(5) & 0xFF == 27:
            break
cap.release()