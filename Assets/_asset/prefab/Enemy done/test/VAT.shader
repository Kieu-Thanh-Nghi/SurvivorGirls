Shader "Custom/VAT"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PosTex ("Position Tex", 2D) = "white" {}
        _Frame ("Frame", Float) = 0
        _TotalFrames ("Total Frames", Float) = 1
    }

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            sampler2D _PosTex;

            float _Frame;
            float _TotalFrames;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 uv2 : TEXCOORD1; // 👈 dùng để lưu vertex index
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;

                float vertexIndex = v.uv2.x;
                float frame = _Frame;

                float2 texUV;
                texUV.x = vertexIndex;
                texUV.y = frame / _TotalFrames;

                float3 pos = tex2Dlod(_PosTex, float4(texUV,0,0)).xyz;

                o.vertex = UnityObjectToClipPos(float4(pos,1));
                o.uv = v.uv;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}