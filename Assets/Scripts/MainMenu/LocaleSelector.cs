using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    Coroutine changeLocaleCoroutine;

    IEnumerator SetLocale(int _localeID) {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = 
            LocalizationSettings.AvailableLocales.Locales[_localeID];
        changeLocaleCoroutine = null;
    }

    public void ChangeLocale(int _localeID) {
        if (changeLocaleCoroutine != null) return;
        changeLocaleCoroutine = StartCoroutine(SetLocale(_localeID));
    }
}
