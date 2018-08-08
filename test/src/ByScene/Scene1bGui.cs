using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene1bGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioClip drinkMilk;
    public AudioSource[] AudSrcsToFadeOut;
       
    
    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();


        /* adding text contents */

        SingleTextStatement Stat2_0 = new SingleTextStatement(
            "你\n初生於這個家的小男孩", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        //Stat2_0.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, false, babyCry);

        SingleTextStatement Stat2_1 = new SingleTextStatement(
            "有關生活的需要，衣服、食物、玩具 ……\n你爸爸媽媽都為你準備好", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        DoubleChoiceQuestion Q2 = new DoubleChoiceQuestion(
            "即使你討厭牛奶的味道\n媽媽卻每天早上為你準備 ……", "不情願地\n喝一口", "閉上眼睛\n一口喝完",
            vrCamera, myGuiModels, SceneSwitchControl.Scene1Q2Name);

        Q2.SetOnFilledAudioClipForSlider1(drinkMilk);
        Q2.SetOnFilledAudioClipForSlider2(drinkMilk);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat2_0.AddNextStory(Stat2_1);
        Stat2_1.AddNextStory(Q2);
        Q2.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene1cName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider1, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        Q2.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene1cName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider2, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);


        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat2_0.SetAsStartGui(storyStartManager);

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