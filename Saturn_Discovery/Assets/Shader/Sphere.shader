Shader "Custom/Sphere" {
    Properties{
        _EdgeLength("Edge length", Range(2,50)) = 5
        _Phong("Phong Strengh", Range(0,1)) = 0.5
        _MainTex("Base (RGB)", 2D) = "white" {}
        _Color("Color", color) = (1,1,1,0)
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 300

            CGPROGRAM
            #pragma surface surf BlinnPhong vertex:vert tessellate:tessEdge tessphong:_Phong nolightmap
            #include "Tessellation.cginc"

            sampler2D   _MainTex;
            fixed4      _Color;
            float       _Phong;
            float       _EdgeLength;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;

                fixed4 color : COLOR;
            };
            struct Input
            {
                float2 uv_MainTex;
                float3 color : COLOR;
            };
            

            void vert(inout appdata v) 
            {
                v.color = float4 (v.normal, 0.0);
            }

            float4 tessEdge(appdata v0, appdata v1, appdata v2)
            {
                return UnityEdgeLengthBasedTess(v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
            }

            void surf(Input IN, inout SurfaceOutput o)
            {
                const float PI = 3.14159265359;
                float3 direction = normalize(IN.color.xyz);
                float longitude = 0.5 - atan2(direction.z, direction.x) / (2.0f * PI);
                float latitude = 0.5 + asin(direction.y) / PI;
                float2 customUV = float2(longitude, latitude);

                fixed4 c = tex2D(_MainTex, customUV) * _Color;

                o.Albedo = c.rgb;
                o.Alpha = c.a;
            }

            ENDCG
        }
        FallBack "Diffuse"
}