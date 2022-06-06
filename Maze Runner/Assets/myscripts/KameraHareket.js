#pragma strict

public var kupObjesi : Transform;
private var kameraObjesi : Transform;
private var joystick : Joystick;

function Start()
{
	kameraObjesi = Camera.main.transform;
	joystick = GetComponent( Joystick );
}

function Update()
{
	// Kameranın her zaman küple beraber hareket etmesini sağla
	transform.position = kupObjesi.position;
	
	var kamerayiDondur : Vector2 = Vector2.zero;
	
	#if (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_EDITOR)
		// bu kod sadece mobil cihazlarda ve editörde çalıştırılır
		kamerayiDondur = joystick.sonuc;
	#else
		// bu kod mobil cihazlar harici cihazlarda çalıştırılır
		// PC'de G-J tuşlarıyla kamerayı sola-sağa oynat
		if( Input.GetKey( KeyCode.G ) )
			kamerayiDondur.x = -1;
		else if( Input.GetKey( KeyCode.J ) )
			kamerayiDondur.x = 1;
		
		// H-Y tuşlarıyla kamerayı aşağı-yukarı oynat
		if( Input.GetKey( KeyCode.H ) )
			kamerayiDondur.y = -1;
		else if( Input.GetKey( KeyCode.Y ) )
			kamerayiDondur.y = 1;
	#endif
	
	// Kamerayı sağa-sola oynat
	transform.Rotate( 0, kamerayiDondur.x * 120 * Time.deltaTime, 0 );
	// Kamerayı yukarı-aşağı oynat
	kameraObjesi.RotateAround( transform.position, transform.right, kamerayiDondur.y * 120 * Time.deltaTime );
}