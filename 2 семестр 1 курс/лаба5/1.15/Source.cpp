#include <iostream>
#include <string>
#include <fstream>

using namespace std;

extern "C"
{
	bool one(int** matrix, int N);//количество отрицательных элементов выше главной диагонали равно количеству положительных ниже ее
	int two(int** matrix, int N, int M);//помен€ть местами области верхний и нижний треугольники, образованные пересечением главной и побочной диагоналей
}

int** createMatrix(istream& in, int& n, int& m);
void printMatrix(int** matrix, int n, int m);
void deleteMatrix(int** matrix, int& n, int& m);

int main()
{
	setlocale(LC_ALL, "");
	string Menu[] = { "1. ¬вод матрицы с клавиатуры", "2. ¬вод матрицы из файла", "3. ¬ычисление характеристики", "4. ѕреобразование матрицы", "5. ѕечать матрицы", "6. ¬ыход" };
	int** matrix = nullptr, count, N, M;
	ifstream fin;
	while (true)
	{
		system("cls");					//очистка консоли
		//вывод меню
		for (int i = 0; i < 6; i++)
		{
			cout << Menu[i] << endl;
		}
		cin >> count;
		system("cls");
		switch (count)
		{
		case 1:
			deleteMatrix(matrix, N, M);
			matrix = createMatrix(cin, N, M);
			break;
		case 2:
			deleteMatrix(matrix, N, M);
			fin.open("input.txt");
			if (fin.is_open())
			{
				matrix = createMatrix(fin, N, M);
			}
			else
			{
				cout << "Ќе удалось открыть файл!" << endl;
				system("pause");
			}
			break;
		case 3:
			if (matrix)
			{
				if (one(matrix, N))		//проверка характеристика
				{
					cout << "True" << endl;
				}
				else
				{
					cout << "False" << endl;
				}
			}
			else
			{
				cout << "ћатрица не заполнена" << endl;
			}
			system("pause");
			break;
		case 4:
			if (matrix)
			{
				two(matrix, N, M);			//преобразование матрицы
			}
			else
			{
				cout << "ћатрица не заполнена" << endl;
				system("pause");
			}
			break;
		case 5:
			if (matrix)
			{
				printMatrix(matrix, N, M);
			}
			else
			{
				cout << "ћатрица не заполнена" << endl;
			}
			system("pause");
			break;
		default:
			deleteMatrix(matrix, N, M);
			return 0;
		}
	}
}

int** createMatrix(istream& in, int& n, int& m)
{
	in >> n >> m;
	int** matrix = new int* [n];
	for (int i = 0; i < n; i++)
	{
		matrix[i] = new int[m];
		for (int j = 0; j < m; j++)
		{
			in >> matrix[i][j];
		}
	}
	return matrix;
}

void printMatrix(int** matrix, int n, int m)
{
	cout << n << " " << m << endl;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			cout << matrix[i][j] << "\t";
		}
		cout << endl;
	}
}

void deleteMatrix(int** matrix, int& n, int& m)
{
	if (matrix)
	{
		for (int i = 0; i < n; i++)
		{
			delete[] matrix[i];
		}
		delete[] matrix;
		n = m = 0;
		matrix = nullptr;
	}
}
/*
5 5
1 2 3 4 5
6 7 8 9 10
11 12 13 14 15
16 17 18 19 20
21 22 23 24 25

5 5
-1 -2 -3 -4 1
0 9 8 1 3
3 -4 1 5 9
-3 1 4 -5 -7
1 3 10 -5 -6

*/