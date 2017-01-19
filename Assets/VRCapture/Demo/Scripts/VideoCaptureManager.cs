using UnityEngine;

namespace VRCapture.Demo {

    public class VideoCaptureManager : MonoBehaviour {

        bool enableMainCamera = false;
        bool enable360Camera = false;
        bool enableTopDownCamera = true;
        bool enableLeftRightCamera = true;
        bool enableOnlyAudio = false;

        void Start() {
            VRCapture.Instance.RegisterSessionCompleteDelegate(HandleCaptureFinish);
            //Application.runInBackground = true;
        }

        void OnGUI() {
            enableMainCamera = GUI.Toggle(
                new Rect(50, 50, 150, 50),
                enableMainCamera,
                " Enable Video Camera");
            if (enableMainCamera) {
                VRCapture.Instance.GetCaptureVideo(0).isEnabled = true;
            }
            else {
                VRCapture.Instance.GetCaptureVideo(0).isEnabled = false;
            }
            if (GUI.Button(new Rect(50, 350, 150, 50), "Capture Start")) {
                print("Capture Start");
                VRCapture.Instance.BeginCaptureSession();
            }
            if (GUI.Button(new Rect(50, 450, 150, 50), "Capture Stop")) {
                print("Capture Stop");
                VRCapture.Instance.EndCaptureSession();
            }
            if (GUI.Button(new Rect(50, 550, 150, 50), "Open Video Folder")) {
                System.Diagnostics.Process.Start(VRCapture.Instance.FolderPath);
            }
        }

        void HandleCaptureFinish() {
            print("Capture Finish");
        }
    }
}