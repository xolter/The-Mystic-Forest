using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class OptionsSettingManager : MonoBehaviour {

	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Slider musicVolumeSlider;

	public AudioSource musicSource;
	public Resolution[] resolutions;
	public string[] qualitylvl;
	OptionsSettings gameSettings;

	void OnEnable()
	{
		gameSettings = new OptionsSettings();
		fullscreenToggle.onValueChanged.AddListener (delegate {
			OnFullscreenToggle ();
		});
		resolutionDropdown.onValueChanged.AddListener (delegate {
			OnResolutionChange ();
		});
		textureQualityDropdown.onValueChanged.AddListener (delegate {
			OnTextureQualityChange ();
		});
		musicVolumeSlider.onValueChanged.AddListener (delegate {
			OnMusicVolumeChange ();
		});
			
		resolutions = Screen.resolutions;
		foreach (Resolution resolutoin in resolutions)
		{
			resolutionDropdown.options.Add(new Dropdown.OptionData(resolutoin.ToString()));
		}
	}

	public void OnFullscreenToggle()
	{
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}
	public void OnResolutionChange()
	{
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen);
		gameSettings.resolutionIndex = resolutionDropdown.value;
	}
	public void OnTextureQualityChange()
	{
		if (textureQualityDropdown.value == 0)
		{
			QualitySettings.pixelLightCount = 0;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
			QualitySettings.antiAliasing = 0;
			QualitySettings.masterTextureLimit = 2;
			QualitySettings.shadows = ShadowQuality.Disable;
			QualitySettings.shadowResolution = ShadowResolution.Low;
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
			QualitySettings.shadowDistance = 15;
			QualitySettings.shadowCascades = 0;
			QualitySettings.blendWeights = BlendWeights.OneBone;
			QualitySettings.particleRaycastBudget = 4;
			QualitySettings.lodBias = 0.3f;
			gameSettings.textureQuality = 0;
		}
		else if (textureQualityDropdown.value == 1)
		{
			QualitySettings.pixelLightCount = 0;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
			QualitySettings.antiAliasing = 0;
			QualitySettings.masterTextureLimit = 0;
			QualitySettings.shadows = ShadowQuality.Disable;
			QualitySettings.shadowResolution = ShadowResolution.Low;
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
			QualitySettings.shadowDistance = 20;
			QualitySettings.shadowCascades = 0;
			QualitySettings.blendWeights = BlendWeights.TwoBones;
			QualitySettings.particleRaycastBudget = 16;
			QualitySettings.lodBias = 0.4f;
			gameSettings.textureQuality = 1;
		}
		else if (textureQualityDropdown.value == 2)
		{
			QualitySettings.pixelLightCount = 1;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
			QualitySettings.antiAliasing = 0;
			QualitySettings.masterTextureLimit = 0;
			QualitySettings.shadows = ShadowQuality.HardOnly;
			QualitySettings.shadowResolution = ShadowResolution.Low;
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
			QualitySettings.shadowDistance = 20;
			QualitySettings.shadowCascades = 0;
			QualitySettings.blendWeights = BlendWeights.TwoBones;
			QualitySettings.particleRaycastBudget = 64;
			QualitySettings.lodBias = 0.7f;
			gameSettings.textureQuality = 2;
		}
		else if (textureQualityDropdown.value == 3)
		{
			QualitySettings.pixelLightCount = 2;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
			QualitySettings.antiAliasing = 0;
			QualitySettings.masterTextureLimit = 0;
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = ShadowResolution.Medium;
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
			QualitySettings.shadowDistance = 40;
			QualitySettings.shadowCascades = 2;
			QualitySettings.blendWeights = BlendWeights.TwoBones;
			QualitySettings.particleRaycastBudget = 256;
			QualitySettings.lodBias = 1;
			gameSettings.textureQuality = 3;
		}
		else if (textureQualityDropdown.value == 4)
		{
			QualitySettings.pixelLightCount = 3;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
			QualitySettings.antiAliasing = 2;
			QualitySettings.masterTextureLimit = 0;
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = ShadowResolution.High;
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
			QualitySettings.shadowDistance = 70;
			QualitySettings.shadowCascades = 2;
			QualitySettings.blendWeights = BlendWeights.FourBones;
			QualitySettings.particleRaycastBudget = 1024;
			QualitySettings.lodBias = 1.5f;
			gameSettings.textureQuality = 4;
		}
		else
		{
			QualitySettings.pixelLightCount = 4;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
			QualitySettings.antiAliasing = 2;
			QualitySettings.masterTextureLimit = 0;
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = ShadowResolution.High;
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
			QualitySettings.shadowDistance = 150;
			QualitySettings.shadowCascades = 4;
			QualitySettings.blendWeights = BlendWeights.FourBones;
			QualitySettings.particleRaycastBudget = 4096;
			QualitySettings.lodBias = 2;
			gameSettings.textureQuality = 5;
		}
	}
	public void OnMusicVolumeChange()
	{
		musicSource.volume = gameSettings.musicvolume = musicVolumeSlider.value;
	}
}
