#pragma once
#include <vector>

namespace Math
{
	class Vector3
	{
	private:
		std::vector<float> m_buffer;

	public:
		float GetX() const;
		void SetX( float a );

		float GetY() const;
		void SetY( float a );

		float GetZ() const;
		void SetZ( float a );

		Vector3( float x, float y, float z = 0 );
		Vector3( float value );
		Vector3();

		void operator+=( const Vector3& v );
		void operator-=( const Vector3& v );
		void operator*=( float v );
		void operator/=( float v );

		Vector3 operator+( const Vector3& a ) const;
		Vector3 operator-( const Vector3& a ) const;
		Vector3 operator*( float a ) const;
		Vector3 operator/( float a ) const;

		static Vector3 MeanPosition( const std::vector<Vector3>& arr );
		static inline double GetSqLength( const Vector3& v );
		static inline double GetSqDistance( const Vector3& pos1, const Vector3& pos2 );
	};
}
