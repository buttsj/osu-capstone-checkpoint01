using UnityEngine;
using UnityEngine.UI;

namespace VRCapture.Demo
{

    public class VideoCaptureManager : MonoBehaviour
    {

        bool enableMainCamera = false;
        bool enable360Camera = false;
        bool enableTopDownCamera = true;
        bool enableLeftRightCamera = true;
        public Text captureText;
        //bool enableOnlyAudio = false;

        void Start()
        {
            VRCapture.Instance.RegisterSessionCompleteDelegate(HandleCaptureFinish);
            Application.runInBackground = true;
            VRCapture.Instance.GetCaptureVideo(0).isEnabled = true;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V) && enable360Camera == false)
            {
                enable360Camera = true;
                print("Capture Start");
                captureText.text = "Capturing Video";
                VRCapture.Instance.BeginCaptureSession();
            }
            else if (Input.GetKeyDown(KeyCode.V) && enable360Camera == true)
            {
                enable360Camera = false;
                print("Capture Stop");
                captureText.text = "Capture Ended";
                VRCapture.Instance.EndCaptureSession();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                System.Diagnostics.Process.Start(VRCaptureConfig.SaveFolder);
            }
        }

        void HandleCaptureFinish()
        {
            print("Capture Finish");
        }
    }
}