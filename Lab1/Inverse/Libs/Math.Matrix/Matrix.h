#pragma once
#include <vector>
#include <string>

namespace Math
{
	class Matrix
	{
	private: 
		int m_width;
		int m_height;

		std::vector<std::vector<float>> m_buffer;

	public:
		// Ctors
		Matrix( const std::vector<std::vector<float>>& arg );
		Matrix( int rows = 0, int columns = 0, float defaultValue = 0 );

		// Getters
		int Rows() const;
		int Columns() const;
		std::vector<std::vector<float>> GetBuffer() const;

		// Methods
		Matrix Transponse() const;
		float Determinant() const;
		Matrix Minor( int row, int column ) const;
		Matrix Inverse() const;

		static Matrix IdentityMatrix(int size);
		static Matrix RotationXY(float angle, int scale = 4);
		static Matrix RotationYZ(float angle, int scale = 4);
		static Matrix RotationXZ(float angle, int scale = 4);

		// Operators
		void operator*= ( const Matrix& b );
		void operator+= ( const Matrix& b );
		void operator-= ( const Matrix& b );

		Matrix operator* ( const Matrix& b ) const;
		Matrix operator+ ( const Matrix& b ) const;
		Matrix operator- ( const Matrix& b ) const;

		void operator*= ( float k );
		void operator/= ( float k );
		Matrix operator* ( float k ) const;
		Matrix operator/ ( float k ) const;

		bool operator== ( const Matrix& a ) const;
		bool operator!= ( const Matrix& a ) const;

		std::vector<float>& operator[] ( int n );
	};
}

