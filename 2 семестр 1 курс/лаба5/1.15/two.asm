public _two
.586
.model flat
.data
count   dd  0
.code
_two proc
                push    ebp
                mov             ebp,esp
                push    eax
                push    ecx
                push    esi
                push    edi
                push    ebx
                push    edx              
       
                mov esi, [ebp + 8]  ;адрес первой строчки матрицы
                ;смещение по строчкам
                mov     ebx, [ebp + 12]
                dec     ebx
                imul    ebx, 4

                mov     eax, [ebp + 12]     ;кол-во столбцов
                mov     ecx, 2              ;делитель
                cdq
                idiv    ecx

                mov     [count], eax

                xor     ecx, ecx    ;индекс строк
                xor     eax, eax    ;индекс столбцов
                
                ;цикл обмена закрашенных областей
                loop1:
                cmp     ecx, [count]
                je      exits
                    loop2:
                    cmp     eax, [ebp + 16]
                    je      met1

                    ;элемент лежит выше или на главной диаганали матрицы, если eax >= ebx
                    cmp     eax, ecx
                    jl      met2

                    ;элемент лежит выше или на побочной диагонали матрицы, если ecx + eax + 1 < n
                    mov     edx, ecx
                    add     edx, eax
                    inc     edx
                    cmp     edx, [ebp + 12]
                    jg      met2

                    ;элемент верхней области
                    mov     edi, [esi]
                    mov     edx, [edi + eax * 4]
                    
                    ;элемент нижней области
                    push    ebx
                    mov     edi, [esi + ebx]
                    mov     ebx, [edi + eax * 4]
                    ;замена элемента нижней области
                    mov     [edi + eax * 4], edx

                    mov     edi, [esi]
                    ;замена элемента верхней области
                    mov     [edi + eax * 4], ebx
                    pop     ebx

                    met2:
                    inc     eax         ;переход на следующий элемлент строки
                    jmp     loop2
                    met1:
                xor     eax,eax
                sub     ebx, 8
                inc     ecx     
                add     esi, 4  ;переход на следующую строку
                jmp    loop1
                exits:


                pop             edx
                pop             ebx
                pop             edi
                pop             esi
                pop             ecx
                pop             eax
                pop             ebp                
                ret
_two endp
end