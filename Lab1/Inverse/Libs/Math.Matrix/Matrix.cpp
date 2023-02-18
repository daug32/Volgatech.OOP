#include "Matrix.h"
#include "Math.h"
#include <iostream>
#include <stdexcept>

namespace Math
{
	Matrix::Matrix( int rows, int columns, float defaultValue )
	{
		m_height = rows;
		m_width = columns;

		m_buffer.resize( rows );

		for ( auto& row : m_buffer )
		{
			row.resize( columns, defaultValue );
		}
	}

	Matrix::Matrix( const std::vector<std::vector<float>>& arg )
	{
		m_height = arg.size();
		m_width = m_height > 0 ? arg[0].size() : 0;

		m_buffer = arg;
	}

	//=============================
	//Getters
	//=============================
	int Matrix::Rows() const
	{
		return m_height;
	}

	int Matrix::Columns() const
	{
		return m_width;
	}

	std::vector<std::vector<float>> Matrix::GetBuffer() const
	{
		return m_buffer;
	}

	//=============================
	//Methods
	//=============================
	float Matrix::Determinant() const
	{
		if ( m_height != m_width )
		{
			throw std::invalid_argument( "Can't calculate determinator for not sqгare matrix" );
		}

		if ( m_height == 2 )
		{
			return
				m_buffer[0][0] * m_buffer[1][1] -
				m_buffer[1][0] * m_buffer[0][1];
		}

		float result = 0;
		float k = -1;

		Matrix a( *this );
		for ( int i = 0; i < m_width; i++ )
		{
			result += ( k *= -1 ) * a[0][i] * a.Minor( 0, i ).Determinant();
		}

		return result;
	}

	Matrix Matrix::Transponse() const
	{
		Matrix result( m_width, m_height );

		for ( int y = 0; y < m_height; y++ )
		{
			for ( int x = 0; x < m_width; x++ )
			{
				result[x][y] = m_buffer[y][x];
			}
		}

		return result;
	}

	Matrix Matrix::Minor( int row, int column ) const
	{
		if ( row < 0 || row > m_height ||
			column < 0 || column > m_width )
		{
			return Matrix(*this);
		}

		Matrix result( m_height - 1, m_width - 1 );

		int newY = 0;
		for ( int oldY = 0; oldY < m_height; oldY++)
		{
			if ( oldY == row )
			{
				continue;
			}

			int newX = 0;
			for ( int oldX = 0; oldX < m_width; oldX++)
			{
				if ( oldX == column )
				{
					continue;
				}

				result[newY][newX] = m_buffer[oldY][oldX];
				newX++;
			}

			newY++;
		}

		return result;
	}

	Matrix Matrix::Inverse() const
	{
		if (m_height != m_width)
		{
			throw std::invalid_argument("Non square matrices do not have inverse matrix");
		}

		int determinant = Determinant();
		if (determinant == 0)
		{
			throw std::invalid_argument("Determinant is 0, there is no inverse matrix");
		}

		auto transponsed = Transponse();
		Matrix result(m_height, m_width);
		
		int k = -1;
		for (int y = 0; y < m_height; y++)
		{
			for (int x = 0; x < m_width; x++)
			{
				result[y][x] = (k *= -1) * transponsed.Minor(y, x).Determinant() / determinant;
			}
		}

		return result;
	}

	//=============================
	//Static Methods
	//=============================
	Matrix Matrix::RotationXY(float angle, int scale)
	{
		if (scale < 3)
		{
			throw std::invalid_argument("Matrix scale is less then 3");
		}

		float sin = std::sin(angle);
		float cos = std::cos(angle);

		auto result = IdentityMatrix(scale);

		result[0][0] = cos;
		result[0][1] = -sin;
		result[1][0] = sin;
		result[1][1] = cos;

		return result;
	}

	Matrix Matrix::RotationYZ(float angle, int scale)
	{
		if (scale < 3)
		{
			throw std::invalid_argument("Matrix scale is less then 3");
		}

		float sin = std::sin(angle);
		float cos = std::cos(angle);

		auto result = IdentityMatrix(scale);

		result[1][1] = cos;
		result[1][2] = -sin;
		result[2][1] = sin;
		result[2][2] = cos;

		return result;
	}

	Matrix Matrix::RotationXZ(float angle, int scale)
	{
		if (scale < 3)
		{
			throw std::invalid_argument("Matrix scale is less then 3");
		}

		float sin = std::sin(angle);
		float cos = std::cos(angle);

		auto result = IdentityMatrix(scale);

		result[0][0] = cos;
		result[0][2] = sin;
		result[2][0] = -sin;
		result[2][2] = cos;

		return result;
	}

	Matrix Matrix::IdentityMatrix(int size)
	{
		Matrix result(size, size, 0);

		for (int i = 0; i < result.Rows(); i++)
		{
			result[i][i] = 1;
		}

		return result;
	}

	//=============================
	//Operators
	//=============================
	Matrix Matrix::operator* ( const Matrix& b ) const
	{
		if ( m_width != b.m_height )
		{
			throw std::invalid_argument( "Impossible to multipy those matrices" );
		}

		Matrix r( m_height, b.m_width );

		for ( int firstY = 0; firstY < m_height; firstY++ )
		{
			for ( int secondX = 0; secondX < b.m_width; secondX++ )
			{
				for ( int firstX = 0; firstX < m_width; firstX++ )
				{
					r[firstY][secondX] += 
						m_buffer[firstY][firstX] * 
						b.m_buffer[firstX][secondX];
				}
			}
		}

		return r;
	}

	Matrix Matrix::operator+ ( const Matrix& b ) const
	{
		if ( m_width != b.m_width || m_height != b.m_height )
		{
			throw std::invalid_argument( "Matrices have different sizes" );
		}

		Matrix r( *this );

		for ( int y = 0; y < m_height; y++ )
		{
			for ( int x = 0; x < m_width; x++ )
			{
				r[y][x] += b.m_buffer[y][x];
			}
		}

		return r;
	}

	Matrix Matrix::operator- ( const Matrix& b ) const
	{
		if ( m_width != b.m_width || m_height != b.m_height )
		{
			throw std::invalid_argument( "Matrices have different sizes" );
		}

		Matrix r( *this );

		for ( int y = 0; y < m_height; y++ )
		{
			for ( int x = 0; x < m_width; x++ )
			{
				r[y][x] -= b.m_buffer[y][x];
			}
		}

		return r;
	}

	void Matrix::operator*= ( const Matrix& b )
	{
		*this = *this * b;
	}

	void Matrix::operator+= ( const Matrix& b )
	{
		*this = *this + b;
	}

	void Matrix::operator-= ( const Matrix& b )
	{
		*this = *this - b;
	}

	Matrix Matrix::operator* ( float k ) const
	{
		Matrix r( *this );

		for ( int y = 0; y < m_height; y++ )
		{
			for ( int x = 0; x < m_width; x++ )
			{
				r[y][x] *= k;
			}
		}

		return r;
	}
	Matrix Matrix::operator/ ( float k ) const
	{
		if ( k == 0 )
		{
			throw std::invalid_argument( "Can't devide by 0" );
		}

		Matrix r( *this );

		for ( int y = 0; y < m_height; y++ )
		{
			for ( int x = 0; x < m_width; x++ )
			{
				r[y][x] /= k;
			}
		}

		return r;
	}

	void Matrix::operator*= ( float k )
	{
		*this = *this * k;
	}

	void Matrix::operator/= ( float k )
	{
		*this = *this / k;
	}

	inline std::vector<float>& Matrix::operator[] ( int n )
	{
		return m_buffer[n];
	}

	bool Matrix::operator== ( const Matrix& a ) const
	{
		if ( a.m_width != m_width || a.m_height != m_height )
		{
			return false;
		}

		for ( int y = 0; y < m_height; y++ )
		{
			for ( int x = 0; x < m_width; x++ )
			{
				if ( a.m_buffer[y][x] != m_buffer[y][x] )
				{
					return false;
				}
			}
		}

		return true;
	}

	bool Matrix::operator!= ( const Matrix& a ) const
	{
		return !this->operator==( a );
	}
}
