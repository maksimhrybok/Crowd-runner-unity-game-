using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform runnersParent;
    [SerializeField] private RunnerSelector runnerSelectorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ShopManager.onSkinSelected += SelectSkin;
    }

    private void OnDestroy()
    {
        ShopManager.onSkinSelected -= SelectSkin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SelectSkin(Random.Range(0, 9));
    }

    //public void SelectSkin(int skinIndex)
    //{
    //    for (int i = 0; i < runnersParent.childCount; i++)
    //        runnersParent.GetChild(i).GetComponent<RunnerSelector>().SelectRunner(skinIndex);
    //}

    public void SelectSkin(int skinIndex)
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Transform runner = runnersParent.GetChild(i);
            Runner runnerScript = runner.GetComponent<Runner>();

            if (runnerScript != null)
            {
                // Находим новый скин
                Transform newSkin = runner.Find($"Skin {skinIndex:D2}");
                if (newSkin != null)
                {
                    // Включаем новый скин
                    newSkin.gameObject.SetActive(true);

                    // Обновляем ссылку на Animator
                    Animator newAnimator = newSkin.GetComponent<Animator>();
                    runnerScript.SetAnimator(newAnimator);
                }

                // Выключаем остальные скины
                for (int j = 0; j < runner.childCount; j++)
                {
                    if (runner.GetChild(j) != newSkin)
                    {
                        runner.GetChild(j).gameObject.SetActive(false);
                    }
                }
            }
        }

        runnerSelectorPrefab.SelectRunner(skinIndex);
    }

}
