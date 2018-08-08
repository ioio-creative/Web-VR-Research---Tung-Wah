using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene1aGui : MonoBehaviour
{
    //public StoryStartControl storyStartManager;
    public GameObject SingleChoiceObjectBeforeStart;
    public VRInput vrCamera;

    public AudioClip heartBeatClip;
    public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();


        /* adding text contents */

        DoubleTextStatement Stat0_0 = new DoubleTextStatement(Color.white, "- 你來了 -",
            "一切，無聲無息，無從解釋", GuiPrefabUtils.DoubleTextFirstGazeDuration,
            GuiPrefabUtils.DoubleTextSecondGazeDuration, vrCamera, myGuiModels);
        Stat0_0.AddPlayAnimationOnDoubleTextGazeComplete(heartBeatAnim);

        SingleTextStatement Stat0_2 = new SingleTextStatement(Color.white,
            "漸漸的，你開始聽到心臟微微跳動\n感受到身體被一種暖流包裹", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);
        Stat0_2.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, true,
            heartBeatClip);

        SingleTextStatement Stat0_3 = new SingleTextStatement(Color.white,
            "生命，悄悄滋長 ……", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleChoiceQuestion Q1 = new SingleChoiceQuestion(Color.white,
            "你願意來到這個世界\n經歷這一趟人生旅程嗎？", "我願意", vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat0_0.AddNextStory(Stat0_2);
        Stat0_2.AddNextStory(Stat0_3);
        Stat0_3.AddNextStory(Q1);
        Q1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene1bName);

        /* end of setting next stories or next scenes */


        /* setting start gui */

        //Stat0_0.SetAsStartGui(storyStartManager);

        // Hard coded here
        NextStory nextStoryOfStartObj =
            SingleChoiceObjectBeforeStart.transform.Find("SelectionSlider").GetComponent<NextStory>();
        nextStoryOfStartObj.nextUiFader = GuiPrefabUtils.GetUiFader(Stat0_0.underlyingGameObj);
        nextStoryOfStartObj.nextDoubleTextForGaze = GuiPrefabUtils.GetDoubleTextForGaze(Stat0_0.underlyingGameObj);

        /* end of setting start gui */


        /* activating guis */
        // [Important] This is needed because the prefab game objects are set to be inactive so that the OnEnable event is not called during Prefab Instantiation.

        foreach (GuiModelBase myGuiModel in myGuiModels)
        {
            myGuiModel.SetActive(true);
        }

        /* end of activating guis */
    }
}