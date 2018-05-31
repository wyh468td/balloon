using UnityEditor;

public class CreateAssetBundles
{
	[MenuItem ("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles ()
	{
		//BuildPipeline.BuildAssetBundles ("Assets/AssetBundlesOSX", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneOSXUniversal);
		BuildPipeline.BuildAssetBundles ("Assets/AssetBundlesAndroid", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
		BuildPipeline.BuildAssetBundles ("Assets/AssetBundlesIphone", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.iOS);
	}
}