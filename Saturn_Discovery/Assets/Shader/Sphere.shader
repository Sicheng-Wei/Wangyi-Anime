Shader "Custom/Sphere"
{
    Properties
    {
        // Sphere Parameters
        //_Centre("Centre",Vector) = (0,0,0)
        _Radius("Radius", float) = 30
        _MainTex("MainTex", 2D) = "white"{}
        
        // Lighting Parameters
        _Steps("Step", int) = 1000
        _StepSize("StepSize", float) = 0.01
        _Diffuse("Diffuse Color", Color) = (1, 1, 1, 1)
    }
    
    SubShader
    {
        Tags { "LightMode"="ForwardBase" "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 100
        Pass
        {
            ZWrite off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            
            #include "Lighting.cginc"
            #include "UnityCG.cginc"

            #pragma vertex vert
            #pragma fragment frag

            // Sphere Parameters
            fixed       _Radius = 30;
            sampler2D   _MainTex;
          
            // Lighting Parameters
            int         _Steps;
            float       _StepSize;
            fixed4      _Diffuse;

            struct a2v
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;   // Clip space
                float3 wPos : TEXCOORD1;    // World position
                float3 wNom : TEXCOORD0;    // World normal
            };

            // 判断是否进入球内
            bool sphereHit(float3 p)
            {
                return distance(p, unity_ObjectToWorld._14_24_34) < _Radius;
            }

            //光线步进
            bool raymarchHit(float3 position, float3 direction)
            {
                for (int i = 0; i < _Steps; i++)
                {
                    if (sphereHit(position)) return true;
                    position += direction * _StepSize;
                }
                return false;
            }

            //Texture Map
            fixed3 map(float3 p, fixed3 lightDir) 
            {
                float PI = 3.1415926535;
                float lat = + 90. - acos(p.y / length(p)) * 180. / PI;
                float lon =  atan2(p.x, p.z) * 180. / PI;
                float2 uv = float2(lon / 360. + 0.5, lat / 180. + 0.5);
                return tex2D(_MainTex, uv).rgb * _LightColor0.rgb * dot(lightDir, normalize(p));
            }

            v2f vert(a2v v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.wPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.wNom = UnityObjectToWorldNormal(o.wPos);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 worldPos = float3(i.wPos.x, i.wPos.y, i.wPos.z);
                float3 viewDir = normalize(i.wPos - _WorldSpaceCameraPos);

                fixed3 normalDir = normalize(i.wNom);
                fixed3 lightDir = normalize(WorldSpaceLightDir(float4(i.wPos, 1)));

                fixed3 finalColor = map(worldPos, lightDir);
                
                if (raymarchHit(worldPos, viewDir)) return fixed4(finalColor, 1);       // Tex if hit the ball
                else return fixed4(1, 1, 1, 0);                                         // Transparent otherwise
            }
        ENDCG
        }
    }
}

//Shader "Phong Tessellation" {
//    Properties{
//        _EdgeLength("Edge length", Range(2,50)) = 5
//        _Phong("Phong Strengh", Range(0,1)) = 0.5
//        _MainTex("Base (RGB)", 2D) = "white" {}
//        _Color("Color", color) = (1,1,1,0)
//    }
//        SubShader{
//            Tags { "RenderType" = "Opaque" }
//            LOD 300
//
//            CGPROGRAM
//            #pragma surface surf Lambert vertex:dispNone tessellate:tessEdge tessphong:_Phong nolightmap
//            #include "Tessellation.cginc"
//
//            struct appdata {
//                float4 vertex : POSITION;
//                float3 normal : NORMAL;
//                float2 texcoord : TEXCOORD0;
//            };
//
//            void dispNone(inout appdata v) { }
//
//            float _Phong;
//            float _EdgeLength;
//
//            float4 tessEdge(appdata v0, appdata v1, appdata v2)
//            {
//                return UnityEdgeLengthBasedTess(v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
//            }
//
//            struct Input {
//                float2 uv_MainTex;
//            };
//
//            fixed4 _Color;
//            sampler2D _MainTex;
//
//            void surf(Input IN, inout SurfaceOutput o) {
//                half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
//                o.Albedo = c.rgb;
//                o.Alpha = c.a;
//            }
//
//            ENDCG
//        }
//            FallBack "Diffuse"
//}