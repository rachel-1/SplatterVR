Shader "BlendedDecal"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	
	SubShader
	{
		Lighting Off
		ZTest LEqual
		ZWrite Off
		Tags {"Queue" = "Transparent"}
		Pass
		{
			//Alphatest Greater 0.4
			Blend SrcAlpha OneMinusSrcAlpha
			Offset -1, -1

			SetTexture [_MainTex]
			{
				//ConstantColor primary // (.25, .7, .3, 1)
				Combine primary, texture
			}
		}
	}
}