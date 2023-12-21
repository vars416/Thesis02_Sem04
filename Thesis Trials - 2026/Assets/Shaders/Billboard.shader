Shader "Billboards" {
    Properties{
       _MainTex("Texture Image", 2D) = "white" {}
       _Color("Color", Color) = (1, 1, 1, 1)
       _ScaleX("Scale X", Float) = 1.0
       _ScaleY("Scale Y", Float) = 1.0
    }
        SubShader{
           Tags {
                "RenderType"="Transparent"
                "Queue"="Transparent"
           }
           Pass {
                Blend SrcAlpha OneMinusSrcAlpha
                ZWrite Off
                ZTest Off
              CGPROGRAM

              #pragma vertex vert  
              #pragma fragment frag

              // User-specified uniforms            
              uniform sampler2D _MainTex;
              uniform float _ScaleX;
              uniform float _ScaleY;
              uniform fixed4 _Color;

              struct vertexInput {
                 float4 vertex : POSITION;
                 float4 tex : TEXCOORD0;
                 float4 color : COLOR;
              };
              struct vertexOutput {
                 float4 pos : SV_POSITION;
                 float4 tex : TEXCOORD0;
                 float4 color : COLOR;
              };

              vertexOutput vert(vertexInput input)
              {
                 vertexOutput output;

                 output.pos = mul(UNITY_MATRIX_P,
                   mul(UNITY_MATRIX_MV, float4(0.0, 0.0, 0.0, 1.0))
                   + float4(input.vertex.x, input.vertex.y, 0.0, 0.0)
                   * float4(_ScaleX, _ScaleY, 1.0, 1.0));

                 output.tex = input.tex;
                 output.color = input.color;

                 return output;
              }

              float4 frag(vertexOutput input) : COLOR
              {
                 return tex2D(_MainTex, float2(input.tex.xy)) * _Color * input.color;
              }

              ENDCG
           }
       }
}
