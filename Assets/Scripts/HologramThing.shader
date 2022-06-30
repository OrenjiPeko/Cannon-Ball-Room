Shader "Custom/HologramThing" {
	Properties {
		_Color ("Color", Color) = (0,0.5,0.5,0)

		_RimPow ("Rim STR", Range(0,50)) = 3.0
	}
	SubShader {
		Tags { "Queue" = "Transparent" }

		pass
		{
		ZWrite off
		ColorMask 0 

		}

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert alpha:fade

		sampler2D _MainTex;


		struct Input 
		{
			float3 viewDir;
		};

		fixed4 _Color;
		float _RimPow;

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _Color.rgb * pow(rim, _RimPow);
			o.Alpha = pow(rim, _RimPow);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
