using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene2aGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioClip alarmClip;
    public AudioSource[] AudSrcsToFadeOut;

    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

        
        /* adding text contents */

        DoubleTextStatement Stat0_0_1= new DoubleTextStatement(Color.white,
            "- 13歲 -", "中二生\n踏上求學生涯，每天學琴、做功課 ……",
            GuiPrefabUtils.DoubleTextFirstGazeDuration, GuiPrefabUtils.DoubleTextSecondGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat0_0_2 = new SingleTextStatement(Color.white,
            "起床了 ……", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        Stat0_0_2.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, false, alarmClip);

        DoubleChoiceQuestion Q1 = new DoubleChoiceQuestion(Color.white,
            "昨晚你做功課到十二點多\n現在卻要六點起床", "多睡五分鐘", "準時起床",
            vrCamera, myGuiModels, SceneSwitchControl.Scene2Q1Name);

        Q1.AddStoreTwoSelectionChoice(SceneSwitchControl.Scene2Q1Name);



        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat0_0_1.AddNextStory(Stat0_0_2);
        Stat0_0_2.AddNextStory(Q1);
        Q1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene2bName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider1, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        Q1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene2bName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider2, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);


        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat0_0_1.SetAsStartGui(storyStartManager);

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