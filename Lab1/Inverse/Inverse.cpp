#include "Libs/Math.Matrix/Matrix.h"
#include <fstream>
#include <iostream>
#include <stdexcept>
#include <string>
#include <vector>
using std::fstream;
using std::string;
using std::vector;

vector<vector<float>> GetMatrix(fstream& input);
void PrintMatrix(const Math::Matrix& matrix);

int main(int argc, char* argv[])
{
	for (int i = 1; i < 7; i++)
	{
		string path = "D:/Development/Projects/OOP/Lab1/Inverse/Tests/" + std::to_string(i) + ".txt";
		fstream input(path, std::ios_base::in);
		if (!input)
		{
			std::cout 
				<< "Exception at test " << i << ". " 
				<< "File not foudn. Path: " << path 
				<< std::endl;

			// return 1;
			continue;
		}

		vector<vector<float>> matrixBuffer;
		try
		{
			matrixBuffer = GetMatrix(input);
		}
		catch (std::exception& ex)
		{
			std::cout 
				<< "Exception at test " << i << ". " 
				<< ex.what() 
				<< std::endl;

			// return 1;
			continue;
		}

		Math::Matrix matrix(matrixBuffer);
		try
		{
			matrix = matrix.Inverse();
		}
		catch (std::exception& ex)
		{
			std::cout 
				<< "Exception at test " << i << ". " 
				<< ex.what() 
				<< std::endl;

			//return 1;
			continue;
		}

		PrintMatrix(matrix);
		std::cout << std::endl;
	}

	return 0;
}

void PrintMatrix(const Math::Matrix& matrix)
{
	for (auto& row : matrix.GetBuffer())
	{
		for (auto value : row)
		{
			std::cout << value << " ";
		}

		std::cout << std::endl;
	}
}

vector<float> ParseFloatVector(const string& line)
{
	vector<float> result;

	size_t size = line.size();
	size_t startIndex = -1;
	size_t endIndex = -1;

	while (true)
	{
		// Prepare
		startIndex = endIndex + 1;
		if (startIndex >= size)
		{
			break;
		}

		// Skip whitespaces, find where a number starts
		while (isspace(line[startIndex]))
		{
			startIndex++;
			if (startIndex >= size)
			{
				break;
			}
		}

		if (startIndex >= size)
		{
			break;
		}

		// Find where the number ends
		endIndex = startIndex;
		while (!isspace(line[endIndex]))
		{
			endIndex++;
			if (endIndex >= size)
			{
				break;
			}
		}

		// Parsing
		float number = std::stof(line.substr(startIndex, endIndex));
		result.push_back(number);
	}

	return result;
}

vector<vector<float>> GetMatrix(fstream& input)
{
	vector<vector<float>> result = {};

	int width = 0;
	std::string line;
	while (std::getline(input, line))
	{
		vector<float> vector = ParseFloatVector(line);
		if (vector.size() < 1)
		{
			continue;
		}

		if (width == 0)
		{
			width = vector.size();
		}
		else if (width != vector.size())
		{
			string message = "Expected matrix width is " + std::to_string(width) + ", but got " + std::to_string(vector.size());
			throw std::invalid_argument(message);
		}

		result.push_back(vector);
	}

	return result;
}
