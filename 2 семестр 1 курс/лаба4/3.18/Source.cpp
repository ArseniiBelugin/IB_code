#include <iostream>
#include <windows.h>

using namespace std;

int main()
{
    char* line = new char[100];
    char* ptrword;                       //�����, ����������� �� ������ ������ ��������� �����
    int  len = 10000;                      //����� ������ ��������� �����
    char punctuation[9] = { ' ', '!', '.', ',', '?' , '-' , ';', ':', '\0' };       //�����������
    cin.getline(line, 100);
    __asm
    {
        pusha
        mov esi, line
        //����� ������ �����
        loop1 :
        cmp[esi], '\0'
            je  ex
            lea eax, punctuation
            //�������� �� �����������
            lp :
        cmp[eax], '\0'
            je      ex2
            mov     bh, [eax]
            cmp[esi], bh
            je      inc1
            inc     eax
            jmp     lp
            ex2 :
        mov    edx, esi

            //����� ����� �����
            loop2 :
        inc    esi
            cmp[esi], '\0'
            je     prov
            lea    eax, punctuation
            //�������� �� �����������
            lp2 :
            cmp[eax], '\0'
            je      loop2
            mov     bh, [eax]
            cmp[esi], bh
            je      prov
            inc     eax
            jmp     lp2

            inc1 :
        inc    esi
            jmp    loop1
            //���������� ����������� �����
            prov :
        mov   eax, esi
            sub   eax, edx
            cmp[len], eax
            jl    loop1
            mov[len], eax
            mov   ptrword, edx
            jmp   loop1
            ex :
        popa
    }
    for (int i = 0; i < len; i++)
    {
        cout << ptrword[i];
    }
    cout << endl;
    system("pause");
    return 0;
}
/*
* ������� �� �������� � �� ���� �������� ��������� ����� � ����� ����� ������; ������ ������� ���� � ������ ����������. ����� ��� ����� �� �������� �����, �� ���� ��� ������; ����� ��� ��������� � �������� ���� � ������ �����,
*/