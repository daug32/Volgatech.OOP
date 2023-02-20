#include "Libs/Math.Matrix/Matrix.h"
#include "VectorParser.h"
#include <fstream>
#include <iomanip>
#include <iostream>
#include <stdexcept>
#include <string>
#include <vector>
using std::vector;

Math::Matrix GetMatrix(std::fstream& input);
void PrintMatrix(const Math::Matrix& matrix);

int main(int argc, char* argv[])
{
	if (argc < 2)
	{
		std::cout << "Expected <input file name>" << std::endl;
	}

	std::string path = std::string(argv[1]);
	std::fstream input(path, std::ios_base::in);
	if (!input)
	{
		std::cout << "File not found. Path: " << path << std::endl;
		return 1;
	}

	Math::Matrix matrix;
	try
	{
		matrix = GetMatrix(input).Inverse();
	}
	catch (std::exception& ex)
	{
		std::cout << ex.what() << std::endl;
		return 1;
	}

	PrintMatrix(matrix);

	return 0;
}

Math::Matrix GetMatrix(std::fstream& input)
{
	std::vector<std::vector<float>> matrixBuffer = VectorParser::Parse2DFloatVectorFromFile(input);

	int width = 0;
	if (matrixBuffer.size() > 0)
	{
		width = matrixBuffer[0].size();
	}

	for (auto& row : matrixBuffer)
	{
		if (row.size() != width)
		{
			std::string message = "Expected matrix width is " + std::to_string(width) + ", but got " + std::to_string(row.size());
			throw std::invalid_argument(message);
		}
	}

	return Math::Matrix(matrixBuffer);
}

void PrintMatrix(const Math::Matrix& matrix)
{
	int precision = std::cout.precision();
	std::cout << std::fixed << std::setprecision(3);

	for (auto& row : matrix.GetBuffer())
	{
		for (auto value : row)
		{
			std::cout << value << " ";
		}

		std::cout << std::endl;
	}

	std::cout << std::setprecision(precision);
}