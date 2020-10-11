# UniAddressablesOnMemoryAssetBundleList

Addressable で読み込んで現在メモリに載っているアセットバンドルの一覧を取得できるクラス

## 依存するパッケージ

```
https://github.com/baba-s/UniAssetBundleProviderWithCallback.git
https://github.com/baba-s/UniJsonAssetBundleResourceData.git
```

## 使用例

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private readonly AddressablesOnMemoryAssetBundleList m_list
        = new AddressablesOnMemoryAssetBundleList();

    private void Awake()
    {
        DontDestroyOnLoad( gameObject );
    }

    private void OnDestroy()
    {
        m_list.Dispose();
    }

    private void OnGUI()
    {
        foreach ( var x in m_list )
        {
            GUILayout.Label( x.Url );
        }
    }
}
```
