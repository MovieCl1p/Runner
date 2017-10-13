// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:2,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:8817,x:33577,y:32479,varname:node_8817,prsc:2|custl-8591-OUT,clip-5458-OUT;n:type:ShaderForge.SFN_DDX,id:3619,x:31926,y:33238,varname:node_3619,prsc:2|IN-448-RGB;n:type:ShaderForge.SFN_VertexColor,id:448,x:31598,y:33593,varname:node_448,prsc:2;n:type:ShaderForge.SFN_DDY,id:2683,x:31908,y:33391,varname:node_2683,prsc:2|IN-448-RGB;n:type:ShaderForge.SFN_Abs,id:1470,x:32150,y:33327,varname:node_1470,prsc:2|IN-3619-OUT;n:type:ShaderForge.SFN_Abs,id:5370,x:32139,y:33456,varname:node_5370,prsc:2|IN-2683-OUT;n:type:ShaderForge.SFN_Add,id:2468,x:32375,y:33415,varname:node_2468,prsc:2|A-1470-OUT,B-5370-OUT;n:type:ShaderForge.SFN_Smoothstep,id:7281,x:32863,y:33523,varname:node_7281,prsc:2|A-1059-OUT,B-6199-OUT,V-448-RGB;n:type:ShaderForge.SFN_Vector1,id:1059,x:32651,y:33523,varname:node_1059,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:8802,x:32658,y:33042,varname:node_8802,prsc:2|A-4512-OUT,B-6443-OUT;n:type:ShaderForge.SFN_Slider,id:6443,x:32270,y:33039,ptovrint:False,ptlb:LineBrightness,ptin:_LineBrightness,varname:_LineBrightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.752,max:3;n:type:ShaderForge.SFN_Multiply,id:6199,x:32651,y:33680,varname:node_6199,prsc:2|A-2468-OUT,B-9418-OUT;n:type:ShaderForge.SFN_Slider,id:9418,x:32166,y:33791,ptovrint:False,ptlb:LineThickness,ptin:_LineThickness,varname:_LineThickness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Min,id:4688,x:33319,y:33509,varname:node_4688,prsc:2|A-6246-R,B-6246-G;n:type:ShaderForge.SFN_Min,id:5092,x:33319,y:33627,varname:node_5092,prsc:2|A-4688-OUT,B-6246-B;n:type:ShaderForge.SFN_ComponentMask,id:6246,x:33057,y:33571,varname:node_6246,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-7281-OUT;n:type:ShaderForge.SFN_OneMinus,id:4512,x:33540,y:33601,varname:node_4512,prsc:2|IN-5092-OUT;n:type:ShaderForge.SFN_Fresnel,id:9227,x:32587,y:32704,varname:node_9227,prsc:2|EXP-8722-OUT;n:type:ShaderForge.SFN_Slider,id:8722,x:32238,y:32779,ptovrint:False,ptlb:Fresnel,ptin:_Fresnel,varname:_Fresnel,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.4,max:5;n:type:ShaderForge.SFN_Add,id:1627,x:32682,y:32894,varname:node_1627,prsc:2|A-9227-OUT,B-8802-OUT;n:type:ShaderForge.SFN_Multiply,id:3128,x:32897,y:32619,varname:node_3128,prsc:2|A-5979-RGB,B-1627-OUT;n:type:ShaderForge.SFN_Color,id:5979,x:32238,y:32525,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.03921569,c2:0.3686275,c3:0.6039216,c4:1;n:type:ShaderForge.SFN_Add,id:2480,x:33274,y:33082,varname:node_2480,prsc:2|A-588-OUT,B-4689-OUT;n:type:ShaderForge.SFN_Sin,id:5937,x:33637,y:33082,varname:node_5937,prsc:2|IN-4554-OUT;n:type:ShaderForge.SFN_RemapRange,id:5458,x:33809,y:33082,varname:node_5458,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-5937-OUT;n:type:ShaderForge.SFN_Multiply,id:4689,x:32974,y:33184,varname:node_4689,prsc:2|A-4901-OUT,B-448-A;n:type:ShaderForge.SFN_Multiply,id:4554,x:33447,y:33082,varname:node_4554,prsc:2|A-2480-OUT,B-599-OUT;n:type:ShaderForge.SFN_Slider,id:599,x:33117,y:33230,ptovrint:False,ptlb:WobbleSpeed,ptin:_WobbleSpeed,varname:_WobbleSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Vector1,id:4901,x:32778,y:33184,varname:node_4901,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:8370,x:32788,y:32959,ptovrint:False,ptlb:Fade,ptin:_Fade,varname:_Fade,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4,max:4;n:type:ShaderForge.SFN_RemapRange,id:588,x:33102,y:32959,varname:node_588,prsc:2,frmn:0,frmx:4,tomn:-2,tomx:4|IN-8370-OUT;n:type:ShaderForge.SFN_Multiply,id:8591,x:33245,y:32544,varname:node_8591,prsc:2|A-3128-OUT,B-5979-A;proporder:6443-9418-8722-5979-599-8370;pass:END;sub:END;*/

Shader "Custom/Wireframe" {
    Properties {
        _LineBrightness ("LineBrightness", Range(0, 3)) = 0.752
        _LineThickness ("LineThickness", Range(0, 10)) = 1
        _Fresnel ("Fresnel", Range(0, 5)) = 3.4
        _Color ("Color", Color) = (0.03921569,0.3686275,0.6039216,1)
        _WobbleSpeed ("WobbleSpeed", Range(0, 10)) = 1
        //_Fade ("Fade", Range(-1.5, 1.5)) = 0
        _Fade ("Fade", Range(0, 4)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent+2"
            "RenderType"="Transparent"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            #pragma glsl
            uniform float _LineBrightness;
            uniform float _LineThickness;
            uniform float _Fresnel;
            uniform float4 _Color;
            uniform float _WobbleSpeed;
            uniform float _Fade;

            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };

            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
            };

            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }

            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                clip((sin((((_Fade*1.5+-2.0)+(1.0*i.vertexColor.a))*_WobbleSpeed))*0.5+0.5) - 0.5);
                //clip((sin(((_Fade * 2 + 1.5) + i.vertexColor.a) ) * 0.5 + 0.5) - 0.5);
////// Lighting:
                float node_1059 = 0.0;
                float3 node_6246 = smoothstep( float3(node_1059, node_1059, node_1059), ((abs(ddx(i.vertexColor.rgb)) + abs(ddy(i.vertexColor.rgb)))*_LineThickness), i.vertexColor.rgb ).rgb;
                float3 finalColor = ((_Color.rgb*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel)+((1.0 - min(min(node_6246.r,node_6246.g),node_6246.b))*_LineBrightness)))*_Color.a);
                return fixed4(finalColor,1);

                //return _Color;// * ( pow(1.0 - max(0, dot(normalDirection, viewDirection)), _Fresnel) );
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
