#pragma once
#include <vector>
#include <string>

namespace Math
{
	class Matrix
	{
	private:
		size_t m_width;
		size_t m_height;

		std::vector<std::vector<float>> m_buffer;

	public:
		// Ctors
		Matrix(const std::vector<std::vector<float>>& arg);
		Matrix(size_t rows = 0, size_t columns = 0, float defaultValue = 0);

		// Getters
		size_t Rows() const;
		size_t Columns() const;
		std::vector<std::vector<float>> GetBuffer() const;

		// Methods
		Matrix Transponse() const;
		float Determinant() const;
		Matrix Minor(size_t row, size_t column) const;
		Matrix Inverse() const;

		static Matrix IdentityMatrix(size_t size);

		// Operators
		void operator*= (const Matrix& b);
		void operator+= (const Matrix& b);
		void operator-= (const Matrix& b);

		Matrix operator* (const Matrix& b) const;
		Matrix operator+ (const Matrix& b) const;
		Matrix operator- (const Matrix& b) const;

		void operator*= (float k);
		void operator/= (float k);
		Matrix operator* (float k) const;
		Matrix operator/ (float k) const;

		bool operator== (const Matrix& a) const;
		bool operator!= (const Matrix& a) const;

		std::vector<float>& operator[] (size_t n);
	};
}

