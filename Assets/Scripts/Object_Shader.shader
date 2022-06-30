Shader "Custom/Object_Shadee" {
	Properties {
		_aTexture("Texture",2D) = "white"{}
	   _aBump("Bump", 2D) = "bump"{}
	   
	   
		
	}
	SubShader {
	

		CGPROGRAM
		
		#pragma surface surf Lambert 

		

		

		struct Input {
			float2 uv_aTexture;
			float2 uv_aBump;
			
		};

	   sampler2D _aTexture, _aBump;
		
		

		

		void surf (Input IN, inout SurfaceOutput Main) {
			Main.Albedo = tex2D(_aTexture, IN.uv_aTexture).rgb;
			Main.Normal = UnpackNormal(tex2D(_aBump, IN.uv_aBump));
			
		}
		
		ENDCG
	}
	FallBack "Diffuse"
}
