Shader "Custom/Sphere"
{
    Properties
    {
        _Centre("Centre",Vector) = (0,0,0)
        _Radius("Radius", float) = 30
        _MainTex("MainTex", 2D) = "white"{} 
        
    }
        SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 100
        Pass
        {
            ZWrite off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #include "Lighting.cginc"

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 pos : SV_POSITION;    // Clip space
                float3 wPos : TEXCOORD1;    // World position
            };

            float3 _Centre;
            fixed _Radius;

            // 判断是否进入球内
            bool sphereHit(float3 p)
            {
                return distance(p, _Centre) < _Radius;
            }

            //光线步进
            bool raymarchHit(float3 position, float3 direction)
            {
                float STEPS = 664;
                float STEP_SIZE = 0.1;
                for (int i = 0; i < STEPS; i++)
                {
                    if (sphereHit(position))
                        return true;

                    position += direction * STEP_SIZE;
                }

                return false;
            }

            //Texture Map
            fixed3 map(float3 p) 
            {
                float PI = 3.15;
                float lat = + 90. - acos(p.y / length(p)) * 180. / PI;
                float lon =  atan2(p.x, p.z) * 180. / PI;
                float2 uv = float2(lon / 360. + 0.5, lat / 180. + 0.5);
                return tex2D(_MainTex, uv).rgb;
            }


            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.wPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 worldPosition = i.wPos;
                float3 viewDirection = normalize(i.wPos - _WorldSpaceCameraPos);
                fixed3 texColor = map(i.wPos);
                
                if (raymarchHit(worldPosition, viewDirection))
                    return fixed4(texColor / 2, 1); // Red if hit the ball
                else
                    return fixed4(1,1,1,0); // White otherwise
            }
        ENDCG
        }
    }
}