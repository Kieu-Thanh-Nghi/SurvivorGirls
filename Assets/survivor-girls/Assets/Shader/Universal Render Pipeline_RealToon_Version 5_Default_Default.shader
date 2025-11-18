Shader "Universal Render Pipeline/RealToon/Version 5/Default/Default" {
	Properties {
		[Enum(UnityEngine.Rendering.CullMode)] _Culling ("Culling", Float) = 2
		[Toggle(N_F_TRANS_ON)] _TRANSMODE ("Transparent Mode", Float) = 0
		_MainTex ("Texture", 2D) = "white" {}
		[ToggleOff] _TexturePatternStyle ("Texture Pattern Style", Float) = 0
		[HDR] _MainColor ("Main Color", Vector) = (1,1,1,1)
		_MaiColPo ("Main Color Power", Float) = 0.8
		[ToggleOff] _MVCOL ("Mix Vertex Color", Float) = 0
		[ToggleOff] _MCIALO ("Main Color In Ambient Light Only", Float) = 0
		[HDR] _HighlightColor ("Highlight Color", Vector) = (1,1,1,1)
		_HighlightColorPower ("Highlight Color Power", Float) = 1
		_MCapIntensity ("Intensity", Range(0, 1)) = 1
		_MCap ("MatCap", 2D) = "white" {}
		[ToggleOff] _SPECMODE ("Specular Mode", Float) = 0
		_SPECIN ("Specular Power", Float) = 1
		_MCapMask ("Mask MatCap", 2D) = "white" {}
		_Cutout ("Cutout", Range(0, 1)) = 0
		[ToggleOff] _AlphaBaseCutout ("Alpha Base Cutout", Float) = 1
		[ToggleOff] _UseSecondaryCutout ("Use Secondary Cutout Only", Float) = 0
		_SecondaryCutout ("Secondary Cutout", 2D) = "white" {}
		[Toggle(N_F_COEDGL_ON)] _N_F_COEDGL ("Enable Glow Edge", Float) = 0
		[HDR] _Glow_Color ("Glow Color", Vector) = (1,1,1,1)
		_Glow_Edge_Width ("Glow Edge Width", Float) = 1
		[Toggle(N_F_SIMTRANS_ON)] _SimTrans ("Simple Transparency Mode", Float) = 0
		_Opacity ("Opacity", Range(0, 1)) = 1
		_TransparentThreshold ("Transparent Threshold", Float) = 0
		[Enum(UnityEngine.Rendering.BlendMode)] _BleModSour ("Blend - Source", Float) = 1
		[Enum(UnityEngine.Rendering.BlendMode)] _BleModDest ("Blend - Destination", Float) = 0
		_MaskTransparency ("Mask Transparency", 2D) = "black" {}
		[Toggle(N_F_TRANSAFFSHA_ON)] _TransAffSha ("Affect Shadow", Float) = 1
		_NormalMap ("Normal Map", 2D) = "bump" {}
		_NormalMapIntensity ("Normal Map Intensity", Float) = 1
		_Saturation ("Saturation", Range(0, 2)) = 1
		_OutlineWidth ("Width", Float) = 0.5
		_OutlineWidthControl ("Width Control", 2D) = "white" {}
		[Enum(Normal,0,Origin,1)] _OutlineExtrudeMethod ("Outline Extrude Method", Float) = 0
		_OutlineOffset ("Outline Offset", Vector) = (0,0,0,1)
		_OutlineZPostionInCamera ("Outline Z Position In Camera", Float) = 0
		[Enum(Off,1,On,0)] _DoubleSidedOutline ("Double Sided Outline", Float) = 1
		[HDR] _OutlineColor ("Color", Vector) = (0,0,0,1)
		[ToggleOff] _MixMainTexToOutline ("Mix Main Texture To Outline", Float) = 0
		_NoisyOutlineIntensity ("Noisy Outline Intensity", Range(0, 1)) = 0
		[Toggle(N_F_DNO_ON)] _DynamicNoisyOutline ("Dynamic Noisy Outline", Float) = 0
		[ToggleOff] _LightAffectOutlineColor ("Light Affect Outline Color", Float) = 0
		[ToggleOff] _OutlineWidthAffectedByViewDistance ("Outline Width Affected By View Distance", Float) = 0
		_FarDistanceMaxWidth ("Far Distance Max Width", Float) = 10
		[ToggleOff] _VertexColorBlueAffectOutlineWitdh ("Vertex Color Blue Affect Outline Witdh", Float) = 0
		_DepthThreshold ("Depth Threshold", Float) = 900
		[Toggle(N_F_O_MOTTSO_ON)] _N_F_MSSOLTFO ("Mix Outline To The Shader Output", Float) = 0
		_SelfLitIntensity ("Intensity", Range(0, 1)) = 0
		[HDR] _SelfLitColor ("Color", Vector) = (1,1,1,1)
		_SelfLitPower ("Power", Float) = 2
		_TEXMCOLINT ("Texture and Main Color Intensity", Float) = 1
		[ToggleOff] _SelfLitHighContrast ("High Contrast", Float) = 1
		_MaskSelfLit ("Mask Self Lit", 2D) = "white" {}
		_GlossIntensity ("Gloss Intensity", Range(0, 1)) = 1
		_Glossiness ("Glossiness", Range(0, 1)) = 0.6
		_GlossSoftness ("Softness", Range(0, 1)) = 0
		[HDR] _GlossColor ("Color", Vector) = (1,1,1,1)
		_GlossColorPower ("Color Power", Float) = 10
		_MaskGloss ("Mask Gloss", 2D) = "white" {}
		_GlossTexture ("Gloss Texture", 2D) = "black" {}
		_GlossTextureSoftness ("Softness", Float) = 0
		[ToggleOff] _PSGLOTEX ("Pattern Style", Float) = 0
		_GlossTextureRotate ("Rotate", Float) = 0
		[ToggleOff] _GlossTextureFollowObjectRotation ("Follow Object Rotation", Float) = 0
		_GlossTextureFollowLight ("Follow Light", Range(0, 1)) = 0
		[HDR] _OverallShadowColor ("Overall Shadow Color", Vector) = (0,0,0,1)
		_OverallShadowColorPower ("Overall Shadow Color Power", Float) = 1
		[ToggleOff] _SelfShadowShadowTAtViewDirection ("Self Shadow & ShadowT At View Direction", Float) = 0
		_ReduSha ("Reduce Shadow", Float) = 0.5
		_ShadowHardness ("Shadow Hardness", Range(0, 1)) = 0
		_SelfShadowRealtimeShadowIntensity ("Self Shadow & Realtime Shadow Intensity", Range(0, 1)) = 1
		_SelfShadowThreshold ("Threshold", Range(0, 1)) = 0.93
		[ToggleOff] _VertexColorGreenControlSelfShadowThreshold ("Vertex Color Green Control Self Shadow Threshold", Float) = 0
		_SelfShadowHardness ("Hardness", Range(0, 1)) = 1
		[HDR] _SelfShadowRealTimeShadowColor ("Self Shadow & Real Time Shadow Color", Vector) = (1,1,1,1)
		_SelfShadowRealTimeShadowColorPower ("Self Shadow & Real Time Shadow Color Power", Float) = 1
		[ToggleOff] _LigIgnoYNorDir ("Light Ignore Y Normal Direction", Float) = 0
		[ToggleOff] _SelfShadowAffectedByLightShadowStrength ("Self Shadow Affected By Light Shadow Strength", Float) = 0
		_SmoothObjectNormal ("Smooth Object Normal", Range(0, 1)) = 0
		[ToggleOff] _VertexColorRedControlSmoothObjectNormal ("Vertex Color Red Control Smooth Object Normal", Float) = 0
		_XYZPosition ("XYZ Position", Vector) = (0,0,0,0)
		[ToggleOff] _ShowNormal ("Show Normal", Float) = 0
		_ShadowColorTexture ("Shadow Color Texture", 2D) = "white" {}
		_ShadowColorTexturePower ("Power", Float) = 0
		_ShadowTIntensity ("ShadowT Intensity", Range(0, 1)) = 1
		_ShadowT ("ShadowT", 2D) = "white" {}
		_ShadowTLightThreshold ("Light Threshold", Float) = 50
		_ShadowTShadowThreshold ("Shadow Threshold", Float) = 0
		_ShadowTHardness ("Hardness", Range(0, 1)) = 1
		[HDR] _ShadowTColor ("Color", Vector) = (1,1,1,1)
		_ShadowTColorPower ("Color Power", Float) = 1
		[ToggleOff] _STIL ("Ignore Light", Float) = 0
		[Toggle(N_F_STIS_ON)] _N_F_STIS ("Show In Shadow", Float) = 0
		[Toggle(N_F_STIAL_ON )] _N_F_STIAL ("Show In Ambient Light", Float) = 0
		_ShowInAmbientLightShadowIntensity ("Show In Ambient Light & Shadow Intensity", Range(0, 1)) = 1
		_ShowInAmbientLightShadowThreshold ("Show In Ambient Light & Shadow Threshold", Float) = 0.4
		[ToggleOff] _LightFalloffAffectShadowT ("Light Falloff Affect ShadowT", Float) = 0
		_PTexture ("PTexture", 2D) = "white" {}
		_PTCol ("Color", Vector) = (0,0,0,1)
		_PTexturePower ("Power", Float) = 1
		[Toggle(N_F_RELGI_ON)] _RELG ("Receive Environmental Lighting and GI", Float) = 1
		_EnvironmentalLightingIntensity ("Environmental Lighting Intensity", Float) = 1
		[ToggleOff] _GIFlatShade ("GI Flat Shade", Float) = 0
		_GIShadeThreshold ("GI Shade Threshold", Range(0, 1)) = 0
		[ToggleOff] _LightAffectShadow ("Light Affect Shadow", Float) = 0
		_LightIntensity ("Light Intensity", Float) = 1
		[Toggle(N_F_USETLB_ON)] _UseTLB ("Use Traditional Light Blend", Float) = 0
		[Toggle(N_F_EAL_ON)] _N_F_EAL ("Enable Additional Lights", Float) = 1
		_DirectionalLightIntensity ("Directional Light Intensity", Float) = 0
		_PointSpotlightIntensity ("Point and Spot Light Intensity", Float) = 0
		_LightFalloffSoftness ("Light Falloff Softness", Range(0, 1)) = 1
		_CustomLightDirectionIntensity ("Intensity", Range(0, 1)) = 0
		[ToggleOff] _CustomLightDirectionFollowObjectRotation ("Follow Object Rotation", Float) = 0
		_CustomLightDirection ("Custom Light Direction", Vector) = (0,0,10,0)
		_ReflectionIntensity ("Intensity", Range(0, 1)) = 0
		_ReflectionRoughtness ("Roughness", Float) = 0
		_RefMetallic ("Metallic", Range(0, 1)) = 0
		_MaskReflection ("Mask Reflection", 2D) = "white" {}
		_FReflection ("FReflection", 2D) = "black" {}
		_RimLigInt ("Rim Light Intensity", Range(0, 1)) = 1
		_RimLightUnfill ("Unfill", Float) = 1.5
		[HDR] _RimLightColor ("Color", Vector) = (1,1,1,1)
		_RimLightColorPower ("Color Power", Float) = 10
		_RimLightSoftness ("Softness", Range(0, 1)) = 1
		[ToggleOff] _RimLightInLight ("Rim Light In Light", Float) = 1
		[ToggleOff] _LightAffectRimLightColor ("Light Affect Rim Light Color", Float) = 0
		_MinFadDistance ("Min Distance", Float) = 0
		_MaxFadDistance ("Max Distance", Float) = 2
		_RefVal ("ID", Float) = 0
		[Enum(Blank,8,A,0,B,2)] _Oper ("Set 1", Float) = 0
		[Enum(Blank,8,None,4,A,6,B,7)] _Compa ("Set 2", Float) = 4
		[Toggle(N_F_MC_ON)] _N_F_MC ("MatCap", Float) = 0
		[Toggle(N_F_NM_ON)] _N_F_NM ("Normal Map", Float) = 0
		[Toggle(N_F_CO_ON)] _N_F_CO ("Cutout", Float) = 0
		[Toggle(N_F_O_ON)] _N_F_O ("Outline", Float) = 1
		[Toggle(N_F_CA_ON)] _N_F_CA ("Color Adjustment", Float) = 0
		[Toggle(N_F_SL_ON)] _N_F_SL ("Self Lit", Float) = 0
		[Toggle(N_F_GLO_ON)] _N_F_GLO ("Gloss", Float) = 0
		[Toggle(N_F_GLOT_ON)] _N_F_GLOT ("Gloss Texture", Float) = 0
		[Toggle(N_F_SS_ON)] _N_F_SS ("Self Shadow", Float) = 1
		[Toggle(N_F_SON_ON)] _N_F_SON ("Smooth Object Normal", Float) = 0
		[Toggle(N_F_SCT_ON)] _N_F_SCT ("Shadow Color Texture", Float) = 0
		[Toggle(N_F_ST_ON)] _N_F_ST ("ShadowT", Float) = 0
		[Toggle(N_F_PT_ON)] _N_F_PT ("PTexture", Float) = 0
		[Toggle(N_F_CLD_ON)] _N_F_CLD ("Custom Light Direction", Float) = 0
		[Toggle(N_F_R_ON)] _N_F_R ("Relfection", Float) = 0
		[Toggle(N_F_FR_ON)] _N_F_FR ("FRelfection", Float) = 0
		[Toggle(N_F_RL_ON)] _N_F_RL ("Rim Light", Float) = 0
		[Toggle(N_F_NFD_ON)] _N_F_NFD ("Near Fade Dithering", Float) = 0
		[Toggle(N_F_HDLS_ON)] _N_F_HDLS ("Hide Directional Light Shadow", Float) = 0
		[Toggle(N_F_HPSS_ON)] _N_F_HPSS ("Hide Point & Spot Light Shadow", Float) = 0
		[Toggle(N_F_DCS_ON)] _N_F_DCS ("Disable Cast Shadow", Float) = 0
		[Toggle(N_F_NLASOBF_ON)] _N_F_NLASOBF ("No Light and Shadow On BackFace", Float) = 0
		[Toggle(N_F_ESSAO_ON)] _N_F_ESSAO ("Enable Screen Space Ambient Occlusion", Float) = 0
		[HDR] _SSAOColor ("Ambient Occlusion Color", Vector) = (0,0,0,0)
		[Toggle(N_F_RDC_ON)] _N_F_RDC ("Receive Decal", Float) = 1
		[Toggle(N_F_OFLMB_ON)] _N_F_OFLMB ("Optimize for [Light Mode: Baked]", Float) = 0
		[Toggle(N_F_DDMD_ON)] _N_F_DDMD ("Disable DOTS Mesh Deformation", Float) = 0
		[Enum(On, 1, Off, 0)] _ZWrite ("ZWrite", Float) = 1
		[HideInInspector] _SkinMatrixIndex ("Skin Matrix Index Offset", Float) = 0
		[HideInInspector] _ComputeMeshIndex ("Compute Mesh Buffer Index Offset", Float) = 0
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
	Fallback "Hidden/InternalErrorShader"
	//CustomEditor "RealToon.GUIInspector.RealToonShaderGUI_URP_SRP"
}