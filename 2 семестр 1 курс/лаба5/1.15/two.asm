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
       
                mov esi, [ebp + 8]  ;����� ������ ������� �������
                ;�������� �� ��������
                mov     ebx, [ebp + 12]
                dec     ebx
                imul    ebx, 4

                mov     eax, [ebp + 12]     ;���-�� ��������
                mov     ecx, 2              ;��������
                cdq
                idiv    ecx

                mov     [count], eax

                xor     ecx, ecx    ;������ �����
                xor     eax, eax    ;������ ��������
                
                ;���� ������ ����������� ��������
                loop1:
                cmp     ecx, [count]
                je      exits
                    loop2:
                    cmp     eax, [ebp + 16]
                    je      met1

                    ;������� ����� ���� ��� �� ������� ��������� �������, ���� eax >= ebx
                    cmp     eax, ecx
                    jl      met2

                    ;������� ����� ���� ��� �� �������� ��������� �������, ���� ecx + eax + 1 < n
                    mov     edx, ecx
                    add     edx, eax
                    inc     edx
                    cmp     edx, [ebp + 12]
                    jg      met2

                    ;������� ������� �������
                    mov     edi, [esi]
                    mov     edx, [edi + eax * 4]
                    
                    ;������� ������ �������
                    push    ebx
                    mov     edi, [esi + ebx]
                    mov     ebx, [edi + eax * 4]
                    ;������ �������� ������ �������
                    mov     [edi + eax * 4], edx

                    mov     edi, [esi]
                    ;������ �������� ������� �������
                    mov     [edi + eax * 4], ebx
                    pop     ebx

                    met2:
                    inc     eax         ;������� �� ��������� �������� ������
                    jmp     loop2
                    met1:
                xor     eax,eax
                sub     ebx, 8
                inc     ecx     
                add     esi, 4  ;������� �� ��������� ������
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