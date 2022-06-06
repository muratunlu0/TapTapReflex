using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof(Joystick) )]
public class JoystickEditor : Editor 
{
	int sceneWidth;
	int sceneHeight;
	bool valueChanged = false;
	int pixelOrPercentage;
	int percentageDir;
	int pixelOrPercentage2;
	string[] options = { "Pixel", "Yüzde (%)" };
	string[] options2 = { "Dikey (Y)", "Yatay (X)" };
	
	void Awake()
	{
		Joystick j = (Joystick) target;
		
		if( j.yuzdeSistemiKullanEbat )
			pixelOrPercentage = 1;
		else
			pixelOrPercentage = 0;
			
		if( j.yuzdeEbatYatayMi )
			percentageDir = 1;
		else
			percentageDir = 0;
			
		if( j.yuzdeSistemiKullanUzaklik )
			pixelOrPercentage2 = 1;
		else
			pixelOrPercentage2 = 0;
	}
	
    public override void OnInspectorGUI()
    {   
		Joystick j = (Joystick) target;
		Color c = GUI.color;
		GUI.color = Color.cyan;
		EditorGUILayout.HelpBox( "- Made by Murat UNLU", MessageType.None );
		GUI.color = c;
		
		EditorGUILayout.HelpBox( "Joystick Özellikler", MessageType.Info );
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel( "Joystick Texture" );
		j.joystickTexture = (Texture2D) EditorGUILayout.ObjectField( j.joystickTexture, typeof(Texture2D), false );
		EditorGUILayout.EndHorizontal();
		
		j.id = EditorGUILayout.IntField( "Joystick ID", j.id );
		
		EditorGUILayout.HelpBox( "Joystick Ebat", MessageType.Info );
		pixelOrPercentage = EditorGUILayout.Popup( "Ölçeklendirme Birimi", pixelOrPercentage, options );
		j.yuzdeSistemiKullanEbat = ( pixelOrPercentage == 1 ) ? true : false;
		
		if( pixelOrPercentage == 1 )
		{
			percentageDir = EditorGUILayout.Popup( "Referans Eksen", percentageDir, options2 );
			j.yuzdeEbatYatayMi = ( percentageDir == 1 ) ? true : false;
			j.joystickEbatYuzde = EditorGUILayout.IntField( "Joystick Ebat %", (int) j.joystickEbatYuzde );
			j.hareketAlaniYaricapYuzde = EditorGUILayout.IntField( "Hareket Alanı Yarıçap %",(int) j.hareketAlaniYaricapYuzde );
			
			GUI.color = Color.green;
			EditorGUILayout.HelpBox( "Joystick ekran " + ( (percentageDir==1) ? "genişliğinin " : "yüksekliğinin " ) + "%" + j.joystickEbatYuzde 
							+ " kadarını kaplayacak.\nJoystickin hareket edebileceği dairesel alanın yarıçapı ekran " + 
							( (percentageDir==1) ? "genişliğinin " : "yüksekliğinin " ) + "%" + j.hareketAlaniYaricapYuzde
							+ " kadarı olacak.", MessageType.None );
			GUI.color = c;
			
			j.joystickEbatYuzde = Mathf.Clamp( j.joystickEbatYuzde, 1f, 100f );
			j.hareketAlaniYaricapYuzde = Mathf.Clamp( j.hareketAlaniYaricapYuzde, 1f, 50f );
		}
		else
		{
			j.joystickEbat = EditorGUILayout.IntField( "Joystick Ebat", j.joystickEbat );
			j.hareketAlaniYaricap = EditorGUILayout.IntField( "Hareket Alanı Yarıçap", j.hareketAlaniYaricap );
			
			GUI.color = Color.green;
			EditorGUILayout.HelpBox( "Joystick " + j.hareketAlaniYaricap + " pixel ebatında olacak.\n" +
							"Joystickin hareket edebileceği dairesel alanın yarıçapı " + j.hareketAlaniYaricap +
							" pixel olacak.", MessageType.None );
			GUI.color = c;
			
			if( j.joystickEbat < 10 )
				j.joystickEbat = 10;
				
			if( j.hareketAlaniYaricap < 0 )
				j.hareketAlaniYaricap = 0;
		}
		
        j.hareketEkseni = (HareketModu) EditorGUILayout.EnumPopup( "Hareket Ekseni", j.hareketEkseni );
		
		EditorGUILayout.HelpBox( "Joystick Konumlandırma", MessageType.Info );
		j.dinamikKonumlandir = EditorGUILayout.Toggle( "Dinamik Konumlandır", j.dinamikKonumlandir );
		
		if( j.dinamikKonumlandir )
		{
			GUI.color = Color.green;
			EditorGUILayout.HelpBox( "Joystick ekranda tıklanan noktada oluşacak.", MessageType.None );
			GUI.color = c;
			GUI.enabled = false;
		}
		
		j.referansNoktasi = (ReferansNoktasi) EditorGUILayout.EnumPopup( "Referans Noktası", j.referansNoktasi );
		pixelOrPercentage2 = EditorGUILayout.Popup( "Ölçeklendirme Birimi", pixelOrPercentage2, options );
		j.yuzdeSistemiKullanUzaklik = ( pixelOrPercentage2 == 1 ) ? true : false;
		
		if( pixelOrPercentage2 == 0 )
		{
			j.yatayBoslukPixel = EditorGUILayout.IntField( "Yatay Boşluk Pixel", j.yatayBoslukPixel );
			j.dikeyBoslukPixel = EditorGUILayout.IntField( "Dikey Boşluk Pixel", j.dikeyBoslukPixel );
			
			string s = ( j.referansNoktasi == ReferansNoktasi.SolAlt ) ? "sol alt" : ( j.referansNoktasi == ReferansNoktasi.SolUst ) ? "sol üst" :
			( j.referansNoktasi == ReferansNoktasi.SagAlt ) ? "sağ alt" : "sağ üst";
			
			if( !j.dinamikKonumlandir )
			{
				GUI.color = Color.green;
				EditorGUILayout.HelpBox( "Joystickin " + s + " noktası, ekranın " + s + " noktasından " +
								j.yatayBoslukPixel + "x" + j.dikeyBoslukPixel + " pixel uzakta olacak.", MessageType.None );
				GUI.color = c;
			}
			
			if( j.yatayBoslukPixel < 0 )
				j.yatayBoslukPixel = 0;
				
			if( j.dikeyBoslukPixel < 0 )
				j.dikeyBoslukPixel = 0;
		}
		else
		{
			j.yatayBoslukYuzde = EditorGUILayout.IntField( "Yatay Boşluk Yüzde", (int) j.yatayBoslukYuzde );
			j.dikeyBoslukYuzde = EditorGUILayout.IntField( "Dikey Boşluk Yüzde", (int) j.dikeyBoslukYuzde );
			
			string s1 = ( j.referansNoktasi == ReferansNoktasi.SolAlt || j.referansNoktasi == ReferansNoktasi.SolUst ) ? "sol" : "sağ";
			string s2 = ( j.referansNoktasi == ReferansNoktasi.SolAlt || j.referansNoktasi == ReferansNoktasi.SagAlt ) ? "alt" : "üst";
			
			if( !j.dinamikKonumlandir )
			{
				GUI.color = Color.green;
				EditorGUILayout.HelpBox( "Joystick ile ekranın " + s1 + " kenarı arasında ekranın genişliğinin %" + 
								j.yatayBoslukYuzde + " kadarınca boşluk olacak.\nJoystick ile ekranın " + s2 +
								" kenarı arasında ekranın yüksekliğinin %" + 
								j.dikeyBoslukYuzde + " kadarınca boşluk olacak.\n", MessageType.None );
				GUI.color = c;
			}
			
			j.yatayBoslukYuzde = Mathf.Clamp( j.yatayBoslukYuzde, 1f, 100f );
			j.dikeyBoslukYuzde = Mathf.Clamp( j.dikeyBoslukYuzde, 1f, 100f );
		}
		
		GUI.enabled = true;
		
		if( GUI.changed )
		{
			valueChanged = true;
			SceneView.RepaintAll();
		}
    }
	
	void OnSceneGUI()
	{
		Joystick j = (Joystick) target;
		
		if( Screen.width != sceneWidth || Screen.height != sceneHeight )
		{
			j.Start();
			sceneWidth = Screen.width;
			sceneHeight = Screen.height;
		}
		
		if( valueChanged )
		{
			j.Start();
			valueChanged = false;
		}
		
		Handles.BeginGUI();
		GUI.DrawTexture( j.joystickRect, j.joystickTexture );
		Handles.EndGUI();
	}
}