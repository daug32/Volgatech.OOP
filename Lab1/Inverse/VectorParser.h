#pragma once
#include <fstream>
#include <string>
#include <vector>

class VectorParser
{
public:
	static std::vector<float> ParseFloatVectorFromLine(const std::string& line);
	static std::vector<std::vector<float>> Parse2DFloatVectorFromFile(std::fstream& input);
};
