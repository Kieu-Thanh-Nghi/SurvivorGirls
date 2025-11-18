Shader "Custom/FX_Shader" {
	Properties {
		[HDR] _Color ("Color", Vector) = (1,1,1,1)
		_Pow ("Pow", Range(1, 100)) = 1
		_Brightness ("Brightness", Range(0, 100)) = 1
		[ToggleUI] _Base1_On ("Base1_On", Float) = 0
		_Base1 ("Base1", 2D) = "white" {}
		[ToggleUI] _Base1_Rot_1_57_Ani ("Base1_Rot(1.57)Ani", Float) = 0
		_Base1_Rot_1_57 ("Base1_Rot(1.57)", Float) = 0
		_Base1_XY ("Base1_XY", Vector) = (0,0,0,0)
		_Base2 ("Base2", 2D) = "white" {}
		_Base2_Rot_1_57 ("Base2_Rot(_1.57)", Float) = 0
		_Base2_XY ("Base2_XY", Vector) = (0,0,0,0)
		_Noise ("Noise", 2D) = "white" {}
		_Noise_pow ("Noise pow", Range(-1, 1)) = 0
		_Noise_Rot_1_57 ("Noise Rot_1.57", Float) = 0
		_Noise_XY ("Noise_XY", Vector) = (0,0,0,0)
		[HideInInspector] _CastShadows ("_CastShadows", Float) = 0
		[HideInInspector] _Surface ("_Surface", Float) = 1
		[HideInInspector] _Blend ("_Blend", Float) = 2
		[HideInInspector] _AlphaClip ("_AlphaClip", Float) = 0
		[HideInInspector] _SrcBlend ("_SrcBlend", Float) = 1
		[HideInInspector] _DstBlend ("_DstBlend", Float) = 0
		[ToggleUI] [HideInInspector] _ZWrite ("_ZWrite", Float) = 0
		[HideInInspector] _ZWriteControl ("_ZWriteControl", Float) = 0
		[HideInInspector] _ZTest ("_ZTest", Float) = 4
		[HideInInspector] _Cull ("_Cull", Float) = 0
		[HideInInspector] _AlphaToMask ("_AlphaToMask", Float) = 0
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
			};

			struct Vertex_Stage_Output
			{
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			float4 _Color;

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return _Color; // RGBA
			}

			ENDHLSL
		}
	}
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
}