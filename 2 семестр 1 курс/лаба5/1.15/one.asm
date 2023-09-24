public _one
.586
.model flat
.data
otr     dd      0   ;кол-во отрицательных элементов
pol     dd      0   ;кол-во положительных элементов                
.code
_one proc
                push    ebp
                mov     ebp, esp
                push    ecx
                push    esi
                push    edi
                push    ebx
                push    edx             

                xor     ecx, ecx
                xor     ebx, ebx
                mov     esi, [ebp + 8]      ;адрес первой строчки
                loop1:
                cmp     ecx, [ebp + 12]     ;проверка на выход за границы матрицы
                je      met2

                mov     edi, [esi]          ;адрес первого элемента строчки
                xor     ebx, ebx            ;индекс столбца
                loop2:
                        cmp     ebx, [ebp + 12]         ;проверка на выход за границы матрицы
                        je      met3

                        mov     eax, [edi]              ;текущее значение
                        ;элемент лежит выше главной диаганали матрицы, если ecx < ebx
                        cmp     ecx, ebx
                        jg      met1

                        cmp     eax, 0
                        jge     met4
                        mov     eax, [otr]
                        inc     eax
                        mov     [otr], eax
                        jmp     met4

                        met1:
                        cmp     eax, 0
                        jl      met4
                        mov     eax, [pol]
                        inc     eax
                        mov     [pol], eax

                        met4:
                        add      edi,4      ;переход к след элементу строки
                        inc      ebx
                        jmp      loop2

                met3:
                add     esi, 4               ;переход к след строчке
                inc     ecx
                jmp     loop1
                met2:             
                
                mov     ebx, [otr]
                mov     edx, [pol]
                cmp     edx, ebx
                jne     false

                mov     eax, 1
                jmp     exits

                false:
                xor     eax, eax

                exits:
                pop             edx
                pop             ebx
                pop             edi
                pop             esi
                pop             ecx
                pop             ebp
                ret
_one endp
end