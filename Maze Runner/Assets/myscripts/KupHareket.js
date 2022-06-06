#pragma strict

public var gucMiktari : float = 12;
private var kameraParentObjesi : Transform;
private var joystick : Joystick;

function Start()
{
	kameraParentObjesi = Camera.main.transform.parent;
	joystick = GetComponent( Joystick );
}

function FixedUpdate()
{
	if( Input.GetKeyDown( KeyCode.Escape ) )
		Application.Quit();
		
	// Gücü kübün tepe noktasına uygula, böylece küp takla atarak hareket etsin
	var gucUygulamaNoktasi : Vector3 = transform.position;
	gucUygulamaNoktasi.y += 0.5f;
	
	var gucUygula : Vector2 = Vector2.zero;
	
	#if (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_EDITOR)
		// bu kod sadece mobil cihazlarda ve editörde çalıştırılır
		gucUygula = joystick.sonuc;
	#else
		// bu kod mobil cihazlar harici cihazlarda çalıştırılır
		// PC'de sağ-sol ok tuşlarıyla küpü sağa sola oynat
		gucUygula.x = Input.GetAxis( "Vertical" );
		
		// ileri-geri ok tuşlarıyla küpü ileri geri oynat
		gucUygula.y = Input.GetAxis( "Horizontal" );
	#endif
	
	// Küpe yatay eksende (sağ-sol) güç uygula
	GetComponent.<Rigidbody>().AddForceAtPosition( -kameraParentObjesi.right * -gucUygula.y * -gucMiktari, gucUygulamaNoktasi );
	// Küpe z ekseninde (ileri-geri) güç uygula
	GetComponent.<Rigidbody>().AddForceAtPosition( kameraParentObjesi.forward * gucUygula.x * gucMiktari, gucUygulamaNoktasi );
}