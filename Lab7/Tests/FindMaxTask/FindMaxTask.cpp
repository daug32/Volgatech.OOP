#include <iostream>
#include <vector>

template <typename T>
bool FindMax(const std::vector<T>& arr, T& maxValue);

template <>
bool FindMax<const char*>(
    const std::vector<const char*>& arr,
    const char* & maxValue);

int main(int argc, char* argv[])
{
    const std::vector<int> intArray = {
        0, 10, 1, 2, 3
    };

    int maxInt;
    std::cout << FindMax(intArray, maxInt) << std::endl;
    std::cout << maxInt << std::endl;

    const std::vector<const char*> stringArray = {
        "abcd",
        "dcba",
        "acbd"
    };

    const char* maxString;
    std::cout << FindMax(stringArray, maxString) << std::endl;
    std::cout << maxString;

    return 0;
}

template <typename T>
bool FindMax(const std::vector<T>& arr, T& maxValue)
{
    const size_t size = arr.size();
    if (size == 0)
    {
        return false;
    }

    for (size_t i = 0; i < size; i++)
    {
        if (arr[i] > maxValue)
        {
            maxValue = arr[i];
        }
    }

    return true;
}

template <>
bool FindMax<const char*>(
    const std::vector<const char*>& arr,
    const char* & maxValue)
{
    const size_t size = arr.size();
    if (size == 0)
    {
        return false;
    }

    maxValue = "";
    for (size_t i = 0; i < size; i++)
    {
        if (std::strcmp(arr[i], maxValue) > 0)
        {
            maxValue = arr[i];
        }
    }

    return true;
}
