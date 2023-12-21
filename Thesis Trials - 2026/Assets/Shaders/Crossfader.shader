Shader "Custom/Crossfader"
{
    Properties
    {
        _MainTex("Render Texture 1", 2D) = "white" {}
        _MainTex2("Render Texture 2", 2D) = "white" {}
        _Fade("Crossfade", Range(0,1)) = 0.5
        _Color("Tint", Color) = (1,1,1,1)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };
                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };
                sampler2D _MainTex;
                float4 _MainTex_ST;
                sampler2D _MainTex2;
                //float4 _MainTex2_ST;
                float _Fade;
                float4 _Color;
                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    UNITY_TRANSFER_FOG(o,o.vertex);
                    return o;
                }
                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);
                    fixed4 col2 = tex2D(_MainTex2, i.uv);
                    fixed4 result = lerp(col, col2, _Fade) * _Color;
                    return result;
                }
                ENDCG
            }
        }
}
