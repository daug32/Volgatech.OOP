#include "Math.h"
#include <stdexcept>

namespace Math
{
	inline float Radians( float degrees )
	{
		return PI / 180.f * degrees;
	}

	inline float Degrees( float radians )
	{
		return 180.f / PI * radians;
	}
}