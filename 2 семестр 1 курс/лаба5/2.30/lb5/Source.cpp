#include<iostream>
#include<fstream>
#include<iomanip>
#include<string>
#include<limits>

using namespace std;
extern "C"
{
	int Charasteristic(int** A, int n, int m);
}

int main()
{
	setlocale(LC_ALL, "");
	ifstream inFile("input.txt");
	int n, m;
	inFile >> n >> m;
	int** matrix = new int* [n];
	for (int i = 0; i < n; i++)
	{
		matrix[i] = new int[m];
	}
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			inFile >> matrix[i][j];
		}
	}
	inFile.close();
	int maxarea = Charasteristic(matrix, n, m);
	cout << "Максимальная возможная площадь прямоугольного дома: " << maxarea << endl;
	for (int i = 0; i < n; i++)
	{
		delete[] matrix[i];
	}
	delete[] matrix;
}
