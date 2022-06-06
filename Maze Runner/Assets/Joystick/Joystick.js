#pragma strict

public var joystickTexture : Texture2D;

public var id : int = 0;

public var joystickEbat : int = 128;
public var hareketAlaniYaricap : int = 128;

private var joystickEbatUsage : int;
private var hareketAlaniYaricapUsage : int;

public var joystickEbatYuzde : float = 15;
public var hareketAlaniYaricapYuzde : float = 15;

public var hareketEkseni : HareketModu = 0;
public var referansNoktasi : ReferansNoktasi = 0;
public var yuzdeSistemiKullanEbat : boolean = false;
public var yuzdeEbatYatayMi : boolean = false; // false- dikey, true- yatay
public var yuzdeSistemiKullanUzaklik : boolean = true;
public var dinamikKonumlandir : boolean = false;

public var yatayBoslukPixel : int = 128;
public var dikeyBoslukPixel : int = 128;
public var yatayBoslukYuzde : float = 15;
public var dikeyBoslukYuzde : float = 15;

public var joystickRect : Rect; // joystick'e dokunmazken joystickin çizileceği alan
private var joystickGorunumRect : Rect; // joystick'e dokunurken joystickin çizileceği alan
private var merkezNoktasi : Vector2; // joystickRect'in orta noktası

public enum HareketModu { XveY, SadeceX, SadeceY }
public enum ReferansNoktasi { SolAlt, SolUst, SagAlt, SagUst }

private var gorunurluk : float = 1; // joystick'in ekrandaki opaklığı
private var parmakId : int = -1; // joystick'e tıklayan parmak

@HideInInspector
public var sonuc : Vector2 = Vector2.zero;

function Start()
{
	if( !dinamikKonumlandir )
	{
		// Dinamik konumlandırma kapalıysa joystickin çizileceği konumu (Rect) belirle
		var joystickKenar : int;
		var yaricap : int;
		
		if( yuzdeSistemiKullanEbat )
		{
			if( yuzdeEbatYatayMi )
			{
				joystickKenar = Screen.width * joystickEbatYuzde / 100;
				yaricap = Screen.width * hareketAlaniYaricapYuzde / 100;
			}
			else
			{
				joystickKenar = Screen.height * joystickEbatYuzde / 100;
				yaricap = Screen.height * hareketAlaniYaricapYuzde / 100;
			}
		}
		else
		{
			joystickKenar = joystickEbat;
			yaricap = hareketAlaniYaricap;
		}
		
		var dx : int;
		var dy : int;
		if( yuzdeSistemiKullanUzaklik )
		{
			// % olarak konumlandırma seçilmişse boşlukları ona göre ayarla
			dx = Screen.width * yatayBoslukYuzde / 100;
			dy = Screen.height * dikeyBoslukYuzde / 100;
		}
		else
		{
			dx = yatayBoslukPixel;
			dy = dikeyBoslukPixel;
		}
		
		// Joystickin çizileceği Rect'i oluştur
		if( referansNoktasi == ReferansNoktasi.SolAlt )
			joystickRect = new Rect( dx, Screen.height - dy - joystickKenar, joystickKenar, joystickKenar );
		else if( referansNoktasi == ReferansNoktasi.SolUst )
			joystickRect = new Rect( dx, dy, joystickKenar, joystickKenar );
		else if( referansNoktasi == ReferansNoktasi.SagAlt )
			joystickRect = new Rect( Screen.width - dx - joystickKenar, Screen.height - dy - joystickKenar, joystickKenar, joystickKenar );
		else
			joystickRect = new Rect( Screen.width - dx - joystickKenar, dy, joystickKenar, joystickKenar );
		
		
		joystickGorunumRect = joystickRect;
		merkezNoktasi = new Vector2( joystickRect.x + joystickKenar / 2, joystickRect.y + joystickKenar / 2 );
		
		joystickEbatUsage = joystickKenar;
		hareketAlaniYaricapUsage = yaricap;
	}
	else
	{
		joystickEbatUsage = joystickEbat;
		hareketAlaniYaricapUsage = hareketAlaniYaricap;
		
		// Dinamik konumlandırma açıksa joysticki oyunun başında gizle
		gorunurluk = 0;
		joystickGorunumRect = new Rect();
	}
}

function Update()
{
	var parmakBulundu : boolean = false;
	
	#if UNITY_EDITOR
	if( Input.GetMouseButtonDown( 0 ) )
	{
		if( dinamikKonumlandir )
		{
			if( JoystickOlusturulsunMu( new Vector2( Input.mousePosition.x, Screen.height - Input.mousePosition.y ) ) )
			{
				parmakId = 1;
				parmakBulundu = true;
				
				// joysticki parmağın ekrana dokunduğu yerde oluştur
				joystickRect = new Rect( Input.mousePosition.x - joystickEbatUsage / 2, Screen.height - Input.mousePosition.y - joystickEbatUsage / 2, joystickEbatUsage, joystickEbatUsage );
				joystickGorunumRect = joystickRect;
				merkezNoktasi = new Vector2( Input.mousePosition.x, joystickRect.y + joystickEbatUsage / 2 );
			}
		}
		else if( joystickRect.Contains( new Vector2( Input.mousePosition.x, Screen.height - Input.mousePosition.y ) ) )
		{
			parmakId = 1;
			parmakBulundu = true;
			JoystickKimildat( Input.mousePosition );
		}
	}
	else if( Input.GetMouseButton( 0 ) && parmakId == 1 )
	{
		parmakBulundu = true;
		JoystickKimildat( Input.mousePosition );
	}
	#else
	for( var parmak : Touch in Input.touches )
	{
		// Ekrandaki tüm parmaklara bak
		
		if( parmakId == -1 ) 
		{
			// eğer joysticki tutan parmak yoksa
			
			if( parmak.phase == TouchPhase.Began ) 
			{
				// bu parmak ekrana yeni dokunduysa
				
				if( dinamikKonumlandir )
				{
					// dinamik konumlandırma açıksa ve parmağın ekrandaki konumu uygunsa
					// (JoystickOlusturulsunMu true döndürmüşse) artık joysticki kontrol ediyoruz
					if( JoystickOlusturulsunMu( new Vector2( parmak.position.x, Screen.height - parmak.position.y ) ) )
					{
						parmakId = parmak.fingerId;
						parmakBulundu = true;
						
						// joysticki parmağın ekrana dokunduğu yerde oluştur
						joystickRect = new Rect( parmak.position.x - joystickEbatUsage / 2, Screen.height - parmak.position.y - joystickEbatUsage / 2, joystickEbatUsage, joystickEbatUsage );
						joystickGorunumRect = joystickRect;
						merkezNoktasi = new Vector2( parmak.position.x, joystickRect.y + joystickEbatUsage / 2 );
					}
				}
				else if( joystickRect.Contains( new Vector2( parmak.position.x, Screen.height - parmak.position.y ) ) )
				{
					// dinamik konumlandırma kapalıysa ve parmak joystick'in bulunduğu
					// alana tıklamışsa joysticki kontrol etmeye başla
					parmakId = parmak.fingerId;
					JoystickKimildat( parmak.position );
					parmakBulundu = true;
				}
			}
		}
		else if( parmakId == parmak.fingerId )
		{
			// eğer şu anda joysticki tutan parmağa bakıyorsak
			parmakBulundu = true;
			
			// parmak kımıldadıysa joysticki de kımıldat
			if( parmak.phase == TouchPhase.Moved )
				JoystickKimildat( parmak.position );
		}
	}
	#endif
	
	if( !parmakBulundu )
	{
		// eğer joysticki tutan parmak yoksa joysticki sıfırla
		parmakId = -1;
		sonuc = Vector2.zero;
		joystickGorunumRect = joystickRect;
		
		if( dinamikKonumlandir )
		{	
			// dinamik konumlandırma açıksa joysticki ekrandan gizle
			gorunurluk -= Time.deltaTime * 5;
			
			if( gorunurluk < 0 )
				gorunurluk = 0;
		}
	}
	else if( dinamikKonumlandir )
	{
		// eğer joysticki tutan parmak varsa ve dinamik
		// konumlandırma açıksa joysticki ekranda göster
		gorunurluk += Time.deltaTime * 5;
			
		if( gorunurluk > 1 )
			gorunurluk = 1;
	}
}

function JoystickKimildat( pozisyon : Vector2 )
{
	if( hareketEkseni == HareketModu.SadeceX )
		pozisyon.y = merkezNoktasi.y;
	else
		pozisyon.y = Screen.height - pozisyon.y;
		
	if( hareketEkseni == HareketModu.SadeceY )
		pozisyon.x = merkezNoktasi.x;

	// eğer parmak joystickin hareket yarıçapından uzaktaysa
	// joysticki parmağa bakacak şekilde, merkezden yarıçap
	// uzaklığa taşı
	if( Vector2.Distance( pozisyon, merkezNoktasi ) > hareketAlaniYaricapUsage )
	{
		var yon : Vector2 = ( pozisyon - merkezNoktasi ).normalized;
		pozisyon = merkezNoktasi + yon * hareketAlaniYaricapUsage;
	}
	
	// joysticki kımıldat
	joystickGorunumRect.x = pozisyon.x - joystickEbatUsage / 2;
	joystickGorunumRect.y = pozisyon.y - joystickEbatUsage / 2;
	
	// joystickin döndürdüğü değeri güncelle
	sonuc = new Vector2( ( pozisyon.x - merkezNoktasi.x ) / hareketAlaniYaricapUsage, -( pozisyon.y - merkezNoktasi.y ) / hareketAlaniYaricapUsage );
}

function JoystickOlusturulsunMu( pozisyon : Vector2 )
{
	if( id == 0 )
	{
		if( pozisyon.x < Screen.width )
			return true;
			
		return false;
	}
	else if( id == 1 )
	{
		if( pozisyon.x > Screen.width )
			return true;
			
		return false;
	}
		
	return false;
}////////////////

function OnGUI()
{
	// joysticki ekranda çizdir (opaklığı "gorunurluk" olacak şekilde)
	GUI.color.a = gorunurluk;
	GUI.DrawTexture( joystickGorunumRect, joystickTexture );
	GUI.color.a = 1;
}