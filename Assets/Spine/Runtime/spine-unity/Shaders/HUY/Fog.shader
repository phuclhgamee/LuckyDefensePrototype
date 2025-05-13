Shader "Custom/UIAlphaCircle"
{
    Properties
    {
        _Radius ("Radius", Range(0, 1)) = 0.25
        _Color ("Color", Color) = (1, 1, 1, 0)
        _Center ("Center", Range(0.0, 1)) = 0.5
        _Smooth ("Smooth", Range(0.0, 0.5)) = 0.01
        _Height ("Height", Float) = 1920
        _Width ("Width", Float) = 1080
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            float _Radius;
            fixed4 _Color;
            float _Center;
            float _Smooth;
            float _Height;
            float _Width;
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float x = min(_Height, _Width);
                float2 center = float2(0.5 * _Height, 0.5 * _Width);
                float r = _Radius * x;
                float2 newi = float2(i.uv.x * _Height, i.uv.y * _Width);
                float distance = sqrt((newi.x-center.x)*(newi.x-center.x)+(newi.y-center.y)*(newi.y-center.y));\
                float alpha;
                if(distance > r)
                    alpha = 1;
                else alpha = distance / r;
                fixed4 col = _Color;
                col.a *= alpha;
                return col;
            }
            ENDCG
        }
    }
}







