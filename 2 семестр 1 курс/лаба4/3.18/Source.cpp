#include <iostream>
#include <windows.h>

using namespace std;

int main()
{
    char* line = new char[100];
    char* ptrword;                       //адрес, указывающий на начало самого короткого слова
    int  len = 10000;                      //длина самого короткого слова
    char punctuation[9] = { ' ', '!', '.', ',', '?' , '-' , ';', ':', '\0' };       //разделители
    cin.getline(line, 100);
    __asm
    {
        pusha
        mov esi, line
        //поиск начала слова
        loop1 :
        cmp[esi], '\0'
            je  ex
            lea eax, punctuation
            //проверка на разделители
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

            //поиск конца слова
            loop2 :
        inc    esi
            cmp[esi], '\0'
            je     prov
            lea    eax, punctuation
            //проверка на разделители
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
            //сохранение подходящего слова
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
* Октябрь уж наступил — уж роща отряхает Последние листы с нагих своих ветвей; Дохнул осенний хлад — дорога промерзает. Журча еще бежит за мельницу ручей, Но пруд уже застыл; сосед мой поспешает В отъезжие поля с охотою своей,
*/