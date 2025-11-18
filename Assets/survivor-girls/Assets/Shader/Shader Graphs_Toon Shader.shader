Shader "Shader Graphs/Toon Shader" {
	Properties {
		[NoScaleOffset] _MainTex ("Texture2D", 2D) = "white" {}
		Color_70EBBDEE ("MainColor", Vector) = (1,1,1,0)
		[HDR] Color_F57A70D0 ("AmbientColor", Vector) = (0.7075472,0.7075472,0.7075472,0)
		[HDR] Color_DEE0E45B ("SpecularColor", Vector) = (1,1,1,0)
		Vector1_81088C75 ("Glossiness", Float) = 32
		[HDR] Color_CFC87909 ("RimColor", Vector) = (8,8,8,0)
		Vector1_242C9891 ("RimAmount", Range(0, 1)) = 0.7
		Vector1_99B978 ("RimTheshhold", Range(0, 1)) = 0.1
		[HideInInspector] _ComputeMeshIndex ("Compute Mesh Buffer Index Offset", Float) = 0
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
			float4 _MainTex_ST;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Vertex_Stage_Output
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.uv = (input.uv.xy * _MainTex_ST.xy) + _MainTex_ST.zw;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			Texture2D<float4> _MainTex;
			SamplerState sampler_MainTex;

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy);
			}

			ENDHLSL
		}
	}
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
}