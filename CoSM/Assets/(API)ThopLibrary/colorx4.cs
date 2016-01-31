using UnityEngine;
using System.Collections;
using thopframwork;
public class colorx4 {

	public int color1 = 5;
	public int color2 = 5;
	public int color3 = 5;
	public int color4 = 5;
	
	public static colorx4 randomC4()
	{
		colorx4 value;
		value.color1 = randomc (value);
		value.color2 = randomc (value);
		value.color3 = randomc (value);
		value.color4 = randomc (value);
		return value;
	}
	int randomc (colorx4 x)
	{
		int value = ThopFW.Random(0,4);
		if (value == x.color1 || value == x.color2 || value == x.color3 || x.color4)
			randomc (x);
		else 
			return value;
	}
}
