Shader "Asylum/Sketch" {
	Properties{
		_Hatch0("Hatch 0", 2D) = "black" {}
		_Hatch1("Hatch 1", 2D) = "white" {}
		_Hatch2("Hatch 2", 2D) = "white" {}
		_Hatch3("Hatch 3", 2D) = "white" {}
		_Hatch4("Hatch 4", 2D) = "white" {}
		_Hatch5("Hatch 5", 2D) = "white" {}
		_Intensity("Intensity", Float) = 1.0
		_Propagation("Propagation", Float) = 0.05
	}
	SubShader{
		Tags{ "RenderType" = "Opaque" }

		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf SimpleLambert

		sampler2D _Hatch0;
		sampler2D _Hatch1;
		sampler2D _Hatch2;
		sampler2D _Hatch3;
		sampler2D _Hatch4;
		sampler2D _Hatch5;
		uniform float _Intensity;
		uniform float _Propagation;

		half4 LightingSimpleLambert_PrePass(inout SurfaceOutput s, half4 lightDir)
		{
			float2 uv = s.Albedo.xy * 10;
			s.Albedo = 0.0;

			half NdotL = dot(s.Normal, lightDir);
			half diff = NdotL;// * 0.75 + 0.25;
			half4 c;

			half lightColor = _LightColor0.r + _LightColor0.g + _LightColor0.b;
			half intensity = lightDir * _Intensity - _Propagation;
			//intensity = saturate(intensity);

			float part = 1 / 6.0;
			// KLUDGE: with "if" instead of "else if" lines between regions are invisible		
			if (intensity <= part)
			{
				float temp = intensity;
				temp *= 6;
				c.rgb = lerp(tex2D(_Hatch0, uv), tex2D(_Hatch1, uv), temp);
			}
			if (intensity > part && intensity <= part * 2)
			{
				float temp = intensity - part;
				temp *= 6;
				c.rgb = lerp(tex2D(_Hatch1, uv), tex2D(_Hatch2, uv), temp);
			}
			if (intensity > part * 2 && intensity <= part * 3)
			{
				float temp = intensity - part * 2;
				temp *= 6;
				c.rgb = lerp(tex2D(_Hatch2, uv), tex2D(_Hatch3, uv), temp);
			}
			if (intensity > part * 3 && intensity <= part * 4)
			{
				float temp = intensity - part * 3;
				temp *= 6;
				c.rgb = lerp(tex2D(_Hatch3, uv), tex2D(_Hatch4, uv), temp);
			}
			if (intensity > part * 4 && intensity <= part * 5)
			{
				float temp = intensity - part * 4;
				temp *= 6;
				c.rgb = lerp(tex2D(_Hatch4, uv), tex2D(_Hatch5, uv), temp);
			}
			if (intensity > part * 5)
			{
				float temp = intensity - part * 5;
				temp *= 6;
				c.rgb = lerp(tex2D(_Hatch5, uv), 1, temp);
			}
			c.r *= lightDir.r;
			c.g *= lightDir.g;
			c.b *= lightDir.b;
			return c;
		}

		struct Input
		{
			float2 uv_Hatch0;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo.xy = IN.uv_Hatch0;
		}
		ENDCG
	}
	Fallback "VertexLit"
}