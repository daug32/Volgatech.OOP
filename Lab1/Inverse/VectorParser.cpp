#include "VectorParser.h"
#include <stdexcept>

std::vector<float> VectorParser::ParseFloatVectorFromLine(const std::string& line)
{
	std::vector<float> result;

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

std::vector<std::vector<float>> VectorParser::Parse2DFloatVectorFromFile(std::fstream& input)
{
	std::vector<std::vector<float>> result = {};

	int width = 0;
	std::string line;
	while (std::getline(input, line))
	{
		std::vector<float> vector = ParseFloatVectorFromLine(line);
		if (vector.size() < 1)
		{
			continue;
		}

		result.push_back(vector);
	}

	return result;
}