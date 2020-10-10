using System;
using System.Collections;
using System.Collections.Generic;

namespace Kogane
{
	/// <summary>
	/// Addressables で読み込んでメモリに載っているアセットバンドルのリストを管理するクラス
	/// </summary>
	public sealed class AddressablesOnMemoryAssetBundleList :
		IDisposable,
		IReadOnlyList<JsonAssetBundleResourceData>
	{
		//================================================================================
		// 変数(readonly)
		//================================================================================
		private readonly List<JsonAssetBundleResourceData> m_list = new List<JsonAssetBundleResourceData>();

		//================================================================================
		// プロパティ
		//================================================================================
		public int Count => m_list.Count;

		public JsonAssetBundleResourceData this[ int index ] => m_list[ index ];

		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AddressablesOnMemoryAssetBundleList()
		{
			AssetBundleResourceWithCallback.OnSuccess += OnSuccess;
			AssetBundleResourceWithCallback.OnUnload  += OnUnload;
		}

		/// <summary>
		/// 破棄します
		/// </summary>
		public void Dispose()
		{
			AssetBundleResourceWithCallback.OnSuccess -= OnSuccess;
			AssetBundleResourceWithCallback.OnUnload  -= OnUnload;
		}

		/// <summary>
		/// アセットバンドルの読み込みに成功した時に呼び出されます
		/// </summary>
		private void OnSuccess( JsonAssetBundleResourceData data )
		{
			m_list.Add( data );
		}

		/// <summary>
		/// アセットバンドルをアンロードした時に呼び出されます
		/// </summary>
		private void OnUnload( JsonAssetBundleResourceData data )
		{
			m_list.Remove( data );
		}

		/// <summary>
		/// メモリに載っているアセットバンドルのリストを返します
		/// </summary>
		public IEnumerator<JsonAssetBundleResourceData> GetEnumerator()
		{
			foreach ( var x in m_list )
			{
				yield return x;
			}
		}

		/// <summary>
		/// メモリに載っているアセットバンドルのリストを返します
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}