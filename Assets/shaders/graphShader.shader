Shader "Graph/Point Surface" {

	Properties {
		_smoothness ("Smoothness", Range(0, 1)) = 0.5
	}

	SubShader {
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		#pragma target 3.0

		struct Input
		{
			float3 worldPos;
		};

		// use '_' to configure in the editor
		float _smoothness;
		void ConfigureSurface(Input input, inout SurfaceOutputStandard surface)
		{
			surface.Albedo = saturate(input.worldPos * 0.5 + 0.5); // saturate is added to clamp the value between 0 to 1
			surface.Smoothness = _smoothness;
		}
		ENDCG
	}

	Fallback "Diffuse"

}
