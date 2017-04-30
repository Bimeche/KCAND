Shader "Custom/NewShader" {
	 SubShader {Pass {
     GLSLPROGRAM
     varying lowp vec2 uv;
     #ifdef VERTEX
     void main() {
         gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
         uv = gl_MultiTexCoord0.xy;
     }
     #endif
     #ifdef FRAGMENT
     uniform lowp sampler2D _MainTex;
     void main() {
         gl_FragColor = texture2D(_MainTex, uv);
     }
     #endif      
     ENDGLSL
 }}
 SubShader {Pass {
     SetTexture[_MainTex]
 }}
}
