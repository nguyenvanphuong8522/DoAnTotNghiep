using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : BasePopup
{
    public Slider slideMusic;
    public Slider slideSound;

    private void OnEnable()
    {
        UpdateSlide();
    }

    public void ChangeVolumeMusic()
    {
        AudioManager.instance.ChangeMusicVolume(slideMusic.value);
    }

    public void ChangeVolumeSound()
    {
        AudioManager.instance.ChangeSoundVolume(slideSound.value);
    }

    public void UpdateSlide()
    {
        slideMusic.value = DataPersist.VolumeMusic;
        slideSound.value = DataPersist.VolumeSound;
    }
    public override void Hide()
    {
        base.Hide();
        DataPersist.VolumeMusic = slideMusic.value;
        DataPersist.VolumeSound = slideSound.value;
    }
}
