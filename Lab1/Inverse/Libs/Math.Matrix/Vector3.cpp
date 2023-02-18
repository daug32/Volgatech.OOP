#include "Vector3.h"

namespace Math
{
	//-------------------------------------------
	// Contructors
	//-------------------------------------------
	Vector3::Vector3( float x, float y, float z )
	{
		m_buffer = { x, y, z };
	}

	Vector3::Vector3( float value )
	{
		m_buffer = { value, value, value };
	}

	Vector3::Vector3()
	{
		m_buffer = { 0, 0, 0 };
	}

	//-------------------------------------------
	// Getters and setters
	//-------------------------------------------
	float Vector3::GetX() const
	{
		return m_buffer[0];
	}

	void Vector3::SetX( float x )
	{
		m_buffer[0] = x;
	}

	float Vector3::GetY() const
	{
		return m_buffer[1];
	}

	void Vector3::SetY( float y )
	{
		m_buffer[1] = y;
	}

	float Vector3::GetZ() const
	{
		return m_buffer[2];
	}

	void Vector3::SetZ( float z )
	{
		m_buffer[2] = z;
	}

	//-------------------------------------------
	// Operators
	//-------------------------------------------
	void Vector3::operator+=( const Vector3& v )
	{
		m_buffer[0] += v.GetX();
		m_buffer[1] += v.GetY();
		m_buffer[2] += v.GetZ();
	}

	void Vector3::operator-=( const Vector3& v )
	{
		m_buffer[0] -= v.GetX();
		m_buffer[1] -= v.GetY();
		m_buffer[2] -= v.GetZ();
	}

	void Vector3::operator*=( float v )
	{
		m_buffer[0] *= v;
		m_buffer[1] *= v;
		m_buffer[2] *= v;
	}

	void Vector3::operator/=( float v )
	{
		m_buffer[0] /= v;
		m_buffer[1] /= v;
		m_buffer[2] /= v;
	}

	Vector3 Vector3::operator+( const Vector3& a ) const
	{
		return Vector3(
			m_buffer[0] + a.GetX(),
			m_buffer[1] + a.GetY(),
			m_buffer[2] + a.GetZ()
		);
	}

	Vector3 Vector3::operator-( const Vector3& a ) const
	{
		return Vector3(
			m_buffer[0] - a.GetX(),
			m_buffer[1] - a.GetY(),
			m_buffer[2] - a.GetZ()
		);
	}

	Vector3 Vector3::operator*( float a ) const
	{
		return Vector3(
			m_buffer[0] * a,
			m_buffer[1] * a,
			m_buffer[2] * a
		);
	}

	Vector3 Vector3::operator/( float a ) const
	{
		return Vector3(
			m_buffer[0] / a,
			m_buffer[1] / a,
			m_buffer[2] / a
		);
	}

	//-------------------------------------------
	// Other 
	//-------------------------------------------
	Vector3 Vector3::MeanPosition( const std::vector<Vector3>& arr )
	{
		Vector3 result;

		size_t size = arr.size();
		for ( int i = 0; i < size; i++ )
		{
			result += arr[i];
		}

		return result / size;
	}

	inline double Vector3::GetSqLength( const Vector3& v )
	{
		float x = v.GetX();
		float y = v.GetY();
		float z = v.GetZ();

		return x * x + y * y + z * z;
	}

	inline double Vector3::GetSqDistance( const Vector3& pos1, const Vector3& pos2 )
	{
		float xDiff = pos1.GetX() - pos2.GetX();
		float yDiff = pos1.GetY() - pos2.GetY();
		float zDiff = pos1.GetZ() - pos2.GetZ();

		return xDiff * xDiff + yDiff * yDiff + zDiff * zDiff;
	}
}